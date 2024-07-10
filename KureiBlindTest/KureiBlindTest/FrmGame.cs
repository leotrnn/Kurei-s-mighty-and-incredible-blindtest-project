using MySql.Data.MySqlClient;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace KureiBlindTest
{
    public partial class FrmGame : Form
    {
        Styles styles = new Styles();
        private int _nround;
        private int _remainingPlays;
        private bool isPlaying = false;
        private WaveOutEvent waveOut; // Pour gérer la lecture audio avec NAudio
        private float volume = 0.1f; // Niveau de volume initial (1.0 = 100%)
        private Song selectedSong; // Chanson choisie au départ
        private TimeSpan startPosition; // Position de départ aléatoire de l'extrait

        public int Nround { get => _nround; set => _nround = value; }
        public int RemainingPlays { get => _remainingPlays; set => _remainingPlays = value; }

        public FrmGame()
        {
            Nround = 1;
            RemainingPlays = 3;
            InitializeComponent();
            this.FormClosing += FrmGame_FormClosing;
            this.StartPosition = FormStartPosition.CenterParent; // Centrer par rapport au parent

            // Initialisation de WaveOutEvent pour la lecture audio
            waveOut = new WaveOutEvent();
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped; // Abonnez-vous à l'événement PlaybackStopped

            // Charger toutes les chansons une fois au chargement du formulaire
            List<Song> allSongs = SelectAllSongs();
            if (allSongs.Count > 0)
            {
                // Choisissez une chanson au hasard au départ
                Random random = new Random();
                int randomIndex = random.Next(0, allSongs.Count);
                selectedSong = allSongs[randomIndex];

                // Choisissez un extrait aléatoire de cette chanson
                var youtubeLink = selectedSong.LinkYoutube;
                Task.Run(async () => await ChooseRandomStartPosition(youtubeLink));
            }

            switch (Properties.Settings.Default.Difficulty)
            {
                case "Easy":
                    RemainingPlays = 3;
                    break;

                case "Medium":
                    RemainingPlays = 2;
                    break;

                case "Hard":
                    RemainingPlays = 1;
                    break;
            }
        }

        public void UpdateUI()
        {
            lblRemainingPlays.Text = $"Remaining plays : {RemainingPlays}";
            lblTitle.Text = $"Round N°{Nround}";
        }

        private void FrmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            UpdateUI();
            this.BackColor = styles.ColorBack;
            styles.CenterControl(lblTitle, this.ClientSize.Width);
            styles.CenterControl(pbxLogo, this.ClientSize.Width);
            styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);
            styles.LoadCustomFont(lblRemainingPlays, 20f, styles.ColorFont);
        }

        public List<Song> SelectAllSongs()
        {
            List<Song> lstSongs = new List<Song>();
            string connectionString = ConfigurationManager.ConnectionStrings["KureiBlindTest"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM SONGS JOIN GENRES on SONGS.idGenre = GENRES.idGenre";

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int idSong = Convert.ToInt32(row["idSong"]);
                            string nameSong = row["nameSong"].ToString();
                            string artistSong = row["artistSong"].ToString();
                            string linkYoutube = row["song"].ToString();
                            Genre genreSong = new Genre(Convert.ToInt32(row["idGenre"]), row["nameGenre"].ToString());

                            lstSongs.Add(new Song(idSong, nameSong, artistSong, linkYoutube, genreSong));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message);
                }
            }

            return lstSongs;
        }


        private async Task ChooseRandomStartPosition(string youtubeLink)
        {
            try
            {
                var youtube = new YoutubeClient();

                // Get the video stream manifest
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(youtubeLink);

                // Select the best audio stream
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                if (streamInfo != null)
                {
                    // Download the stream to memory
                    using (var stream = await youtube.Videos.Streams.GetAsync(streamInfo))
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);

                        // Save the stream to a temporary file
                        string tempFilePath = Path.GetTempFileName();
                        using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        {
                            memoryStream.Position = 0;
                            await memoryStream.CopyToAsync(fileStream);
                        }

                        // Get total duration of the audio
                        using (var reader = new MediaFoundationReader(tempFilePath))
                        {
                            var totalDuration = reader.TotalTime;

                            // Choose a random start position, ensuring there's at least 5 seconds left
                            var random = new Random();
                            switch (Properties.Settings.Default.Difficulty)
                            {
                                case "Easy":
                                    startPosition = TimeSpan.FromSeconds(random.NextDouble() * (totalDuration.TotalSeconds - 10));
                                    break;

                                case "Medium":
                                    startPosition = TimeSpan.FromSeconds(random.NextDouble() * (totalDuration.TotalSeconds - 5));
                                    break;

                                case "Hard":
                                    startPosition = TimeSpan.FromSeconds(random.NextDouble() * (totalDuration.TotalSeconds - 3));
                                    break;
                            }

                            // Clean up the temporary file
                            File.Delete(tempFilePath);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Aucun flux audio trouvé pour cette vidéo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la lecture de l'audio de YouTube : " + ex.Message);
            }
        }

        private async Task PlayAudioFromYoutube(string youtubeLink)
        {
            try
            {
                var youtube = new YoutubeClient();

                // Get the video stream manifest
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(youtubeLink);

                // Select the best audio stream
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                if (streamInfo != null)
                {
                    // Download the stream to memory
                    using (var stream = await youtube.Videos.Streams.GetAsync(streamInfo))
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);

                        // Save the stream to a temporary file
                        string tempFilePath = Path.GetTempFileName();
                        using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        {
                            memoryStream.Position = 0;
                            await memoryStream.CopyToAsync(fileStream);
                        }

                        // Play the selected random 5 second segment using NAudio
                        using (var reader = new MediaFoundationReader(tempFilePath))
                        {
                            reader.CurrentTime = startPosition;

                            // Utilisation de waveOut global pour permettre l'arrêt depuis pbxLogo_Click
                            waveOut.Init(reader);
                            waveOut.Volume = volume; // Définit le volume actuel
                            waveOut.Play();

                            // Durée de lecture en fonction de la difficulté
                            switch (Properties.Settings.Default.Difficulty)
                            {
                                case "Easy":
                                    await Task.Delay(TimeSpan.FromSeconds(10));
                                    break;

                                case "Medium":
                                    await Task.Delay(TimeSpan.FromSeconds(5));
                                    break;

                                case "Hard":
                                    await Task.Delay(TimeSpan.FromSeconds(3));
                                    break;
                            }
                        }

                        waveOut.Stop();

                        // Nettoyer le fichier temporaire
                        File.Delete(tempFilePath);
                    }
                }
                else
                {
                    MessageBox.Show("Aucun flux audio trouvé pour cette vidéo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la lecture de l'audio de YouTube : " + ex.Message);
            }
        }

        private void pbxLogo_Click(object sender, EventArgs e)
        {
            if (RemainingPlays > 0)
            {

                // Alterne entre play et pause
                if (!isPlaying)
                {
                    RemainingPlays -= 1;
                    pbxLogo.Image = Properties.Resources.pause;
                    string youtubeLink = selectedSong.LinkYoutube;
                    Task.Run(async () => await PlayAudioFromYoutube(youtubeLink));
                }
                else
                {
                    pbxLogo.Image = Properties.Resources.play;
                    waveOut.Stop(); // Arrête la lecture audio avec NAudio
                }

                isPlaying = !isPlaying;
                UpdateUI();
            }
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            // Lorsque la lecture s'arrête, revenez à l'icône "Play"
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    pbxLogo.Image = Properties.Resources.play;
                });
            }
            else
            {
                pbxLogo.Image = Properties.Resources.play;
            }

            isPlaying = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            waveOut.Dispose(); // Libère les ressources NAudio
        }
    }
}
