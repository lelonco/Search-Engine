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
using System.Windows.Shapes;

namespace Search_Engine
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public void CreateBox(int id)
        {

            TextBlock block = new TextBlock
            {
                 Name = "block" + id.ToString()
            };
            Block.Text = "block" + id;
        }
        public void ShowText(string currentStr)
        {
            //Block.Text += "\n" + currentStr;
            Block.AppendText("\n"+currentStr);
        }
    }

}
