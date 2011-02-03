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
using inibronx;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        SpellBook spellBook;
        ListBox[] listBoxes;
        Journal journal;
        SolidColorBrush black;
        SolidColorBrush silver;
        public Window2()
        {
            InitializeComponent();
            journal = new Journal(textBox1);
            black = new SolidColorBrush(Colors.Black);
            silver = new SolidColorBrush(Colors.Silver);
            listBoxes = new ListBox[10];
            listBoxes[0] = listBox1;
            listBoxes[1] = listBox2;
            listBoxes[2] = listBox3;
            listBoxes[3] = listBox4;
            listBoxes[4] = listBox5;
            listBoxes[5] = listBox6;
            listBoxes[6] = listBox7;
            listBoxes[7] = listBox8;
            listBoxes[8] = listBox9;
            listBoxes[9] = listBox10;
        }
        public void LoadSpellBook(string xmlFile, string bookTypeName)
        {
            BookType bookType;
            switch (bookTypeName)
	        {
                case "Cleric":
                    bookType = BookType.Cleric;
                    break;
                case "Wizard":
                    bookType = BookType.Wizard;
                    break;
                case "Sorcerer":
                    bookType = BookType.Sorcerer;
                    break;
		        default:
                    bookType = BookType.Cleric;
                    break;
	        }
            spellBook = new SpellBook(bookType);
            spellBook.LoadKnownFromXml(xmlFile);
            FillListBoxes();
        }
        private void FillListBoxes()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < spellBook.lvl[i].Count; j++)
                {
                    System.Windows.Controls.ListBoxItem listBoxItem = new ListBoxItem();
                    listBoxItem.Content = spellBook.lvl[i][j].name;
                    listBoxItem.Tag = spellBook.lvl[i][j];
                    listBoxItem.MouseDoubleClick += new MouseButtonEventHandler(listBoxItem_MouseDoubleClick);
                    listBoxItem.GotFocus +=new RoutedEventHandler(listBoxItem_GotFocus);
                    listBoxes[i].Items.Add(listBoxItem);
                }

            }
        }
        private void listBoxItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)sender;
            //listBoxItem.Background = new SolidColorBrush(Colors.Silver);
            if (listBoxItem.Foreground == silver)
            {
                listBoxItem.Foreground = black;
            }
            else
            {
                listBoxItem.Foreground = silver;
            }
        }
        private void listBoxItem_GotFocus(object sender, RoutedEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)sender;
            Spell spell = (Spell)listBoxItem.Tag;
            journal.ClearJournal();
            journal.Update(spell.name);
            journal.Update("School: " + spell.school);
            journal.Update("Range: " + spell.range);
            journal.Update("Duration: " + spell.duration);
            journal.Update("Description: " + spell.description);
        }
    }
}
