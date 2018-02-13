using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Search_Engine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainEngine : Window
    {
        public MainEngine()
        {
            
            //Console.OutputEncoding = System.Text.Encoding.Default;
            //string fileName = "City.txt";
            //string search = "Яремче";
            //string[] arrString = File.ReadAllLines(fileName, Encoding.Default);
            //Deamon d = new Deamon(arrString, search);
            //d.Create(3, arrString, search);
            //Console.ReadKey();
            InitializeComponent();
           

        }
        public static string inFunc = "No";
        public static string fileName = "in.txt";
        public static string searchStr = "vvvsm456@hotmail.com";
        public static int numb = 3;
        public void ENTER_Click(object sender, RoutedEventArgs e)
        {
            string text =EnterVal.Text;
            if (text != "")
            {
                switch(inFunc)
                {
                    case ("No"):
                            switch (text)
                            {
                                case ("1"):

                                MessageBox.Show("Введіть назву файла в поле");
                                inFunc = "First";
                                EnterVal.Text = "";
                                break;
                                case ("2"):
                                    MessageBox.Show("Введіть кількість демонів, або -1 для автоматичного свторення");
                                inFunc = "Second";
                                EnterVal.Text = "";
                                break;
                                case ("3"):
                                
                                    break;
                                case ("4"):

                                break;
                            case ("5"):
                                Deamon d1 = new Deamon(fileName, searchStr, numb);
                                //Thread t = new Thread();
                                //t.SetApartmentState(ApartmentState.STA);
                                //t.Start();
                                ThreadPool.QueueUserWorkItem(d1.Start);
                                inFunc = "No";
                                Log.Text += "\nНазва файлу:" + fileName;
                                Log.Text += "\nКількість демонів:" + numb;
                                Log.Text += "\n Пошук:" + searchStr;
                                break;
                            }
                     break;
                    case ("First"):
                        fileName = EnterVal.Text;
                        Log.Text += fileName;
                        EnterVal.Text = "";
                        inFunc = "No";
                        break;
                    case ("Second"):
                        if (Int32.TryParse(EnterVal.Text, out int a))
                        {
                            numb = a;
                            inFunc = "Str";
                            Log.Text += "\n" + numb;
                            EnterVal.Text = "";
                            MessageBox.Show("Введіть рядок для пошуку");
                        }
                        else
                        {
                            MessageBox.Show("Введіть кількість демонів");
                        }
                        break;
                    case ("Str"):
                        searchStr = EnterVal.Text;
                        EnterVal.Text = "";
                        Log.Text += "\n Пошук:" + searchStr;
                        Deamon d = new Deamon(fileName, searchStr, numb);

                        ThreadPool.QueueUserWorkItem(d.Start);
                        inFunc = "No";
                        break;
                }
            }
            EnterVal.Text = "";
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ENTER_Click( sender, e);
            }
        }
    }
    
}

