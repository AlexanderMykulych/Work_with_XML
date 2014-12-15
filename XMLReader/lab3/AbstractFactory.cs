using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class AbstractFactory
    {
        public string FileDir { set; get; }

        public AbstractFactory(string fileDir)
        {
            FileDir = fileDir;
        }
        //strLine = "atrib1=value1#atrib2=value2#atrib3=value3#..."
        public virtual string Search(object param)
        {
            return "";
        }

        public virtual AllAtr GetAtr()
        {
            return null;
        }
    }
}
