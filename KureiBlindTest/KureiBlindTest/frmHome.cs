using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using NAudio.Wave;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace KureiBlindTest
{
    public partial class frmHome : Form
    {
        Styles styles = new Styles();

        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            List<Control> lstControls = new List<Control>
            {
                pbxLogo, lblTitle, btnPlay, btnQuit
            };

            foreach (Control c in lstControls)
            {
                styles.CenterControl(c, this.ClientSize.Width);
            }

            styles.CustomizeButton(btnPlay);
            styles.CustomizeButton(btnQuit);
            styles.LoadCustomFont(lblTitle, 32f, styles.ColorFont);

            this.BackColor = styles.ColorBack;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmChoiceCategory frmChoice = new FrmChoiceCategory();

            frmChoice.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
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

        private async void playButton_Click(object sender, EventArgs e)
        {
            string linkYoutube = this.SelectAllSongs()[0].LinkYoutube;
            await PlayAudioFromYoutube(linkYoutube);
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

                        // Play a random 5 second segment using NAudio
                        using (var reader = new MediaFoundationReader(tempFilePath))
                        {
                            var totalDuration = reader.TotalTime;
                            var random = new Random();
                            var startPosition = random.NextDouble() * (totalDuration.TotalSeconds - 5); // Choose a random start position, ensuring there's at least 5 seconds left
                            reader.CurrentTime = TimeSpan.FromSeconds(startPosition);

                            using (var waveOut = new WaveOutEvent())
                            {
                                waveOut.Init(reader);
                                waveOut.Play();
                                await Task.Delay(TimeSpan.FromSeconds(5)); // Play for 5 seconds
                                waveOut.Stop();
                            }
                        }
                        
                        // Clean up the temporary file
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

    }
}