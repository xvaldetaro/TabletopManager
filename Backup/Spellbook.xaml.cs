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
using System.Collections.ObjectModel;

namespace WpfApplication1
{
    

    public partial class Spellbook : Window
    {
        SpellbookLevel[] spellbookLevels;
        TextBlock[] lvlLabels;
        SpellbookLevel selectedLevel;
        string spellcaster;

        public Spellbook(string directory, int firstLevel, int lastLevel, string spellcaster)
        {
            this.spellcaster = spellcaster;

            InitializeComponent();
            lvlLabels = new TextBlock[10];
            lvlLabels[0] = textBlock1;
            lvlLabels[1] = textBlock2;
            lvlLabels[2] = textBlock3;
            lvlLabels[3] = textBlock4;
            lvlLabels[4] = textBlock5;
            lvlLabels[5] = textBlock6;
            lvlLabels[6] = textBlock7;
            lvlLabels[7] = textBlock8;
            lvlLabels[8] = textBlock9;
            lvlLabels[9] = textBlock10;

            spellbookLevels = new SpellbookLevel[10];
            for (int i = firstLevel; i <= lastLevel; i++)
            {
                System.IO.StreamReader SR;
                try
                {
                    SR = System.IO.File.OpenText(directory + "\\spells\\" + spellcaster + "\\" + i.ToString() + ".txt");
                    spellbookLevels[i] = new SpellbookLevel(SR.ReadToEnd());
                }
                catch 
                {
                    spellbookLevels[i] = new SpellbookLevel("");
                }
                    
                    lvlLabels[i].DataContext = spellbookLevels[i];
               
            }
            spellbookLevels[firstLevel].Selected = true;
            selectedLevel = spellbookLevels[firstLevel];
            allSpells.DataContext = selectedLevel;
            preparedSpells.DataContext = selectedLevel;
        }

        private void textBlock10_GotFocus(object sender, MouseButtonEventArgs e)
        {
            TextBlock senderBlock = (TextBlock)sender;
            if (selectedLevel != null)
                selectedLevel.Selected = false;
         
            selectedLevel = spellbookLevels[(int)App.getFloatFromString(senderBlock.Text)];
            selectedLevel.Selected = true;
            allSpells.DataContext = selectedLevel;
            preparedSpells.DataContext = selectedLevel;
        }

        private void RandomizeBook_Click(object sender, RoutedEventArgs e)
        {
            int casterLevel = (int)App.getFloatFromString(casterLevelBox.Text);
            for (int i = 0; i < spellbookLevels.Count(); i++)
            {
                int maxLevel = ((casterLevel+1)/2);
                if (i <= maxLevel)
                    spellbookLevels[i].RandomizeSpellBook(Math.Min(2 + maxLevel - i + ((casterLevel + 1) % 2), 5));
            }
        }


    }
    public class SpellbookLevel
    {
        bool selected = false;
        ObservableCollection<Spell> allSpells;
        ObservableCollection<Spell> casterSpells;

        public SpellbookLevel(string levelText)
        {
            allSpells = new ObservableCollection<Spell>();
            casterSpells = new ObservableCollection<Spell>();
            string[] schools = levelText.Split('#');

            foreach (string school in schools)
            {
                string[] spellsFromSchool = school.Split('!');
                for (int i = 1; i < spellsFromSchool.Count(); i++)
                {
                    string[] spellSegments = spellsFromSchool[i].Split(':');
                    Spell spell = new Spell();
                    spell.spellName = spellSegments[0];
                    spell.spellSchool = spellsFromSchool[0];
                    allSpells.Add(spell);
                }
            }
        }
        public void RandomizeSpellBook(int numSpells)
        {
            casterSpells.Clear();
            if (allSpells.Count > 0)
            {
                Random random = new Random();
                for (int i = 0; i < numSpells; i++)
                {
                    int randomSpellIndex = random.Next(0, allSpells.Count);
                    casterSpells.Add(allSpells[randomSpellIndex]);
                }
            }
        }

        public event EventHandler BackgroundColorChanged;
        private void OnBackgroundColorChanged()
        {
            if (BackgroundColorChanged != null)
                BackgroundColorChanged(this, EventArgs.Empty);
        }
        public event EventHandler SelectedChanged;
        private void OnSelectedChanged()
        {
            if (SelectedChanged != null)
                SelectedChanged(this, EventArgs.Empty);
        }
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnSelectedChanged();
                OnBackgroundColorChanged();
            }
        }
        public string BackgroundColor
        {
            get
            {
                if (Selected)
                    return "AntiqueWhite";
                else
                    return "White";
            }
        }
        public ObservableCollection<Spell> AllSpells
        {
            get
            {
                return allSpells;
            }
        }
        public ObservableCollection<Spell> CasterSpells
        {
            get
            {
                return casterSpells;
            }
        }
    }
    public struct Spell
    {
        public string spellName;
        public string spellLevel;
        public string spellDescription;
        public string spellSchool;
        public override string ToString()
        {
            return spellName;
        }
    }
    public enum Schools
    {
        Abjuration = 0,
        Conjuration = 1,
        Divination = 2,
        Enchantment = 3,
        Evocation = 4,
        Illusion = 5,
        Necromancy = 6,
        Transmutation = 7,
        Universal = 8
    }
}
