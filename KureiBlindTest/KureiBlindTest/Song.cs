using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KureiBlindTest
{
    public class Song
    {
        // Champs
        private int _idSong;
        private string _nameSong;
        private string _artistSong;
        private Genre _genre;
        private string _linkYoutube;

        // Propriétés
        public int IdSong { get => _idSong; set => _idSong = value; }
        public string NameSong { get => _nameSong; set => _nameSong = value; }
        public string ArtistSong { get => _artistSong; set => _artistSong = value; }
        public string LinkYoutube { get => _linkYoutube; set => _linkYoutube = value; }
        internal Genre Genre { get => _genre; set => _genre = value; }

        // Constructeur
        public Song(int idSong, string nameSong, string artistSong, string linkYoutube, Genre genre)
        {
            IdSong = idSong;
            NameSong = nameSong;
            ArtistSong = artistSong;
            LinkYoutube = linkYoutube;
            Genre = genre;
        }
    }
}
