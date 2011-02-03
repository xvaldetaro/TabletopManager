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
    /// Interaction logic for NewCombatant.xaml
    /// </summary>
    public partial class NewCombatant : Window
    {
        CombatTable combatants;
        Combatant combatant;
        bool editing;
        public NewCombatant( CombatTable combatants )
        {
            editing = false;
            this.combatants = combatants;
            InitializeComponent();
            textBlock15.Focus();
            combatant = null;
        }

        private void AddNewCombatant(object sender, ExecutedRoutedEventArgs e)
        {
            Combatant newCombatant = new Combatant(textBlock15.Text, "", textBlock21.Text, textBlock22.Text,
                    textBlock19.Text, textBlock20.Text, textBlock21.Text, textBlock22.Text, textBlock23.Text,
                    textBlock26.Text, textBlock27.Text, textBlock28.Text, textBox1.Text, textBox2.Text, (bool)isNPC.IsChecked);
    
            if (combatant == null)
            {
                CommAddCombatant addComm = new CommAddCombatant(combatants, newCombatant);
                addComm.Execute();
            }
            else
            {
                int index = combatants.IndexOf(combatant);
               
                CommRemoveCombatant commRmv = new CommRemoveCombatant(combatants, combatant);
                commRmv.Execute();
                CommAddCombatant addComm = new CommAddCombatant(combatants, newCombatant);
                addComm.Execute();
                CommRepositionCombatant commRepos = new CommRepositionCombatant(combatants, newCombatant, index - combatants.Count);
                commRepos.Execute();
            }
            

            this.Close();
        }
    }
}
