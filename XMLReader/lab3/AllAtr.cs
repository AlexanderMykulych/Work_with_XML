using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class AllAtr
    {
        public List<string> Name;
        public List<string> Autor;
        public List<string> publishingHouse;
        public List<string> year;
        public List<string> pageCount;
        public List<string> printingCount;
        public List<string> language;
        public AllAtr()
        {
            Name = new List<string>();
            Autor = new List<string>();
            publishingHouse = new List<string>();
            year = new List<string>();
            pageCount = new List<string>();
            printingCount = new List<string>();
            language = new List<string>();
        }
    }
}
