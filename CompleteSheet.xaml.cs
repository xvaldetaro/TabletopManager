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
    /// Interaction logic for CompleteSheet.xaml
    /// </summary>
    public partial class CompleteSheet : Window
    {
        Combatant combatant;
        public CompleteSheet(Combatant combatant)
        {
            InitializeComponent();
            this.combatant = combatant;
            grid1.DataContext = combatant;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NewListboxItem itemAdder = new NewListboxItem();
            itemAdder.ShowDialog();
            if (itemAdder.gotItem)
            {
                Combatant combatant = (Combatant)grid1.DataContext;
                combatant.Feats.Add(itemAdder.item);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Combatant combatant = (Combatant)grid1.DataContext;
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("No selected feat");
            else
                combatant.Feats.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            newItem itemAdder = new newItem();
            itemAdder.ShowDialog();
            if (itemAdder.gotItem)
            {
                Combatant combatant = (Combatant)grid1.DataContext;
                combatant.Items.Add(itemAdder.item);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Combatant combatant = (Combatant)grid1.DataContext;
            if (listBox2.SelectedIndex == -1)
                MessageBox.Show("No selected item");
            else
                combatant.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Combatant combatant = (Combatant)grid1.DataContext;
            combatant.setSkillRank(eSkills.Listen, combatant.getSkillRank(eSkills.Listen));
            Close();
        }
    }
}
