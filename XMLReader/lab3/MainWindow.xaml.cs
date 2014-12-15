using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Xsl;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FileDir = @"E:\Програмування\С#\XnaProject\lab3\BD.xml";
        string FileDirXsl = @"E:\Програмування\С#\XnaProject\lab3\BD.xsl";
        string FileDirHtml = @"E:\Програмування\С#\XnaProject\lab3\BD.html";

        AbstractFactory factory;
        List<AbstractFactory> factorys;
        public MainWindow()
        {
            InitializeComponent();


            AddToComboBox(ComboBox1, "Linq");
            AddToComboBox(ComboBox1, "DOM");
            AddToComboBox(ComboBox1, "SAX");

            factorys = new List<AbstractFactory>();

            factorys.Add(new LinqFactory(FileDir));
            factorys.Add(new DOMFactory(FileDir));
            factorys.Add(new SAXFactory(FileDir));


            factory = factorys[0];
            ComboBoxFill();
        }

        private void AddToComboBox(ComboBox cb, string text)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;

            cb.Items.Add(tb);
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            

            

            string sl = "";
            sl += TextBox2.Text + "#";
            sl += TextBox3.Text + "#";
            sl += TextBox4.Text + "#";
            sl += TextBox5.Text + "#";
            sl += TextBox6.Text + "#";
            sl += TextBox7.Text + "#";
            sl += TextBox8.Text;



            TextBox1.Text = factory.Search(sl);

        }


        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            factory = factorys[ComboBox1.SelectedIndex];
        }
        public void ComboBoxFill()
        {
            TextBox2.Items.Clear();
            TextBox3.Items.Clear();
            TextBox4.Items.Clear();
            TextBox5.Items.Clear();
            TextBox6.Items.Clear();
            TextBox7.Items.Clear();
            TextBox8.Items.Clear();
            AllAtr atr = factory.GetAtr();

            {
                TextBlock txt_p1 = new TextBlock();
                txt_p1.Text = "";

                TextBox2.Items.Add(txt_p1);
            }
            {
                TextBlock txt_p2 = new TextBlock();
                txt_p2.Text = "";

                TextBox3.Items.Add(txt_p2);
            }
            {
                TextBlock txt_p3 = new TextBlock();
                txt_p3.Text = "";

                TextBox4.Items.Add(txt_p3);
            }

            {
                TextBlock txt_p4 = new TextBlock();
                txt_p4.Text = "";

                TextBox5.Items.Add(txt_p4);
            }
            {
                TextBlock txt_p5 = new TextBlock();
                txt_p5.Text = "";

                TextBox6.Items.Add(txt_p5);
            }
            {
                TextBlock txt_p6 = new TextBlock();
                txt_p6.Text = "";

                TextBox7.Items.Add(txt_p6);
            }
            {
                TextBlock txt_p7 = new TextBlock();
                txt_p7.Text = "";

                TextBox8.Items.Add(txt_p7);
            }


            for (int i = 0; i < atr.Name.Count; i++)
            {
                TextBlock txt = new TextBlock();
                txt.Text = atr.Name[i];

                TextBox2.Items.Add(txt);
            }

            for (int i = 0; i < atr.Autor.Count; i++)
            {
                TextBlock txt = new TextBlock();
                txt.Text = atr.Autor[i];

                TextBox3.Items.Add(txt);
            }



            for (int i = 0; i < atr.publishingHouse.Count; i++)
            {
                TextBlock txt = new TextBlock();
                txt.Text = atr.publishingHouse[i];

                TextBox4.Items.Add(txt);
            }

            for (int i = 0; i < atr.year.Count; i++)
            {
                TextBlock txt = new TextBlock();
                txt.Text = atr.year[i];

                TextBox5.Items.Add(txt);
            }

            for (int i = 0; i < atr.pageCount.Count; i++)
            {
                TextBlock txt = new TextBlock();
                txt.Text = atr.pageCount[i];

                TextBox6.Items.Add(txt);
            }

            for (int i = 0; i < atr.printingCount.Count; i++)
            {
                TextBlock txt = new TextBlock();
                txt.Text = atr.printingCount[i];

                TextBox7.Items.Add(txt);
            }

            for (int i = 0; i < atr.language.Count; i++)
            {
                TextBlock txt = new TextBlock();
                txt.Text = atr.language[i];

                TextBox8.Items.Add(txt);
            }
        }

        private void TransformToHtml(string fileDir1, string fileDir2, string fileDir3)
        {
            XslCompiledTransform tr = new XslCompiledTransform();
            tr.Load(fileDir1);

            tr.Transform(fileDir2, fileDir3);
        }


        private void Transform(object sender, RoutedEventArgs e)
        {
            TransformToHtml(FileDirXsl, FileDir, FileDirHtml);
            MessageBox.Show("Трансформовано успішно!");
        }

        
    }
}
