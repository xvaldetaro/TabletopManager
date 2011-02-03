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
using inibronx;
using WpfApplication1;

namespace aprimorando
{    
        public struct sheet
        {
            public TextBox names;
            public TextBox inits;
            public TextBox hP;
            public TextBox initMod;
            public TextBox maxHP;
            public TextBox fort;
            public TextBox refl;
            public TextBox will;
            public TextBox ab;
            public TextBox ranged;
            public TextBox ac;
            public TextBox spot;
            public TextBox listen;
            public TextBox sense;
            public TextBox cr;
            public TextBox xp;
            public CheckBox pC;

        }
        public partial class Window1 : Window
        {
            #region declarations
            public Character[] characters;
            public sheet[] sheets;
            public bool[] exists;
            public int turn;
            public int current;
            public ContextMenu meleeContextMenu;
            public ContextMenu rangedContextMenu;
            public ContextMenu conditionsContextMenu;
            public int contextMenuParent;
            public Journal journal;
            string directory;
            string lastSavedFile;
            string lastIncludedFile;
            #endregion

            public Window1()
            {
                InitializeComponent();
                directory = Environment.CurrentDirectory;
                characters = new Character[16];
                for (int i = 0; i < 16; i++)
                    characters[i] = new Character();
                sheets = new sheet[16];
                exists = new bool[16];
                journal = new Journal(journalTextBox);
                meleeContextMenu = new ContextMenu();
                rangedContextMenu = new ContextMenu();
                conditionsContextMenu = new ContextMenu();
                MenuItem menuItem = new MenuItem();
                menuItem.Header = "ApplyCondition";
                conditionsContextMenu.Items.Add(menuItem);
                menuItem.Click += new RoutedEventHandler(conditionMenuItem_Click);
                #region referencing all the TextBoxes
                sheets[0].names = textBox1;
                sheets[1].names = textBox2;
                sheets[2].names = textBox3;
                sheets[3].names = textBox4;
                sheets[4].names = textBox5;
                sheets[5].names = textBox6;
                sheets[6].names = textBox7;
                sheets[7].names = textBox8;
                sheets[8].names = textBox9;
                sheets[9].names = textBox10;
                sheets[10].names = textBox11;
                sheets[11].names = textBox12;
                sheets[12].names = textBox13;
                sheets[13].names = textBox14;
                sheets[14].names = textBox15;
                sheets[15].names = textBox16;

                sheets[0].inits = init1;
                sheets[1].inits = init2;
                sheets[2].inits = init3;
                sheets[3].inits = init4;
                sheets[4].inits = init5;
                sheets[5].inits = init6;
                sheets[6].inits = init7;
                sheets[7].inits = init8;
                sheets[8].inits = init9;
                sheets[9].inits = init10;
                sheets[10].inits = init11;
                sheets[11].inits = init12;
                sheets[12].inits = init13;
                sheets[13].inits = init14;
                sheets[14].inits = init15;
                sheets[15].inits = init16;

                sheets[0].hP = hp1;
                sheets[1].hP = hp2;
                sheets[2].hP = hp3;
                sheets[3].hP = hp4;
                sheets[4].hP = hp5;
                sheets[5].hP = hp6;
                sheets[6].hP = hp7;
                sheets[7].hP = hp8;
                sheets[8].hP = hp9;
                sheets[9].hP = hp10;
                sheets[10].hP = hp11;
                sheets[11].hP = hp12;
                sheets[12].hP = hp13;
                sheets[13].hP = hp14;
                sheets[14].hP = hp15;
                sheets[15].hP = hp16;

                sheets[0].initMod = initMod1;
                sheets[1].initMod = initMod2;
                sheets[2].initMod = initMod3;
                sheets[3].initMod = initMod4;
                sheets[4].initMod = initMod5;
                sheets[5].initMod = initMod6;
                sheets[6].initMod = initMod7;
                sheets[7].initMod = initMod8;
                sheets[8].initMod = initMod9;
                sheets[9].initMod = initMod10;
                sheets[10].initMod = initMod11;
                sheets[11].initMod = initMod12;
                sheets[12].initMod = initMod13;
                sheets[13].initMod = initMod14;
                sheets[14].initMod = initMod15;
                sheets[15].initMod = initMod16;

                sheets[0].maxHP = maxHP1;
                sheets[1].maxHP = maxHP2;
                sheets[2].maxHP = maxHP3;
                sheets[3].maxHP = maxHP4;
                sheets[4].maxHP = maxHP5;
                sheets[5].maxHP = maxHP6;
                sheets[6].maxHP = maxHP7;
                sheets[7].maxHP = maxHP8;
                sheets[8].maxHP = maxHP9;
                sheets[9].maxHP = maxHP10;
                sheets[10].maxHP = maxHP11;
                sheets[11].maxHP = maxHP12;
                sheets[12].maxHP = maxHP13;
                sheets[13].maxHP = maxHP14;
                sheets[14].maxHP = maxHP15;
                sheets[15].maxHP = maxHP16;

                sheets[0].fort = fort1;
                sheets[1].fort = fort2;
                sheets[2].fort = fort3;
                sheets[3].fort = fort4;
                sheets[4].fort = fort5;
                sheets[5].fort = fort6;
                sheets[6].fort = fort7;
                sheets[7].fort = fort8;
                sheets[8].fort = fort9;
                sheets[9].fort = fort10;
                sheets[10].fort = fort11;
                sheets[11].fort = fort12;
                sheets[12].fort = fort13;
                sheets[13].fort = fort14;
                sheets[14].fort = fort15;
                sheets[15].fort = fort16;

                sheets[0].refl = ref1;
                sheets[1].refl = ref2;
                sheets[2].refl = ref3;
                sheets[3].refl = ref4;
                sheets[4].refl = ref5;
                sheets[5].refl = ref6;
                sheets[6].refl = ref7;
                sheets[7].refl = ref8;
                sheets[8].refl = ref9;
                sheets[9].refl = ref10;
                sheets[10].refl = ref11;
                sheets[11].refl = ref12;
                sheets[12].refl = ref13;
                sheets[13].refl = ref14;
                sheets[14].refl = ref15;
                sheets[15].refl = ref16;

                sheets[0].will = will1;
                sheets[1].will = will2;
                sheets[2].will = will3;
                sheets[3].will = will4;
                sheets[4].will = will5;
                sheets[5].will = will6;
                sheets[6].will = will7;
                sheets[7].will = will8;
                sheets[8].will = will9;
                sheets[9].will = will10;
                sheets[10].will = will11;
                sheets[11].will = will12;
                sheets[12].will = will13;
                sheets[13].will = will14;
                sheets[14].will = will15;
                sheets[15].will = will16;

                sheets[0].ac = ac1;
                sheets[1].ac = ac2;
                sheets[2].ac = ac3;
                sheets[3].ac = ac4;
                sheets[4].ac = ac5;
                sheets[5].ac = ac6;
                sheets[6].ac = ac7;
                sheets[7].ac = ac8;
                sheets[8].ac = ac9;
                sheets[9].ac = ac10;
                sheets[10].ac = ac11;
                sheets[11].ac = ac12;
                sheets[12].ac = ac13;
                sheets[13].ac = ac14;
                sheets[14].ac = ac15;
                sheets[15].ac = ac16;

                sheets[0].ab = ab1;
                sheets[1].ab = ab2;
                sheets[2].ab = ab3;
                sheets[3].ab = ab4;
                sheets[4].ab = ab5;
                sheets[5].ab = ab6;
                sheets[6].ab = ab7;
                sheets[7].ab = ab8;
                sheets[8].ab = ab9;
                sheets[9].ab = ab10;
                sheets[10].ab = ab11;
                sheets[11].ab = ab12;
                sheets[12].ab = ab13;
                sheets[13].ab = ab14;
                sheets[14].ab = ab15;
                sheets[15].ab = ab16;
                
                sheets[0].ranged = ranged1;
                sheets[1].ranged = ranged2;
                sheets[2].ranged = ranged3;
                sheets[3].ranged = ranged4;
                sheets[4].ranged = ranged5;
                sheets[5].ranged = ranged6;
                sheets[6].ranged = ranged7;
                sheets[7].ranged = ranged8;
                sheets[8].ranged = ranged9;
                sheets[9].ranged = ranged10;
                sheets[10].ranged = ranged11;
                sheets[11].ranged = ranged12;
                sheets[12].ranged = ranged13;
                sheets[13].ranged = ranged14;
                sheets[14].ranged = ranged15;
                sheets[15].ranged = ranged16;
              

                sheets[0].spot = spot1;
                sheets[1].spot = spot2;
                sheets[2].spot = spot3;
                sheets[3].spot = spot4;
                sheets[4].spot = spot5;
                sheets[5].spot = spot6;
                sheets[6].spot = spot7;
                sheets[7].spot = spot8;
                sheets[8].spot = spot9;
                sheets[9].spot = spot10;
                sheets[10].spot = spot11;
                sheets[11].spot = spot12;
                sheets[12].spot = spot13;
                sheets[13].spot = spot14;
                sheets[14].spot = spot15;
                sheets[15].spot = spot16;

                sheets[0].listen = listen1;
                sheets[1].listen = listen2;
                sheets[2].listen = listen3;
                sheets[3].listen = listen4;
                sheets[4].listen = listen5;
                sheets[5].listen = listen6;
                sheets[6].listen = listen7;
                sheets[7].listen = listen8;
                sheets[8].listen = listen9;
                sheets[9].listen = listen10;
                sheets[10].listen = listen11;
                sheets[11].listen = listen12;
                sheets[12].listen = listen13;
                sheets[13].listen = listen14;
                sheets[14].listen = listen15;
                sheets[15].listen = listen16;

                sheets[0].sense = sense1;
                sheets[1].sense = sense2;
                sheets[2].sense = sense3;
                sheets[3].sense = sense4;
                sheets[4].sense = sense5;
                sheets[5].sense = sense6;
                sheets[6].sense = sense7;
                sheets[7].sense = sense8;
                sheets[8].sense = sense9;
                sheets[9].sense = sense10;
                sheets[10].sense = sense11;
                sheets[11].sense = sense12;
                sheets[12].sense = sense13;
                sheets[13].sense = sense14;
                sheets[14].sense = sense15;
                sheets[15].sense = sense16;

                sheets[0].cr = cr1;
                sheets[1].cr = cr2;
                sheets[2].cr = cr3;
                sheets[3].cr = cr4;
                sheets[4].cr = cr5;
                sheets[5].cr = cr6;
                sheets[6].cr = cr7;
                sheets[7].cr = cr8;
                sheets[8].cr = cr9;
                sheets[9].cr = cr10;
                sheets[10].cr = cr11;
                sheets[11].cr = cr12;
                sheets[12].cr = cr13;
                sheets[13].cr = cr14;
                sheets[14].cr = cr15;
                sheets[15].cr = cr16;

                sheets[0].xp = xp1;
                sheets[1].xp = xp2;
                sheets[2].xp = xp3;
                sheets[3].xp = xp4;
                sheets[4].xp = xp5;
                sheets[5].xp = xp6;
                sheets[6].xp = xp7;
                sheets[7].xp = xp8;
                sheets[8].xp = xp9;
                sheets[9].xp = xp10;
                sheets[10].xp = xp11;
                sheets[11].xp = xp12;
                sheets[12].xp = xp13;
                sheets[13].xp = xp14;
                sheets[14].xp = xp15;
                sheets[15].xp = xp16;

                sheets[0].pC = checkBox1;
                sheets[1].pC = checkBox2;
                sheets[2].pC = checkBox3;
                sheets[3].pC = checkBox4;
                sheets[4].pC = checkBox5;
                sheets[5].pC = checkBox6;
                sheets[6].pC = checkBox7;
                sheets[7].pC = checkBox8;
                sheets[8].pC = checkBox9;
                sheets[9].pC = checkBox10;
                sheets[10].pC = checkBox11;
                sheets[11].pC = checkBox12;
                sheets[12].pC = checkBox13;
                sheets[13].pC = checkBox14;
                sheets[14].pC = checkBox15;
                sheets[15].pC = checkBox16;
                #endregion

                for (int i = 0; i < 16; i++)
                {
                    sheets[i].ab.ContextMenu = meleeContextMenu;
                    sheets[i].ranged.ContextMenu = rangedContextMenu;
                    sheets[i].names.ContextMenu = conditionsContextMenu;
                }
            }
            #region Auxilliary Functions
            private void GetInfo()
            {
                for (int i = 0; i < 16; i++)
                {
                    bool result = characters[i].UpdateCharacter(sheets[i]);
                    if (result)
                        exists[i] = true;
                    else
                        exists[i] = false;
                }

            }
            private void PutInfo()
            {
                for (int i = 0; i < 16; i++)
                {
                    characters[i].UpdateSheet(sheets[i]);
                }
            }
            private Character[] orderFighters(Character[] characters)
            {
                Character temp;
                bool tempE;
                for (int i = 0; i < 16; i++)
                {
                    for (int j = i+1; j < 16; j++)
                    {
                        if (characters[j].init >characters[i].init && exists[j])
                        {
                            temp = characters[i];
                            tempE = exists[i];
                            characters[i] = characters[j];
                            exists[i] = exists[j];
                            characters[j] = temp;
                            exists[j] = tempE;
                        }
                    }
                }
                return characters;
            }
            private void ClearColors()
            {
                for (int i = 0; i < 16; i++)
                {
                    if (i % 2 == 0)
                    {
                        sheets[i].names.Background = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        sheets[i].names.Background = new SolidColorBrush(Colors.Azure);
                    }
                }
            }
            private void RollCheck(int i, string skill, int modif)
            {
                Random randomizer = new Random();
                int diceRoll = randomizer.Next(1, 21);
                string newLine = String.Format("{0}'s {1} Roll: {2} + {3} = {4}", characters[i].nome, skill,
                    System.Convert.ToString(diceRoll), System.Convert.ToString(modif), System.Convert.ToString(diceRoll + modif));
                journal.Update(newLine);
            }
            void UpdateAtkContextMenus()
            {
                meleeContextMenu.Items.Clear();
                rangedContextMenu.Items.Clear();
                for (int i = 0; exists[i]; i++)
                {
                    MenuItem menuItem = new MenuItem();
                    MenuItem menuItem2 = new MenuItem();
                    menuItem.Header = "Melee Atk: " +characters[i].nome;
                    menuItem2.Header = "Ranged Atk: " +characters[i].nome;
                    menuItem.Tag = menuItem2.Tag = i;
                    menuItem.Click += new RoutedEventHandler(atkMenuItem_Click);
                    menuItem2.Click += new RoutedEventHandler(atkMenuItem_Click);
                    meleeContextMenu.Items.Add(menuItem);
                    rangedContextMenu.Items.Add(menuItem2);
                }
            }
            #endregion

