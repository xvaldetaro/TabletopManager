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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        CombatTable listi;
        string loadedFile;
        string loadedFileDir;
        string execDirectory;
        public Window1()
        {
            InitializeComponent();
            listi = new CombatTable();
            listBox1.DataContext = listi;
            execDirectory = Environment.CurrentDirectory;
        }
        private void Undo(object sender, ExecutedRoutedEventArgs e)
        {
            UndoableCommand.Undo();
        }

        private void Redo(object sender, ExecutedRoutedEventArgs e)
        {
            UndoableCommand.Redo();
        }
        #region CombatTable Edition Methods
        private Combatant getSelectedCombatant()
        {
            Combatant combatant = (Combatant)listBox1.SelectedItem;
            if (combatant == null)
            {
                MessageBox.Show("Select a Character", "Invalid Character", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return combatant;
        }

        private void AddNewCombatant(object sender, ExecutedRoutedEventArgs e)
        {       
            NewCombatant windowNew = new NewCombatant( listi );
            windowNew.ShowDialog();
        }
        private void cloneSelectedCombatant_Click(object sender, RoutedEventArgs e)
        {
            Combatant selectedCombatant = getSelectedCombatant();
            if (selectedCombatant == null)
                return;

            Combatant clone = selectedCombatant.Clone();
            CommAddCombatant commAdd = new CommAddCombatant(listi, clone);
            commAdd.Execute();
        }
        private void RemoveSelectedCombatant(object sender, ExecutedRoutedEventArgs e)
        {
            Combatant toBeRemovedCombatant = getSelectedCombatant();
            if (toBeRemovedCombatant != null)
            {
                CommRemoveCombatant commRmv = new CommRemoveCombatant(listi, toBeRemovedCombatant);
                commRmv.Execute();
            }
        }

        private void MoveCombatantUp(object sender, RoutedEventArgs e)
        {
            Combatant toBeShiftedCombatant = getSelectedCombatant();
            if (toBeShiftedCombatant != null)
            {
                CommRepositionCombatant commRmv = new CommRepositionCombatant(listi, toBeShiftedCombatant, -1);
                commRmv.Execute();
            }
        }

        private void MoveCombatantDown(object sender, RoutedEventArgs e)
        {
            Combatant toBeShiftedCombatant = getSelectedCombatant();
            if (toBeShiftedCombatant != null)
            {
                CommRepositionCombatant commRmv = new CommRepositionCombatant(listi, toBeShiftedCombatant, 1);
                commRmv.Execute();
            }
        }

        private void damageHeal_Click(object sender, RoutedEventArgs e)
        {
            float lifeAmount = App.getFloatFromString(damageHealBox.Text);
            if (lifeAmount != 0)
            {
                Combatant toBeDamagedCombatant = getSelectedCombatant();
                if (toBeDamagedCombatant == null)
                    return;
                float previousHP = toBeDamagedCombatant.HP;
                CommUpdateCombatant commUpdt = new CommUpdateCombatant(toBeDamagedCombatant, CombatantAttributes.hp, previousHP - lifeAmount);
                commUpdt.Execute();
            }
        }
        #endregion

        #region quick damage/heal buttons
        private void applyDamage(float damageAmount)
        {
            Combatant toBeDamagedCombatant = getSelectedCombatant();
            if (toBeDamagedCombatant == null)
                return;
            float previousHP = toBeDamagedCombatant.HP;
            CommUpdateCombatant commUpdt = new CommUpdateCombatant(toBeDamagedCombatant, CombatantAttributes.hp, previousHP + damageAmount);
            commUpdt.Execute();
        }
        private void plus1Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(1);
        }

        private void plus3Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(3);
        }

        private void plus5Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(5);
        }

        private void plus10Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(10);
        }

        private void minus1Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(-1);
        }

        private void minus2Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(-3);
        }

        private void minus5Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(-5);
        }

        private void minus10Dmg_Click(object sender, RoutedEventArgs e)
        {
            applyDamage(-10);
        }
        #endregion

        #region Combat management methods
        private void setInitiativeButton_Click(object sender, RoutedEventArgs e)
        {
            InitiativeSet initWindow = new InitiativeSet(listi);
            initWindow.ShowDialog();
        }

        private void restoreAllHP_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listi.Count; i++)
            {
                Combatant toBeRestoredCombatant = listi[i];
                float maxHP = toBeRestoredCombatant.MaxHP;
                CommUpdateCombatant commUpdt = new CommUpdateCombatant(toBeRestoredCombatant, CombatantAttributes.hp, maxHP);
                commUpdt.Execute();
            }
        }

        private void restoreSelectedHp_Click(object sender, RoutedEventArgs e)
        {
            Combatant toBeRestoredCombatant = getSelectedCombatant();
            if (toBeRestoredCombatant == null)
                return;
            float maxHP = toBeRestoredCombatant.MaxHP;
            CommUpdateCombatant commUpdt = new CommUpdateCombatant(toBeRestoredCombatant, CombatantAttributes.hp, maxHP);
            commUpdt.Execute();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            float newInititive = App.getFloatFromString(initiativeBox.Text);
            if (newInititive != 0)
            {
                Combatant newInitiativeCombatant = getSelectedCombatant();
                if (newInitiativeCombatant == null)
                    return;
                float previousHP = newInitiativeCombatant.HP;
                CommUpdateCombatant commUpdt = new CommUpdateCombatant(newInitiativeCombatant, CombatantAttributes.initiative, newInititive);
                commUpdt.Execute();
            }
        }

        private void editCombatant_Click(object sender, RoutedEventArgs e)
        {
            Combatant combatant = getSelectedCombatant();
            if (combatant != null)
            {
                CompleteSheet completeSheet = new CompleteSheet(getSelectedCombatant());
                completeSheet.ShowDialog();
            }
        }
        private void orderByInit_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Combatant> sortedCombatants =
            from combatant in listi
            orderby -combatant.Initiative
            select combatant;

            int count = listi.Count;
            for (int i = 0; i < count; i++)
            {
                Combatant combatant = sortedCombatants.ElementAt(i);
                int index = listi.IndexOf(combatant);
                CommRepositionCombatant commRps = new CommRepositionCombatant(listi, combatant, i - index);
                commRps.Execute();
            }

        }

        private void restoreNPCHP_Click(object sender, RoutedEventArgs e)
        {
            List<UndoableCommand> commList = new List<UndoableCommand>();
            for (int i = 0; i < listi.Count; i++)
            {
                Combatant toBeRestoredCombatant = listi[i];
                
                if (toBeRestoredCombatant.IsNPC)
                {
                    float maxHP = toBeRestoredCombatant.MaxHP;
                    CommUpdateCombatant commUpdt = new CommUpdateCombatant(toBeRestoredCombatant, CombatantAttributes.hp, maxHP);
                    commList.Add(commUpdt);
                }
                
            }
            if (commList.Count > 0)
            {
                CommCommandPackStarter commPack = new CommCommandPackStarter(commList);
                commPack.Execute();
            }
        }

        private void rollNPCInit_Click(object sender, RoutedEventArgs e)
        {
            List<UndoableCommand> commList = new List<UndoableCommand>();
            Random random = new Random();
            for (int i = 0; i < listi.Count; i++)
            {
                Combatant rollInitCombatant = listi[i];
                if (rollInitCombatant.IsNPC)
                {
                    float initiative = rollInitCombatant.InitMod + random.Next(1, 21);
                    CommUpdateCombatant commUpdt = new CommUpdateCombatant(rollInitCombatant, CombatantAttributes.initiative, initiative);
                    commList.Add(commUpdt);
                }
                
            }
            if (commList.Count > 0)
            {
                CommCommandPackStarter commPack = new CommCommandPackStarter(commList);
                commPack.Execute();
            }

        }

        private void clearDead_Click(object sender, RoutedEventArgs e)
        {
            int count = listi.Count;
            List<Combatant> toBeRemoved = new List<Combatant>();

            for (int i = 0; i < count; i++)
            {
                Combatant combatant = listi[i];
                if (combatant.HP < 0)
                {
                    toBeRemoved.Add(combatant);
                }
            }
            foreach (Combatant exCombatant in toBeRemoved)
            {
                CommRemoveCombatant commRmv = new CommRemoveCombatant(listi, exCombatant);
                commRmv.Execute();
            }
        }

        private void clearNPC_Click(object sender, RoutedEventArgs e)
        {
            int count = listi.Count;
            List<Combatant> toBeRemoved = new List<Combatant>();

            for (int i = 0; i < count; i++)
            {
                Combatant combatant = listi[i];
                if (combatant.IsNPC)
                {
                    toBeRemoved.Add(combatant);
                }
            }
            foreach (Combatant exCombatant in toBeRemoved)
            {
                CommRemoveCombatant commRmv = new CommRemoveCombatant(listi, exCombatant);
                commRmv.Execute();
            }
        }

        private void startEncounter_Click(object sender, RoutedEventArgs e)
        {
            CommStartEncounter commStrt = new CommStartEncounter(listi);
            commStrt.Execute();
        }

        private void stopCombat_Click(object sender, RoutedEventArgs e)
        {
            CommFinishEncounter commFnsh = new CommFinishEncounter(listi);
            commFnsh.Execute();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            CommNextCombatant commNxt = new CommNextCombatant(listi);
            commNxt.Execute();
        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {
            CommPreviousCombatant commPrvs = new CommPreviousCombatant(listi);
            commPrvs.Execute();
        }
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            CommClearCombatTable commClr = new CommClearCombatTable(listi);
            commClr.Execute();
        }
        #endregion

        #region IO methods
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                Nullable<bool> result = ofd.ShowDialog();
                string temps;
                if (result == true)
                {

                    temps = ofd.FileName;
                }
                else
                    return;

                this.loadedFile = temps;
                this.loadedFileDir = Environment.CurrentDirectory;
                CommClearCombatTable commClr = new CommClearCombatTable(listi);
                commClr.Execute();

                this.Title = "TableTop Manager" + temps;
                System.IO.StreamReader SR;
                SR = System.IO.File.OpenText(temps);
                String combatantString = SR.ReadToEnd();
                JsonExporter.combatTableFromJsonFile(listi, combatantString);
            }
            catch
            {
                MessageBox.Show("Invalid File");
            }
        }

        private void Include_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = ofd.ShowDialog();
            string temps;
            if (result == true)
            {
                
                temps = ofd.FileName;
            }
            else
                return;

            System.IO.StreamReader SR;
            SR = System.IO.File.OpenText(temps);
            String combatantString = SR.ReadToEnd();
            JsonExporter.combatTableFromJsonFile(listi, combatantString);
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "tm1";
            Nullable<bool> result = ofd.ShowDialog();
            string temps;
            if (result == true)
            {
                temps = ofd.FileName;
            }
            else
                return;

            this.loadedFile = temps;
            this.loadedFileDir = Environment.CurrentDirectory;
            System.IO.StreamWriter SW = System.IO.File.CreateText(temps);

            SW.WriteLine(JsonExporter.jsonFileFromCombatTable(listi));
            SW.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (loadedFile == null)
            {
                MessageBox.Show("invalid file: " + loadedFile);
                return;
            }
            System.IO.StreamWriter SW = System.IO.File.CreateText(this.loadedFile);
            SW.WriteLine(JsonExporter.jsonFileFromCombatTable(listi));
            SW.Close();
        }

        private void exportCharacter_Click(object sender, RoutedEventArgs e)
        {
            Combatant selectedCombatant = getSelectedCombatant();
            if (selectedCombatant == null)
                return;

            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "tm1";
            Nullable<bool> result = ofd.ShowDialog();
            string temps;
            if (result == true)
            {
                temps = ofd.FileName;
            }
            else
                return;

            System.IO.StreamWriter SW = System.IO.File.CreateText(temps);

            SW.WriteLine(JsonExporter.jsonFileFromCombatant(selectedCombatant));

            SW.Close();
        }

        private void exportAll_Click(object sender, RoutedEventArgs e)
        {
            if (loadedFile == null)
            {
                MessageBox.Show("invalid file: " + loadedFile);
                return;
            }
            string directoryToExport = this.loadedFileDir + "\\exported\\";
            System.IO.Directory.CreateDirectory(directoryToExport);

            foreach (Combatant combatant in listi)
            {
                string combatantFilePath = directoryToExport + combatant.CName + ".tm1";

                System.IO.StreamWriter SW = System.IO.File.CreateText(combatantFilePath);

                SW.WriteLine(JsonExporter.jsonFileFromCombatant(combatant));
                SW.Close();
            }
        }
        #endregion

        #region Dice Roll Button events
        private void d2_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 3));
        }
        private void d4_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 5));
        }
        private void d6_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 7));
        }
        private void d8_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 9));
        }
        private void d10_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 11));
        }
        private void d12_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 13));
        }
        private void d20_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 21));
        }
        private void d100_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            resultBox.Text = System.Convert.ToString(random.Next(1, 101));
        }
        #endregion

        #region Gold XP SpellBook and Roll Check
        private void GiveGold_Click(object sender, RoutedEventArgs e)
        {
            List<UndoableCommand> commList = new List<UndoableCommand>();
            int numPCs = 0;
            for (int i = 0; i < listi.Count; i++)
            {
                if (!listi[i].IsNPC)
                {
                    numPCs++;
                }
            }
            float goldShare = App.getFloatFromString(giveBox.Text) / (float)numPCs;
            for (int i = 0; i < listi.Count; i++)
            {
                if (!listi[i].IsNPC)
                {
                    float gold = listi[i].Gold + goldShare;
                    CommUpdateCombatant commUpdt = new CommUpdateCombatant(listi[i], CombatantAttributes.gold, gold);
                    commList.Add(commUpdt);
                }

            }
            if (commList.Count > 0)
            {
                CommCommandPackStarter commPack = new CommCommandPackStarter(commList);
                commPack.Execute();
            }
        }

        private void GiveXP_Click(object sender, RoutedEventArgs e)
        {
            List<UndoableCommand> commList = new List<UndoableCommand>();
            int numPCs = 0;
            for (int i = 0; i < listi.Count; i++)
            {
                if (!listi[i].IsNPC)
                {
                    numPCs++;
                }
            }
            float xpShare = App.getFloatFromString(giveBox.Text) / (float)numPCs;
            for (int i = 0; i < listi.Count; i++)
            {
                if (!listi[i].IsNPC)
                {
                    float xp = listi[i].XP + xpShare;
                    CommUpdateCombatant commUpdt = new CommUpdateCombatant(listi[i], CombatantAttributes.xp, xp);
                    commList.Add(commUpdt);
                }

            }
            if (commList.Count > 0)
            {
                CommCommandPackStarter commPack = new CommCommandPackStarter(commList);
                commPack.Execute();
            }
        }
        private void rollCheck_Click(object sender, RoutedEventArgs e)
        {
            Random randomizer = new Random();

            string menuItemHeader = (string)((MenuItem)sender).Header;
            string msg = "Results:\n";
            foreach (Combatant combatant in listi)
            {
                if (menuItemHeader == "Fortitude")
                {
                    msg = msg + combatant.CName + " = " + System.Convert.ToString(combatant.Fort + randomizer.Next(1, 21)) + "\n";
                }
                else if (menuItemHeader == "Reflex")
                {
                    msg = msg + combatant.CName + " = " + System.Convert.ToString(combatant.Refl + randomizer.Next(1, 21)) + "\n";
                }
                else if (menuItemHeader == "Will")
                {
                    msg = msg + combatant.CName + " = " + System.Convert.ToString(combatant.Will + randomizer.Next(1, 21)) + "\n";
                }
                else if (menuItemHeader == "Spot")
                {
                    msg = msg + combatant.CName + " = " + System.Convert.ToString(combatant.Spot + randomizer.Next(1, 21)) + "\n";
                }
                else if (menuItemHeader == "Sense Motive")
                {
                    msg = msg + combatant.CName + " = " + System.Convert.ToString(combatant.Sense + randomizer.Next(1, 21)) + "\n";
                }
                else
                {
                    msg = msg + combatant.CName + " = " + System.Convert.ToString(combatant.Listen + randomizer.Next(1, 21)) + "\n";
                }
            }
            string title = "Rolls Results";
            MessageBox.Show(msg, title);
        }

        private void Gold_Click(object sender, RoutedEventArgs e)
        {
            float goldAmount = App.getFloatFromString(damageHealBox.Text);
            if (goldAmount != 0)
            {
                Combatant toBeGoldedCombatant = getSelectedCombatant();
                if (toBeGoldedCombatant == null)
                    return;
                float previousGold = toBeGoldedCombatant.Gold;
                CommUpdateCombatant commUpdt = new CommUpdateCombatant(toBeGoldedCombatant, CombatantAttributes.gold, previousGold + goldAmount);
                commUpdt.Execute();
            }
        }

        private void XP_Click(object sender, RoutedEventArgs e)
        {
            float xpAmount = App.getFloatFromString(damageHealBox.Text);
            if (xpAmount != 0)
            {
                Combatant toBexpedCombatant = getSelectedCombatant();
                if (toBexpedCombatant == null)
                    return;
                float previousxp = toBexpedCombatant.XP;
                CommUpdateCombatant commUpdt = new CommUpdateCombatant(toBexpedCombatant, CombatantAttributes.xp, previousxp + xpAmount);
                commUpdt.Execute();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Table table = new Table(execDirectory);
            table.Show();
        }

        private void randomSpellbook_Click(object sender, RoutedEventArgs e)
        {
            Spellbook window = new Spellbook(execDirectory, 0, 9, spellcasterBox.Text);
            window.Show();
        }
        #endregion

        private void StackPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            newItem itemAdder = new newItem();
            Combatant combatant = (Combatant)quickSheet.DataContext;
            itemAdder.Item = combatant.Items[itemListBox.SelectedIndex];
            itemAdder.ShowDialog();
        }

        private void newItemButton_Click(object sender, RoutedEventArgs e)
        {
            newItem itemAdder = new newItem();
            itemAdder.ShowDialog();
            if (itemAdder.gotItem)
            {
                Combatant combatant = (Combatant)quickSheet.DataContext;
                combatant.addItem(itemAdder.Item);
            }
        }

        private void removeItemButton_Click(object sender, RoutedEventArgs e)
        {
            Combatant combatant = (Combatant)quickSheet.DataContext;
            if (itemListBox.SelectedIndex == -1)
                MessageBox.Show("No selected item");
            else
                combatant.removeItem(itemListBox.SelectedIndex);
        }

        private void combatantRow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            quickSheet.DataContext = getSelectedCombatant();
        }
    }
    


    
}
