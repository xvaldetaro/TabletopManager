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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string InputValue { get { return inputValue; } }
        string inputValue;
        public Window2( string title )
        {
            InitializeComponent();
            this.Title = title;
            inputValueTextBox.Focus();
        }
        private void saveInputValue(object sender, ExecutedRoutedEventArgs e)
        {
            inputValue = this.inputValueTextBox.Text;
            this.Close();
        }
    }
}
