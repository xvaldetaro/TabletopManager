using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WpfApplication1
{
    enum BookType
    {
        Cleric, Sorcerer, Wizard
    }
    class Spell
    {
        public string name;
        public string school;
        public string range;
        public string duration;
        public string description;

        public void LoadFromXml(XmlNode node)
        {
            XmlNodeList list = node.ChildNodes;
            this.name = list.Item(0).InnerText;
            this.range = list.Item(3).InnerText;
            this.duration = list.Item(4).InnerText;
            this.school = list.Item(1).InnerText;
            try
            {
                this.description = list.Item(9).InnerText;
            }
            catch
            {
                this.description = list.Item(8).InnerText;
            }
        }
        public void PrintSelf()
        {
            Console.WriteLine(String.Format("{0}\nRange: {1}\nDuration: {2}\nSchool: {3}\nDescription: {4}\n",
                this.name, this.range, this.duration, this.school, this.description));
        }
    }
    class SpellBook
    {
        BookType bookType;
        List<Spell> spells;
        public List<Spell>[] lvl;
        string bookName;

        public SpellBook(BookType bookType)
        {
            this.bookType = bookType;
            spells = new List<Spell>();
            lvl = new List<Spell>[10];
            for (int i = 0; i < 10; i++)
            {
                lvl[i] = new List<Spell>();
            }
        }
        public void LoadKnownFromXml(string xmlDocName)
        {
            Spell spell;
            XmlDocument mainDoc = new XmlDocument();
            mainDoc.Load(xmlDocName);
            XmlNodeList nodeList = mainDoc.GetElementsByTagName("spells");
            XmlNode node = nodeList.Item(0);
            nodeList = node.ChildNodes;
            foreach (XmlNode childNode in nodeList)
            {
                try
                {
                    spell = new Spell();
                    spell.LoadFromXml(childNode);
                }
                catch
                {
                    continue;
                }
                this.spells.Add(spell);
            }
            if (this.bookType == BookType.Sorcerer)
            {
                nodeList = mainDoc.GetElementsByTagName("spells-known");
                node = nodeList.Item(0);
                node = node.FirstChild;
                nodeList = node.ChildNodes;
                int startNode = 0;
                foreach (XmlNode childNode in nodeList)
                {
                    if (startNode > 8)
                    {
                        try
                        {
                            XmlNodeList list = childNode.ChildNodes;
                            int spellLvl = System.Convert.ToInt32(list.Item(1).InnerText);
                            this.lvl[spellLvl].Add(MatchSpell(list.Item(0).InnerText));
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    startNode++;
                }

            }
            else
            {
                nodeList = mainDoc.GetElementsByTagName("spells-prepared");
                node = nodeList.Item(0);
                node = node.FirstChild;
                nodeList = node.ChildNodes;
                foreach (XmlNode childNode in nodeList)
                {
                    try
                    {
                        XmlNodeList list = childNode.ChildNodes;
                        for (int i = 0; i < System.Convert.ToInt32(list.Item(2).InnerText); i++)
                        {
                            int spellLvl = System.Convert.ToInt32(list.Item(3).InnerText);
                            this.lvl[spellLvl].Add(MatchSpell(list.Item(0).InnerText));
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

        }
        public void PrintSelf()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(String.Format("Level {0} Spells:\n", i));
                foreach (Spell spell in lvl[i])
                {
                    spell.PrintSelf();
                }
            }
        }
        private Spell MatchSpell(string spellName)
        {
            foreach (Spell spell in this.spells)
            {
                if (spell.name == spellName)
                {
                    return spell;
                }
            }
            Spell fakeSpell = new Spell();
            fakeSpell.name = spellName;
            return fakeSpell;
        }



    }
}