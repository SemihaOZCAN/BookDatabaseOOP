using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabaseOOP
{
    internal class Kitap
    {
        int id;
        string ad;
        string yazar;

        public int ID
        {
            get { return id; }
            set { id = value; }

        }
        public string KITAPAD 
        { 
            get { return ad; } 
            set {  ad = value; }
        }
        public string YAZAR
        {
            get { return yazar; }
            set { yazar = value; }
        }
    }
}
