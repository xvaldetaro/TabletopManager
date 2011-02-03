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
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : Window
    {
        string directory;
        public Table(string directory)
        {
            this.directory = directory;
            InitializeComponent();
        }
        #region TableViewer button events
        private void table_action_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "actions.jpg");
            window.Show();
        }
        private void table_track_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "track.jpg");
            window.Show();
        }

        private void table_adiSpells_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "additional_spells.jpg");
            window.Show();
        }

        private void table_comModifiers_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "combat_modifiers.JPG");
            window.Show();
        }

        private void table_donArmor_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "donning_armor.jpg");
            window.Show();
        }

        private void table_ligSources_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "light_sources.jpg");
            window.Show();
        }

        private void table_movement_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "movement.jpg");
            window.Show();
        }

        private void table_objects_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "objects_breaking.jpg");
            window.Show();
        }

        private void table_size_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "size_modifiers.jpg");
            window.Show();
        }

        private void table_balance_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "balance_bluff_climb.jpg");
            window.Show();
        }

        private void table_concentration_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "concentration_forgery.jpg");
            window.Show();
        }

        private void table_heal_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "heal-search.jpg");
            window.Show();
        }

        private void table_spellcraft_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "spellcraft-survival.jpg");
            window.Show();
        }

        private void table_tumble_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "tumble-use_rope.jpg");
            window.Show();
        }

        private void table_diseases_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "diseases.JPG");
            window.Show();
        }

        private void table_doors_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "doors.JPG");
            window.Show();
        }

        private void table_encounter_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "encounter_nd.JPG");
            window.Show();
        }

        private void table_npcTraits_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "npc_traits.JPG");
            window.Show();
        }

        private void table_poisons_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "poisons.JPG");
            window.Show();
        }

        private void table_ranDoors_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "random_doors.JPG");
            window.Show();
        }

        private void table_ranTraps_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "random_traps.JPG");
            window.Show();
        }

        private void table_walls_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "walls.JPG");
            window.Show();
        }

        private void table_xp_Click(object sender, RoutedEventArgs e)
        {
            TableViewer window = new TableViewer();
            window.SetImage(directory, "xp.jpg");
            window.Show();
        }
        #endregion
    }
}
