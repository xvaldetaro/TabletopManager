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
    /// Interaction logic for newItem.xaml
    /// </summary>
    public partial class newItem : Window
    {
        public event EventHandler ItemChanged;
        private void OnItemChanged()
        {
            if (ItemChanged != null)
                ItemChanged(this, EventArgs.Empty);
        }
        public Item Item 
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
                grid1.DataContext = item;
                OnItemChanged();
            }
        }
        public bool gotItem;
        Item item;
        public newItem()
        {
            InitializeComponent();
            textBox1.Focus();
            gotItem = false;
            item = null;
        }

        private void AddNew(object sender, ExecutedRoutedEventArgs e)
        {
            item = new Item(textBox1.Text, App.getFloatFromString(textBox3.Text), App.getFloatFromString(textBox2.Text));
            if (!(bool)PoundsCheckBox.IsChecked)
            {
                item.WeightKilos = App.getFloatFromString(textBox2.Text);
            }
            gotItem = true;
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
