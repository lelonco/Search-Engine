using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;

namespace Search_Engine
{
   
    public partial class Deamon
    {
        
        public static int[] progress;
        public bool searchResult = false;
        public string[] src;
        public string searchStr;
        public int id;
        public int numb;
        public string fileName;
        public Deamon(string[] source, string searchStr)
        {
            this.searchStr = searchStr;
            this.src = new string[source.Length];
            //  Console.WriteLine($"Length:{src.Length}");
            Array.Copy(source, src, source.Length);

        }
        public Deamon(string[] source, string searchStr, int id)
        {

            this.searchStr = searchStr;
            this.id = id;
            this.src = new string[source.Length];
            // Console.WriteLine($"Length:{src.Length}");
            Array.Copy(source, src, source.Length);
        }
        public Deamon(string fileName, string searchStr, int numb)
        {
       
            this.fileName = fileName;
            this.searchStr = searchStr;
            this.numb = numb;
        }
        public void Print()
        {
            // Console.WriteLine("Source:{0}", src);
            //
            Console.WriteLine(format: "Номер демона{0} \n Слово для пошука {1}", arg0: id, arg1: searchStr);
        }
        public void Start(Object threadContext)
        {
        Application.Current.Dispatcher.Invoke((Action)delegate
        {
            string[] arrString = File.ReadAllLines(fileName, Encoding.Default);

            Create(numb, arrString, searchStr);
        });
        }
        public void Search(Object threadContext)
        {
         //   Application.Current.Dispatcher.Invoke((Action)delegate 
         //   {
                int threadIndex = (int)threadContext;
                Window1 w = new Window1();
                w.Show();
                // MessageBox.Show("Search");
                //AllocConsole();
                //Trace.WriteLine(@"Search: ");
                //Console.WriteLine($"Length in Search:{src.Length}");
                int counter = 0;
                if (searchResult)
                {
                    Console.WriteLine("Знайденно");
                    searchResult = true;

                    return;
                }
                else
                {
                    // searchResult = src.Contains(searchStr);
                    w.ShowText($"Thread nomber {threadIndex}");
                    for (int i = 0; i < src.Length; i++)
                    {
                        counter++;
                        w.ShowText(src[i]);
                        Console.WriteLine(src[i]);
                        if(src[i]==searchStr)
                        {
                            searchResult = true;
                           // w.Hide();

                        }
                        if (searchResult)
                        {
                            Console.WriteLine("Знайденно");
                            w.ShowText("Знайденно");
                           // w.Hide();
                            return;
                        }
                        if(i+1==src.Length)
                        {
                           // w.Hide();
                        }
                    }
                   
                    return;
                }

           // });

           
        }
       // [STAThread]
        public void Create(int numb, string[] src, string searchStr) 
        {
            
            Deamon[] d = new Deamon[numb];
            MessageBox.Show("Create");
            int nRow = 0;
            int addLastRow = 0;
            int indexStart = 0;
            nRow = src.Length / numb;
            addLastRow = (src.Length) - (nRow * numb);
            string[] temp = new string[addLastRow + nRow];
            for (int i = 0; i < numb; i++)
            {
                if ((i + 1) == numb)
                {
                    nRow += addLastRow;
                    Array.Copy(src, indexStart, temp, 0, nRow);
                   // Console.WriteLine($"Length Temp:{temp.Length}");
                    //d[i] = new Deamon(temp, searchStr, i);
                    Deamon de = new Deamon(temp, searchStr, i);
                    d[i] = de;
                    ThreadPool.QueueUserWorkItem(de.Search,i);
                    //Thread thred = new Thread(d[i].Search);
                    //  thred.Start();
                    // Console.WriteLine($"Кількість рядків у демона{i} :{ nRow}");
                }
                else
                {
                    Array.Copy(src, indexStart, temp, 0, nRow);
                    Deamon de = new Deamon(temp, searchStr, i);
                    d[i] = de;
                    ThreadPool.QueueUserWorkItem(de.Search, i);
                    //d[i] = new Deamon(temp, searchStr, i);
                    //Console.WriteLine($"Кількість рядків у демона{i} :{ nRow}");
                    //  Console.WriteLine(temp.Length);
                    //  d[i].Show();
                    //Thread thred = new Thread(d[i].Search);
                    //thred.Start();
                }
                Array.Clear(temp, 0, temp.Length);
                indexStart += nRow;
            }
        }
    }
}