            #region Combat Buttons Events
            private void startButton_Click(object sender, RoutedEventArgs e)
            {
                characters = orderFighters(characters);
                PutInfo();

                turn = 0;
                current = 0;

                journal.Update("--Combat Started--");
                UpdateAtkContextMenus();

                ClearColors();
                sheets[current].names.Background = new SolidColorBrush(Colors.CornflowerBlue);
                currentBox.Text = characters[current].nome;
                turnBox.Text = "0";
            }
            private void finisher_Click(object sender, RoutedEventArgs e)
            {
                turn = 0;
                currentBox.Text = "";
                current = 0;
                ClearColors();
                turnBox.Text = "";

                MessageBoxResult result = MessageBox.Show("Clear DEAD?", "Finished Combat", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (i % 2 == 0)
                        {
                            sheets[i].names.Background = new SolidColorBrush(Colors.White);
                        }
                        else
                        {
                            sheets[i].names.Background = new SolidColorBrush(Colors.Azure);
                        }
                        if (characters[i].hp < 1)
                        {
                            characters[i].Clear();
                            exists[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (i % 2 == 0)
                        {
                            sheets[i].names.Background = new SolidColorBrush(Colors.White);
                        }
                        else
                        {
                            sheets[i].names.Background = new SolidColorBrush(Colors.Azure);
                        }
                    }

                }
                resetAllInit_Click(this, new RoutedEventArgs());

            }
            private void order_Click(object sender, RoutedEventArgs e)
            {
                ClearColors();
                
                characters = orderFighters(characters);
                PutInfo();
            }
            private void nextButton_Click(object sender, RoutedEventArgs e)
            {
                if (current % 2 == 0)
                {
                    sheets[current].names.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    sheets[current].names.Background = new SolidColorBrush(Colors.Azure);
                }
                current++;
                if (!exists[current])
                {
                    turn++;
                    for (int i = 0; i < current; i++)
                    {
                        if (characters[i].conditions.Count > 0)
                        {
                            journal.Update(characters[i].UpdateConditions());
                            characters[i].UpdateSheet(sheets[i]);
                        }
                    }
                    journal.Update("-- Turn: " + System.Convert.ToString(turn) + " --");
                    current = 0;
                }
                sheets[current].names.Background = new SolidColorBrush(Colors.CornflowerBlue);
                currentBox.Text = characters[current].nome;
                turnBox.Text = System.Convert.ToString(turn);
            }
            private void prevButton_Click(object sender, RoutedEventArgs e)
            {
                if (current % 2 == 0)
                {
                    sheets[current].names.Background = new SolidColorBrush(Colors.White);
                }
                else
                {
                    sheets[current].names.Background = new SolidColorBrush(Colors.Azure);
                }
                current--;
                if (current < 0)
                {
                    for (current = 15; ; current--)
                    {
                        if (exists[current])
                        {
                            break;
                        }
                    }
                    turn--;
                }
                sheets[current].names.Background = new SolidColorBrush(Colors.CornflowerBlue);
                currentBox.Text = characters[current].nome;
                turnBox.Text = System.Convert.ToString(turn);
            }
            private void clearButton_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (i % 2 == 0)
                    {
                        sheets[i].names.Background = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        sheets[i].names.Background = new SolidColorBrush(Colors.Azure);
                    }
                    if (!characters[i].pc)
                    {
                        characters[i].Clear();
                        exists[i] = false;
                    }
                }
                journal.Update("-- Cleared All NPCs --");
                characters = orderFighters(characters);
                PutInfo();
            }
            private void clearAllButton_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 16; i++)
                {
                    characters[i].Clear();
                    exists[i] = false;
                }
                journal.Update("-- Cleared All Characters --");
                characters = orderFighters(characters);
                PutInfo();
            }
            private void clearPCs_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].pc)
                    {
                        characters[i].Clear();
                        exists[i] = false;
                    }
                }
                journal.Update("-- Cleared All PCs --");
                characters = orderFighters(characters);
                PutInfo();
            }
            private void rollInitButton_Click(object sender, RoutedEventArgs e)
            {
                //Random random = new Random();
                for (int i = 0; i < 16; i++)
                {
                    if (!characters[i].pc)
                    {
                        if (exists[i])
                        {
                            characters[i].RollInit();//random.Next(1,21));
                        }
                    }
                }
                PutInfo();
                journal.Update("-- Rolled Initiative for all NPCs --");
            }
            private void rollAllInit_Click(object sender, RoutedEventArgs e)
            {
                Random random = new Random();
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].maxHP > 0)
                    {
                        characters[i].RollInit();
                    }
                }
                PutInfo();
                journal.Update("-- Rolled Initiative for Everybody --");
            }
            private void resetNpcInit_Click(object sender, RoutedEventArgs e)
            {
                
                for (int i = 0; i < 16; i++)
                {
                    if (exists[i])
                    {
                        if (!characters[i].pc)
                        {
                            characters[i].ResetInit();
                        }
                    }
                }
                PutInfo();
                journal.Update("-- Set Initiative = Inititive Mod for all NPCs --");
            }
            private void resetAllInit_Click(object sender, RoutedEventArgs e)
            {
                
                for (int i = 0; i < 16; i++)
                {
                    if (exists[i])
                    {
                        characters[i].ResetInit();
                    }
                }
                PutInfo();
                journal.Update("-- Set Initiative = Inititive Mod for everybody --");
            }
            private void resetNpcHP_Click(object sender, RoutedEventArgs e)
            {
                
                for (int i = 0; i < 16; i++)
                {
                    if (!characters[i].pc)
                    {
                        if (exists[i])
                        {
                            characters[i].SetHP(); ;
                        }
                    }
                }
                PutInfo();
                journal.Update("-- Set all NPCs HP to Maximum--");
            }
            private void resetAllHP_Click(object sender, RoutedEventArgs e)
            {
                
                for (int i = 0; i < 16; i++)
                {
                    if (exists[i])
                    {
                        characters[i].SetHP() ;
                    }
                }
                PutInfo();
                journal.Update("-- Set all HP to Maximum --");
            }
            private void rollAll_Click(object sender, RoutedEventArgs e)
            {
                Random randomizer = new Random();
                
                string msg = "Results:\n";
                for (int i = 0; i < 16; i++)
                {
                    if (exists[i])
                    {
                        if (comboBox1.Text == "Fort")
                        {
                            msg = msg + characters[i].nome + " = " + System.Convert.ToString(characters[i].fort + randomizer.Next(1, 21)) + "\n";
                        }
                        else if (comboBox1.Text == "Reflex")
                        {
                            msg = msg + characters[i].nome + " = " + System.Convert.ToString(characters[i].refl + randomizer.Next(1, 21)) + "\n";
                        }
                        else if (comboBox1.Text == "Will")
                        {
                            msg = msg + characters[i].nome + " = " + System.Convert.ToString(characters[i].will + randomizer.Next(1, 21)) + "\n";
                        }
                        else if (comboBox1.Text == "Spot")
                        {
                            msg = msg + characters[i].nome + " = " + System.Convert.ToString(characters[i].spot + randomizer.Next(1, 21)) + "\n";
                        }
                        else if (comboBox1.Text == "Sense Motive")
                        {
                            msg = msg + characters[i].nome + " = " + System.Convert.ToString(characters[i].sense + randomizer.Next(1, 21)) + "\n";
                        }
                        else
                        {
                            msg = msg + characters[i].nome + " = " + System.Convert.ToString(characters[i].listen + randomizer.Next(1, 21)) + "\n";
                        }
                    }
                }
                string title = "Rolls Results";
                MessageBox.Show(msg, title);
            }
            private void giveXPButton_Click(object sender, RoutedEventArgs e)
            {
                int totalPlayers = 0;
                int totalXP = System.Convert.ToInt32(giveXPBox.Text);
                int dividedXP;
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].maxHP > 0 && characters[i].pc)
                    {
                        totalPlayers++;
                    }
                }
                dividedXP = totalXP / totalPlayers;
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].maxHP > 0 && characters[i].pc)
                    {
                        characters[i].xp += dividedXP;
                    }
                }
                PutInfo();
                journal.Update(String.Format("Awarded {0} Experience to Everybody", System.Convert.ToString(dividedXP)));
            }

            private void giveGoldButton_Click(object sender, RoutedEventArgs e)
            {

                int totalPlayers = 0;
                int totalXP = System.Convert.ToInt32(giveXPBox.Text);
                int dividedXP;
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].maxHP > 0 && characters[i].pc)
                    {
                        totalPlayers++;
                    }
                }
                dividedXP = totalXP / totalPlayers;
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].maxHP > 0 && characters[i].pc)
                    {
                        characters[i].cr += dividedXP;
                    }
                }
                PutInfo();
                journal.Update(String.Format("Awarded {0} Gold to Everybody", System.Convert.ToString(dividedXP)));
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

            #region io function
            private void saveLastButton_Click(object sender, RoutedEventArgs e)
            {
                string temps = this.lastSavedFile;
                System.IO.StreamWriter SW = System.IO.File.CreateText(temps);
                characters = orderFighters(characters);
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].maxHP > 0)
                    {
                        string pcq;
                        if (characters[i].pc)
                            pcq = "1";
                        else
                            pcq = "0";

                        string S = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}", characters[i].nome, System.Convert.ToString(characters[i].init),
                            System.Convert.ToString(characters[i].hp), System.Convert.ToString(characters[i].initMod), System.Convert.ToString(characters[i].maxHP), System.Convert.ToString(characters[i].fort),
                            System.Convert.ToString(characters[i].refl), System.Convert.ToString(characters[i].will),
                            System.Convert.ToString(characters[i].ac), System.Convert.ToString(characters[i].ab), System.Convert.ToString(characters[i].ranged),
                            System.Convert.ToString(characters[i].spot), System.Convert.ToString(characters[i].listen), System.Convert.ToString(characters[i].sense),
                            System.Convert.ToString(characters[i].cr), System.Convert.ToString(characters[i].xp), pcq);
                        SW.WriteLine(S);
                    }
                }
                SW.Close();
            }
            private void saveBackupButton_Click(object sender, RoutedEventArgs e)
            {
                string temps = this.lastSavedFile + "BAK";
                System.IO.StreamWriter SW = System.IO.File.CreateText(temps);
                characters = orderFighters(characters);
                for (int i = 0; i < 16; i++)
                {
                    if (characters[i].maxHP > 0)
                    {
                        string pcq;
                        if (characters[i].pc)
                            pcq = "1";
                        else
                            pcq = "0";

                        string S = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}", characters[i].nome, System.Convert.ToString(characters[i].init),
                            System.Convert.ToString(characters[i].hp), System.Convert.ToString(characters[i].initMod), System.Convert.ToString(characters[i].maxHP), System.Convert.ToString(characters[i].fort),
                            System.Convert.ToString(characters[i].refl), System.Convert.ToString(characters[i].will),
                            System.Convert.ToString(characters[i].ac), System.Convert.ToString(characters[i].ab), System.Convert.ToString(characters[i].ranged),
                            System.Convert.ToString(characters[i].spot), System.Convert.ToString(characters[i].listen), System.Convert.ToString(characters[i].sense),
                            System.Convert.ToString(characters[i].cr), System.Convert.ToString(characters[i].xp), pcq);
                        SW.WriteLine(S);
                    }
                }
                SW.Close();
            }
            private void loader_Click(object sender, RoutedEventArgs e)
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
                    this.Title = "IniBronx " + temps;
                    this.lastSavedFile = temps;
                System.IO.StreamReader SR;
                try
                {
                    SR = System.IO.File.OpenText(temps);
                    string S;
                    int i = 0;
                    S = SR.ReadLine();
                    string newLine = "";
                    while (S != null)
                    {
                        string[] loadedLine = S.Split(',');
                        sheets[i].names.Text = loadedLine[0];
                        sheets[i].inits.Text = loadedLine[1];
                        sheets[i].hP.Text = loadedLine[2];
                        sheets[i].initMod.Text = loadedLine[3];
                        sheets[i].maxHP.Text = loadedLine[4];
                        sheets[i].fort.Text = loadedLine[5];
                        sheets[i].refl.Text = loadedLine[6];
                        sheets[i].will.Text = loadedLine[7];
                        sheets[i].ac.Text = loadedLine[8];
                        sheets[i].ab.Text = loadedLine[9];
                        sheets[i].ranged.Text = loadedLine[10];
                        sheets[i].spot.Text = loadedLine[11];
                        sheets[i].listen.Text = loadedLine[12];
                        sheets[i].sense.Text = loadedLine[13];
                        sheets[i].cr.Text = loadedLine[14];
                        sheets[i].xp.Text = loadedLine[15];
                        int temp = System.Convert.ToInt32(loadedLine[16]);
                        if (temp == 0)
                            sheets[i].pC.IsChecked = false;
                        else
                            sheets[i].pC.IsChecked = true;
                        S = SR.ReadLine();
                        newLine += sheets[i].names.Text + ",";
                        i++;
                    }
                    journal.Update(newLine + " Loaded.");
                    GetInfo();

                }
                catch (System.IO.FileNotFoundException)
                {
                    string msg = "este arquivo n existe. Vc eh retardado?";
                    string title = "Usuario Retardado Detectado";
                    MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception)
                {
                }
            }
            private void includeLastButton_Click(object sender, RoutedEventArgs e)
            {
                GetInfo();
                characters = orderFighters(characters);
                string temps = this.lastIncludedFile;
                System.IO.StreamReader SR;
                try
                {
                    SR = System.IO.File.OpenText(temps);
                    string S;
                    int i = 0;
                    while (characters[i].maxHP > 0)
                    {
                        i++;
                    }
                    S = SR.ReadLine();
                    string newLine = "";
                    while (S != null || i > 15)
                    {
                        string[] loadedLine = S.Split(',');
                        sheets[i].names.Text = loadedLine[0];
                        sheets[i].inits.Text = loadedLine[1];
                        sheets[i].hP.Text = loadedLine[2];
                        sheets[i].initMod.Text = loadedLine[3];
                        sheets[i].maxHP.Text = loadedLine[4];
                        sheets[i].fort.Text = loadedLine[5];
                        sheets[i].refl.Text = loadedLine[6];
                        sheets[i].will.Text = loadedLine[7];
                        sheets[i].ac.Text = loadedLine[8];
                        sheets[i].ab.Text = loadedLine[9];
                        sheets[i].ranged.Text = loadedLine[10];
                        sheets[i].spot.Text = loadedLine[11];
                        sheets[i].listen.Text = loadedLine[12];
                        sheets[i].sense.Text = loadedLine[13];
                        sheets[i].cr.Text = loadedLine[14];
                        sheets[i].xp.Text = loadedLine[15];
                        int temp = System.Convert.ToInt32(loadedLine[16]);
                        if (temp == 0)
                            sheets[i].pC.IsChecked = false;
                        else
                            sheets[i].pC.IsChecked = true;
                        S = SR.ReadLine();
                        newLine += sheets[i].names.Text + ",";
                        i++;
                    }
                    journal.Update(newLine + " Loaded.");
                    GetInfo();
                }
                catch (System.IO.FileNotFoundException)
                {
                    string msg = "este arquivo n existe seu retardado";
                    string title = "Usuario Retardado Detectado";
                    MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception)
                {
                }
            }
           
            private void includer_Click(object sender, RoutedEventArgs e)
            {
                GetInfo();
                characters = orderFighters(characters);
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                Nullable<bool> result = ofd.ShowDialog();
                string temps;
                if (result == true)
                {
                    temps = ofd.FileName;
                }
                else
                    return;
                this.lastIncludedFile = temps;
                System.IO.StreamReader SR;
                try
                {
                    SR = System.IO.File.OpenText(temps);
                    string S;
                    int i = 0;
                    while (characters[i].maxHP > 0)
                    {
                        i++;
                    }
                    S = SR.ReadLine();
                    string newLine = "";
                    while (S != null || i > 15)
                    {
                        string[] loadedLine = S.Split(',');
                        sheets[i].names.Text = loadedLine[0];
                        sheets[i].inits.Text = loadedLine[1];
                        sheets[i].hP.Text = loadedLine[2];
                        sheets[i].initMod.Text = loadedLine[3];
                        sheets[i].maxHP.Text = loadedLine[4];
                        sheets[i].fort.Text = loadedLine[5];
                        sheets[i].refl.Text = loadedLine[6];
                        sheets[i].will.Text = loadedLine[7];
                        sheets[i].ac.Text = loadedLine[8];
                        sheets[i].ab.Text = loadedLine[9];
                        sheets[i].ranged.Text = loadedLine[10];
                        sheets[i].spot.Text = loadedLine[11];
                        sheets[i].listen.Text = loadedLine[12];
                        sheets[i].sense.Text = loadedLine[13]; 
                        sheets[i].cr.Text = loadedLine[14];
                        sheets[i].xp.Text = loadedLine[15];
                        int temp = System.Convert.ToInt32(loadedLine[16]);
                        if (temp == 0)
                            sheets[i].pC.IsChecked = false;
                        else
                            sheets[i].pC.IsChecked = true;
                        S = SR.ReadLine();
                        newLine += sheets[i].names.Text + ",";
                        i++;
                    }
                    journal.Update(newLine + " Loaded.");
                    GetInfo();
                }
                catch (System.IO.FileNotFoundException)
                {
                    string msg = "este arquivo n existe seu retardado";
                    string title = "Usuario Retardado Detectado";
                    MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception)
                {
                }
            }
            private void saver_Click(object sender, RoutedEventArgs e)
            {
                Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
                Nullable<bool> result = ofd.ShowDialog();
                string temps;
                if (result == true)
                {
                    temps = ofd.FileName;
                }
                else
                    return;
                this.lastSavedFile = temps;
                System.IO.StreamWriter SW = System.IO.File.CreateText(temps);
                characters = orderFighters(characters);
                for (int i = 0; i <16; i++)
                {
                    if (characters[i].maxHP > 0)
                    {
                        string pcq;
                        if (characters[i].pc)
                            pcq = "1";
                        else
                            pcq = "0";

                        string S = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}", characters[i].nome, System.Convert.ToString(characters[i].init),
                            System.Convert.ToString(characters[i].hp), System.Convert.ToString(characters[i].initMod), System.Convert.ToString(characters[i].maxHP), System.Convert.ToString(characters[i].fort),
                            System.Convert.ToString(characters[i].refl), System.Convert.ToString(characters[i].will),
                            System.Convert.ToString(characters[i].ac), System.Convert.ToString(characters[i].ab), System.Convert.ToString(characters[i].ranged),
                            System.Convert.ToString(characters[i].spot), System.Convert.ToString(characters[i].listen), System.Convert.ToString(characters[i].sense),
                            System.Convert.ToString(characters[i].cr), System.Convert.ToString(characters[i].xp), pcq);
                        SW.WriteLine(S);
                    }
                }
                SW.Close();
            }
            #endregion

            #region TextBox Events
            private void TextClickEvent(object sender, RoutedEventArgs e)
            {
                GetInfo();
                TextBox sourceTextBox = (TextBox)e.Source;
                int i  = System.Convert.ToInt32(sourceTextBox.Tag);
                i--;
                    if (exists[i])
                    {
                        if (sheets[i].fort == sourceTextBox)
                        {
                            RollCheck(i, "Fortitude Saving", characters[i].fort);
                        }
                        if (sheets[i].refl == sourceTextBox)
                        {
                            RollCheck(i, "Reflex Saving", characters[i].refl);
                        }
                        if (sheets[i].will == sourceTextBox)
                        {
                            RollCheck(i, "Will Saving", characters[i].will);
                        }
                        if (sheets[i].ab == sourceTextBox)
                        {
                            RollCheck(i, "Melee Attack", characters[i].ab);
                        }
                        if (sheets[i].ranged == sourceTextBox)
                        {
                            RollCheck(i, "Ranged Attack", characters[i].ranged);
                        }
                        if (sheets[i].spot == sourceTextBox)
                        {
                            RollCheck(i, "Spot", characters[i].spot);
                        }
                        if (sheets[i].listen == sourceTextBox)
                        {
                            RollCheck(i, "Listen", characters[i].listen);
                        }
                        if (sheets[i].sense == sourceTextBox)
                        {
                            RollCheck(i, "Sense Motive", characters[i].sense);
                        }
                    }
            }
            private void ClearJournal(object sender, RoutedEventArgs e)
            {
                journal.ClearJournal();
            }
            private void saveCurrrentTextBoxInfo(object sender, RoutedEventArgs e)
            {
                
                Control textBoxSender = (Control)sender;
                int i = System.Convert.ToInt32(textBoxSender.Tag);
                i--;
                exists[i] = characters[i].UpdateCharacter(sheets[i]);
            }
            private void contextMenu_Open(object sender, ContextMenuEventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                contextMenuParent = System.Convert.ToInt32(textBox.Tag);
            }
            private void atkMenuItem_Click(object sender, RoutedEventArgs e)
            {
                MenuItem menuItem = (MenuItem)sender;
                ContextMenu contextMenu = (ContextMenu)menuItem.Parent;
                Random random = new Random();
                int target = System.Convert.ToInt32(menuItem.Tag);

                int attacker = contextMenuParent - 1;
                int roll = random.Next(1, 21);
                int mod;
                int ac = characters[target].ac;
                string atkType;
                string hit;
                string msg;
                if (contextMenu == meleeContextMenu)
                {
                    mod = characters[contextMenuParent].ab;
                    atkType = "Melee";
                }
                else
                {
                    mod = characters[contextMenuParent].ranged;
                    atkType = "Ranged";
                }
                if (roll + mod >= ac)
                {
                    hit = "HIT!";
                }
                else
                {
                    hit = "MISSED!";
                }
                msg = String.Format("{0}'s {1} attack roll against {2}: {3} + {4} = {5} , AC={6} {7}",
                    characters[attacker].nome, atkType, characters[target].nome, System.Convert.ToString(roll),
                    System.Convert.ToString(mod), System.Convert.ToString(roll + mod), System.Convert.ToString(ac),
                    hit);
                journal.Update(msg);
            }
            private void conditionMenuItem_Click(object sender, RoutedEventArgs e)
            {
                ConditionWindow cWindow = new ConditionWindow(characters[contextMenuParent-1], journal);
                cWindow.ShowDialog();
                characters[contextMenuParent-1].UpdateSheet(sheets[contextMenuParent-1]);
            }
            #endregion

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

            private void load_SpellBook_Click(object sender, RoutedEventArgs e)
            {
                Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                ofd.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                Nullable<bool> result = ofd.ShowDialog();
                string temps;
                if (result == true)
                {
                    temps = ofd.FileName;
                }
                else
                    return;
                Window2 spellBookWindow = new Window2();
                spellBookWindow.LoadSpellBook(temps, comboBox2.Text);
                spellBookWindow.Show();
            }

            private void applyDamage(object sender, MouseButtonEventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                int damageTaker = System.Convert.ToInt32(textBox.Tag)-1;
                int damage;
                try
                {
                    damage = System.Convert.ToInt32(applyDamageTextbox.Text);
                }
                catch { damage = 0; MessageBox.Show("Invalid Integer"); }
                characters[damageTaker].hp -= damage;
                characters[damageTaker].UpdateSheet(sheets[damageTaker]);
            }

            

           

           
        }
}
