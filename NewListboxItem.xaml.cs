using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for NewListboxItem.xaml
    /// </summary>
    public partial class NewListboxItem : Window
    {
        public bool gotItem;
        public string item;
        public NewListboxItem()
        {
            InitializeComponent();
            textBox1.Focus();
            gotItem = false;
            item = null;
        }

        private void AddNew(object sender, ExecutedRoutedEventArgs e)
        {
            item = textBox1.Text;
            gotItem = true;
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
