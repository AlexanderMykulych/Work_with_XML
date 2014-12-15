using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Linq;
using System.Windows;

namespace lab3
{
    class LinqFactory : AbstractFactory
    {
        XDocument doc;
        public LinqFactory(string fileDir):base(fileDir)
        {
            doc = XDocument.Load(fileDir);
        }
        public override string Search(object param)
        {
            base.Search(param);

            string sRes = "";
            string str = (string)param;
            string[] strList = str.Split(new Char[] { '#' });


            var result = (from obj in doc.Descendants("book")
                          where ((strList[0] == ""? obj.Attribute("NAME").Value.Any():obj.Attribute("NAME").Value == strList[0]) &&
                                 (strList[1] == "" ? obj.Element("info").Attribute("autor").Value.Any() : obj.Element("info").Attribute("autor").Value == strList[1]) &&
                                 (strList[2] == "" ? obj.Element("info").Attribute("publishingHouse").Value.Any() : obj.Element("info").Attribute("publishingHouse").Value == strList[2]) &&
                                 (strList[3] == "" ? obj.Element("info").Attribute("year").Value.Any() : obj.Element("info").Attribute("year").Value == strList[3]) &&
                                 (strList[4] == "" ? obj.Element("info").Attribute("pageCount").Value.Any() : obj.Element("info").Attribute("pageCount").Value == strList[4]) &&
                                 (strList[5] == "" ? obj.Element("info").Attribute("printingCount").Value.Any() : obj.Element("info").Attribute("printingCount").Value == strList[5]) &&
                                 (strList[6] == "" ? obj.Element("info").Attribute("language").Value.Any() : obj.Element("info").Attribute("language").Value == strList[6])
                                 )
                          select new
                          {
                              name = obj.Attribute("NAME").Value,
                              autor = (string)obj.Element("info").Attribute("autor"),
                              publishingHouse = obj.Element("info").Attribute("publishingHouse").Value,
                              year = obj.Element("info").Attribute("year").Value,
                              pageCount = obj.Element("info").Attribute("pageCount").Value,
                              printingCount = obj.Element("info").Attribute("printingCount").Value,
                              language = obj.Element("info").Attribute("language").Value
                          }).ToList();
                            

            foreach(var el in result)
            {
                sRes += "NAME:  " + el.name + '\n';
                sRes += "autor: " + el.autor + '\n';
                sRes += "publishingHouse:   " + el.publishingHouse + '\n';
                sRes += "year:  " + el.year + '\n';
                sRes += "pageCount: " + el.pageCount + '\n';
                sRes += "printingCount: " + el.printingCount + '\n';
                sRes += "language:  " + el.language + '\n';
                sRes += "===========LINQ TO XML===========\n";

            }

            return sRes;
            
        }

        public override AllAtr GetAtr()
        {
            base.GetAtr();

            AllAtr atr = new AllAtr();

            foreach(XElement el in doc.Root.Elements())
            {
                if (el.Name == "book")
                {
                    atr.Name.Add(el.Attribute("NAME").Value);

                    foreach (XElement el2 in el.Elements())
                    {
                        atr.publishingHouse.Add(el2.Attribute("publishingHouse").Value);
                        atr.pageCount.Add(el2.Attribute("pageCount").Value);
                        atr.printingCount.Add(el2.Attribute("printingCount").Value);
                        atr.year.Add(el2.Attribute("year").Value);
                        atr.language.Add(el2.Attribute("language").Value);
                        atr.Autor.Add(el2.Attribute("autor").Value);
                    }
                }
            }


            return atr;
        }
    }
}
