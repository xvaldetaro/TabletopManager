using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public enum eAbilities
    {
        str, dex, con, intel, wis, cha
    }
    public class Ability
    {
        int rank;
        eAbilities type;
        public Ability(eAbilities ability, int value)
        {
            rank = value;
            type = ability;
        }
        public string AbilityName
        {
            get { return type.ToString(); }
        }
        public int Value
        {
            get { return this.rank; }
            set { this.rank = value; }
        }
        public int Modifier
        {
            get { return (this.rank-10) / 2; }
        }

    }
}
