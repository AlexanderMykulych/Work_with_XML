using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    static class XPathCreater
    {
        public static string Create(string str)
        {
            string result = "/libraryDatabase/book[";            
            
            string[] strList = str.Split(new Char[] { '#' });
            string[] strListC = new string[] {"@NAME", "@autor", "@year", "@pageCount", "@printingCount", "@language"};

            result += strListC[0];

            if (strList[0] != "")
                result +="=\"" + strList[0] + "\"";

            result += " and info[";
            for (int i = 1; i < strList.Length-1; i++)
            {
                if (i == 1)
                    result += strListC[i];
                else
                    result += " and " + strListC[i];
                if (strList[i] != "")
                    result += "=\"" + strList[i] + "\"";
                    
            }

            result += "]]";
            
                return result;
        }
    }
}
