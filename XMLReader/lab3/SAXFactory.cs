using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;

namespace lab3
{
    class SAXFactory : AbstractFactory
    {
        string[] strListC = new string[] { "NAME", "autor", "publishingHouse", "year", "pageCount", "printingCount", "language" };
        public SAXFactory(string fileDir):base(fileDir)
        {
            
        }
        public override string Search(object param)
        {
            base.Search(param);

            string result = "";

            string str = (string)param;
            string[] strList = str.Split(new Char[] { '#' });

            string r = "";
            foreach(string s in strList)
            {
                r += s;
            }
           // MessageBox.Show(r);

            var doc = new XmlTextReader(FileDir);
            doc.WhitespaceHandling = WhitespaceHandling.None;
            while(doc.Read())
            {
                if(doc.NodeType == XmlNodeType.Element)
                {
                    string res = "";
                    
                   // MessageBox.Show(doc.Name);
                    if(doc.Name == "book")
                    {
                        bool itGoodEl = true;

                        if (strList[0] != "")
                            if (doc.GetAttribute("NAME") != strList[0])
                            {
                               // MessageBox.Show(doc.GetAttribute("NAME") + " " + strList[0]);
                                itGoodEl = false;
                            }
                            else
                            {
                              //  MessageBox.Show(doc.GetAttribute("NAME") + " " + strList[0]);
                            }
                        if (itGoodEl)
                        {
                            res += "NAME:   " + doc.GetAttribute("NAME") + '\n';
                            doc.Read();
                            if (doc.Name != "info")
                            {
                                MessageBox.Show(doc.Name);
                                throw new Exception("щось не так з xml файлом!");
                            }
                            //MessageBox.Show(doc.GetAttribute("auto"))
                            for (int i = 1; i < 6; i++)
                            {

                                //MessageBox.Show(strListC[i] + " = " + doc.GetAttribute(strListC[i]) + " ======" + strList[i]);
                                res += strListC[i] + ":    " + doc.GetAttribute(strListC[i]) + '\n';
                                if(strList[i] != "")
                                    if (doc.GetAttribute(strListC[i]) != strList[i])
                                    {
                                        itGoodEl = false;
                                        break;
                                    }
                            }
                        }

                        if (itGoodEl)
                        {
                            result += res;
                            result += "========SAX========\n";
                        }

                    }
                    
                }

            }

            return result;

        }
        public override AllAtr GetAtr()
        {
            base.GetAtr();

            AllAtr atr = new AllAtr();

            var doc = new XmlTextReader(FileDir);
            doc.WhitespaceHandling = WhitespaceHandling.None;
            while (doc.Read())
            {
                if (doc.Name == "book")
                {
                    atr.Name.Add(doc.GetAttribute("NAME"));
                   // doc.Read();
                }
                else
                {
                    if (doc.Name == "info")
                    {
                        atr.publishingHouse.Add(doc.GetAttribute("publishingHouse"));
                        atr.pageCount.Add(doc.GetAttribute("pageCount"));
                        atr.printingCount.Add(doc.GetAttribute("printingCount"));
                        atr.year.Add(doc.GetAttribute("year"));
                        atr.language.Add(doc.GetAttribute("language"));
                        atr.Autor.Add(doc.GetAttribute("autor"));
                    }
                }
                //MessageBox.Show(nodeR.Name + " " + nodeR.GetAttribute("NAME") + " " + nodeR.GetAttribute("autor"));

            }

            return atr;
        }
    }
}
