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
    /// Interaction logic for InitiativeSet.xaml
    /// </summary>
    public partial class InitiativeSet : Window
    {
        CombatTable table;
        public InitiativeSet(CombatTable table)
        {
            InitializeComponent();
            this.table = table;
            listBox1.DataContext = table;
            listBox1.SelectedItem = table[0];
            initBox.Focus();
        }

        private void SetThisInitiative(object sender, ExecutedRoutedEventArgs e)
        {
            float initiative = App.getFloatFromString(initBox.Text);
            Combatant selectedCombatant = (Combatant)listBox1.SelectedItem;
            CommUpdateCombatant commUpdt = new CommUpdateCombatant(selectedCombatant, CombatantAttributes.initiative, initiative);
            commUpdt.Execute();

            int indexOfSelected = table.IndexOf(selectedCombatant);
            if (indexOfSelected < table.Count - 1)
            {
                listBox1.SelectedItem = table[indexOfSelected + 1];
                initBox.Text = "";
            }
            else
            {
                this.Close();
            }
            
        }
    }
}
