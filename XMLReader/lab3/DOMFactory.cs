using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;

namespace lab3
{
    class DOMFactory : AbstractFactory
    {
        private XmlDocument doc;
        public DOMFactory(string fileDir):base(fileDir)
        {
            doc = new XmlDocument();
            doc.Load(fileDir);
        }

        public override AllAtr GetAtr()
        {
            base.GetAtr();

            var nodeR = new XmlNodeReader(doc);
            AllAtr atr = new AllAtr();
           // MessageBox.Show("asd");
            while(nodeR.Read())
            {
                

                if(nodeR.Name == "book")
                {
                    atr.Name.Add(nodeR.GetAttribute("NAME"));
                    nodeR.Read();
                }
                else
                {
                    if (nodeR.Name == "info")
                    {
                        atr.publishingHouse.Add(nodeR.GetAttribute("publishingHouse"));
                        atr.pageCount.Add(nodeR.GetAttribute("pageCount"));
                        atr.printingCount.Add(nodeR.GetAttribute("printingCount"));
                        atr.year.Add(nodeR.GetAttribute("year"));
                        atr.language.Add(nodeR.GetAttribute("language"));
                        atr.Autor.Add(nodeR.GetAttribute("autor"));
                    }
                }


                //MessageBox.Show(nodeR.Name + " " + nodeR.GetAttribute("NAME") + " " + nodeR.GetAttribute("autor"));
           
            }

            return atr;
        }
        public override string Search(object param)
        {

            base.Search(param);

            string result = "";

            string XPath = XPathCreater.Create((string)param);
            //string XPath = "/libraryDatabase/book[@NAME=\"ABS\" and info[@autor=\"ABS\" and @year]]";
            //MessageBox.Show("DOM: " + XPath);
            var elems = doc.SelectNodes(XPath);

            //MessageBox.Show("DOM: " + elems.Count.ToString());
            foreach(XmlNode node in elems)
            {
                result += AddAllAtribut(node);
                result += "========DOM========\n";
            }

            return result;
        }
        

        private string AddAllAtribut(XmlNode node)
        {
            string result = "";
            
            foreach (XmlAttribute atr in node.Attributes)
            {
                result += atr.Name.ToString();
                result += ":    " + atr.Value;
                result += "\n";

            }

            if(node.ChildNodes.Count > 0)
            {
                foreach(XmlNode Node in node.ChildNodes)
                {
                    result += AddAllAtribut(Node);
                }
            }

            return result;
        }
    }
}
