using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public enum eSkills
    {
        Appraise,Balance,Bluff,Climb,Concentration,Craft,Decipher_Script,
        Diplomacy,Disable_Device,Disguise,Escape_Artist,Forgery,Gather_Information,
        Handle_Animal, Heal, Hide, Intimidate, Jump, Knowledge1, Knowledge2,
        Knowledge3, Knowledge4, Listen, Move_Silently, Open_Lock,
        Perform,Profession,Ride,Search,Sense_Motive,Sleight_of_Hand,Speak_Language,
        Spellcraft,Spot,Survival,Swim,Tumble,Use_Magic_Device,Use_Rope
    }
    public class Skill
    {
        eSkills type;
        int skillRank;
        public Skill(eSkills skill, int ranks)
        {
            this.type = skill;
            this.skillRank = ranks;
        }
        public string SkillName
        {
            get { return type.ToString(); }
        }
        public int SkillRank
        {
            get { return skillRank; }
            set { this.skillRank = value; }
        }
    }
}
