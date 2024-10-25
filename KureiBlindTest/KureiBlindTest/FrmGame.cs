using MySql.Data.MySqlClient;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace KureiBlindTest
{
    public partial class FrmGame : Form
    {
        private NavigationService navigationService;

        Styles styles = new Styles();
        private int _nround;
        private int _remainingPlays;
        private bool isPlaying = false;
        private WaveOutEvent waveOut;
        private float volume = 0.1f;
        private Song selectedSong;
        private TimeSpan startPosition;

        public int Nround { get => _nround; set => _nround = value; }
        public int RemainingPlays { get => _remainingPlays; set => _remainingPlays = value; }

        Song answerChosed;
        Song realAnswer;
        int score;

        public FrmGame(NavigationService navService)
        {
            InitializeComponent();
            navigationService = navService;
            Nround = 0;
            RemainingPlays = 0;
            score = 0;


        }

      


        public void UpdateUI()
        {
            lblRemainingPlays.Text = $"Remaining plays : {RemainingPlays}";
            lblTitle.Text = $"Round N°{Nround}";
            if (Nround - 1 != 0)
            {
                lblScore.Text = $"Score : {score}/{Nround - 1}";
            }
        }

        private void FrmGame_LoadAsync(object sender, EventArgs e)
        {
            this.newRound();
            UpdateUI();
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
                                    startPosition = TimeSpan.FromSeconds(random.NextDouble() * (totalDuration.TotalSeconds - 5));
                                    break;

                                case "Medium":
                                    startPosition = TimeSpan.FromSeconds(random.NextDouble() * (totalDuration.TotalSeconds - 3));
                                    break;

                                case "Hard":
                                    startPosition = TimeSpan.FromSeconds(random.NextDouble() * (totalDuration.TotalSeconds - 1));
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

                // Récupérer le manifeste de flux vidéo
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(youtubeLink);

                // Sélectionner le meilleur flux audio
                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                if (streamInfo != null)
                {
                    // Télécharger le flux en mémoire
                    using (var stream = await youtube.Videos.Streams.GetAsync(streamInfo))
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);

                        // Sauvegarder le flux dans un fichier temporaire
                        string tempFilePath = Path.GetTempFileName();
                        using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        {
                            memoryStream.Position = 0;
                            await memoryStream.CopyToAsync(fileStream);
                        }

                        // Lire le segment audio à partir de la position de départ choisie
                        using (var reader = new MediaFoundationReader(tempFilePath))
                        {
                            reader.CurrentTime = startPosition;

                            // Initialiser le lecteur audio avec le flux
                            waveOut.Init(reader);
                            waveOut.Volume = volume; // Définir le volume actuel
                            waveOut.Play();

                            // Ajouter un délai pour éviter que le lecteur ne se mette en pause immédiatement
                            await Task.Delay(100); // Laisser le temps au lecteur de démarrer

                            // Durée de lecture en fonction de la difficulté
                            switch (Properties.Settings.Default.Difficulty)
                            {
                                case "Easy":
                                    await Task.Delay(TimeSpan.FromSeconds(5));
                                    break;

                                case "Medium":
                                    await Task.Delay(TimeSpan.FromSeconds(3));
                                    break;

                                case "Hard":
                                    await Task.Delay(TimeSpan.FromSeconds(1));
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
                    // Ne pas arrêter le lecteur si il n'est pas en lecture
                    if (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        pbxLogo.Image = Properties.Resources.play;
                        waveOut.Stop(); // Arrête la lecture audio avec NAudio
                    }
                }

                isPlaying = !isPlaying;
                UpdateUI();
            }
        }


        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            // Arrêtez la lecture de l'audio et mettez à jour l'interface utilisateur
            if (InvokeRequired)
            {
                Invoke((Action)(() => WaveOut_PlaybackStopped(sender, e)));
                return;
            }

            // Réinitialisez l'état de lecture
            pbxLogo.Image = Properties.Resources.play;
            isPlaying = false; // Mettez à jour isPlaying à false ici
        }





        public void newRound()
        {
            Nround += 1;
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

            // Stop the currently playing music
            if (waveOut != null && isPlaying)
            {
                waveOut.Stop();
                pbxLogo.Image = Properties.Resources.pause; // Change the image to pause
                isPlaying = false; // Update the isPlaying flag
            }

            UpdateUI();

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
                realAnswer = allSongs[randomIndex];

                // Choisissez un extrait aléatoire de cette chanson
                var youtubeLink = selectedSong.LinkYoutube;
                Task.Run(async () => await ChooseRandomStartPosition(youtubeLink));
            }

            // Création de la liste des réponses
            List<Song> lstAnswers = new List<Song> { realAnswer }; // Assurez-vous que la bonne réponse est là
            Random rng = new Random();

            // Ajoutez d'autres chansons aléatoires
            while (lstAnswers.Count < 4)
            {
                int index = rng.Next(0, allSongs.Count);
                if (!lstAnswers.Contains(allSongs[index])) // Assurez-vous qu'on n'ajoute pas la même chanson
                {
                    lstAnswers.Add(allSongs[index]);
                }
            }

            // Mélanger les réponses
            lstAnswers = lstAnswers.OrderBy(a => rng.Next()).ToList();
            List<Control> lstOptions = new List<Control> { btnOption1, btnOption2, btnOption3, btnOption4 };

            for (int i = 0; i < lstOptions.Count; i++)
            {
                lstOptions[i].Enabled = true;
                lstOptions[i].Text = $"{lstAnswers[i].ArtistSong} - {lstAnswers[i].NameSong}";

                // Vérifiez si la réponse est correcte
                bool isTheCorrectAnswer = (realAnswer.NameSong == lstAnswers[i].NameSong);
                lstOptions[i].Tag = (isTheCorrectAnswer, realAnswer.NameSong);
            }
        }



        private void btnOption1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            var tagTuple = ((bool, string))btn.Tag;

            // Extraire les éléments du ValueTuple
            bool isTheCorrectAnswer = tagTuple.Item1;
            string song = tagTuple.Item2;


            // Utiliser isTheCorrectAnswer et song
            if (isTheCorrectAnswer)
            {
                score += 1;
                lblInfo.Text = $"Correct";
                //styles.LoadCustomFont(lblInfo, 20f, Color.Green);
            }
            else
            {
                lblInfo.Text = $"Incorrect, answer was {song}";
                //styles.LoadCustomFont(lblInfo, 20f, Color.Red);
            }

            this.newRound();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
            }
        }

        private void FrmGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }


}
