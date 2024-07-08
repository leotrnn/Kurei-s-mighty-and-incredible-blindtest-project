using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KureiBlindTest
{
    internal class Genre
    {
        // Champs
        private int _idGenre;
        private string _nameGenre;

        // Propriétés
        public int IdGenre { get => _idGenre; set => _idGenre = value; }
        public string NameGenre { get => _nameGenre; set => _nameGenre = value; }

        // Constructeurs
        public Genre(int idGenre, string nameGenre)
        {
            IdGenre = idGenre;
            NameGenre = nameGenre;
        }
    }
}
