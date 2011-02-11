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
    /// Interaction logic for TableViewer.xaml
    /// </summary>
    public partial class TableViewer : Window
    {
        public TableViewer()
        {
            InitializeComponent();
        }
        public bool SetImage(string directory, string imageName)
        {
            Uri uriSource = new Uri(directory + "\\tables\\" + imageName);
            BitmapImage source = new BitmapImage();
            try
            {
                source.BeginInit();
                source.UriSource = uriSource;
                source.EndInit();
            }
            catch (Exception)
            {
                MessageBox.Show("No table file called: " + uriSource.OriginalString);
                return false;
            }
            
            this.Height = source.Height + 38;
            this.Width = source.Width + 17;
            image.Width = source.Width;
            image.Height = source.Height;
            image.Source = source;
            return true;
        }
    }
}
