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
using aprimorando;

namespace inibronx
{
    /// <summary>
    /// Interaction logic for ConditionWindow.xaml
    /// </summary>
    public partial class ConditionWindow : Window
    {
        Character character;
        Journal journal;
        public ConditionWindow(Character character, Journal journal)
        {
            InitializeComponent();
            this.journal = journal;
            this.character = character;
            textBlock2.Text = character.nome + textBlock2.Text;
            if (character.conditions.Count > 0)
            {
                foreach (TempCondition tempCondition in character.conditions)
                {
                    ListBoxItem menuItem = new ListBoxItem();
                    menuItem.Content = tempCondition.changeValue.ToString()+ " " + tempCondition.name;
                    menuItem.Tag = tempCondition;
                    comboBox1.Items.Add(menuItem);
                }
            }
            for(int i = 0; i < 19 ; i++)
            {
                ListBoxItem menuItem = new ListBoxItem();
                menuItem.Content = System.Enum.GetName(typeof(ConditionType), i);
                menuItem.Tag = i;
                comboBox2.Items.Add(menuItem);
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem menuItem = (ListBoxItem)comboBox2.SelectedItem;
            TempCondition tempCondition = character.NewCondition((ConditionType)menuItem.Tag, System.Convert.ToInt32(textBox1.Text), System.Convert.ToInt32(textBox2.Text));
            journal.Update(String.Format("{0} {1} condition applied to {2} for {3} rounds",
                tempCondition.changeValue.ToString(), tempCondition.name, this.character.nome, tempCondition.duration.ToString())); 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem menuItem = (ListBoxItem)comboBox1.SelectedItem;
            TempCondition tempCondition = (TempCondition)menuItem.Tag;
            journal.Update(String.Format("{0} {1} condition removed from {2}",
                tempCondition.changeValue.ToString(), tempCondition.name, this.character.nome, tempCondition.duration.ToString())); 
            
            tempCondition.changeValue = tempCondition.changeValue * (-1);
            tempCondition.ApplyEffects();
            character.conditions.Remove(tempCondition);
        }
    }
}
