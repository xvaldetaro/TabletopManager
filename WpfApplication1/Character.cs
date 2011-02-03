using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aprimorando
{
    public enum ConditionType
        {
            Strength, Dexterity, Constitution, Inteligence, Wisdom, Charisma,
            AttackBonus, ArmorClass, HP,
            Fortitude, Reflex, Will,
            Poison, Disease, Stun, Blind, Shaken, Nausea,
            Other
        };
    public class TempCondition
        {
            Character character;
            public string name;
            ConditionType conditionType;
            public int duration;
            public int changeValue;
            public TempCondition(ConditionType conditionType, int duration, Character character, int changeValue)
            {
                this.conditionType = conditionType;
                this.duration = duration;
                this.character = character;
                this.changeValue = changeValue;
                this.name = conditionType.ToString("F"); 
                ApplyEffects();
            }
            public bool Update()
            {
                if (duration > 0)
                {
                    this.duration--;
                    if (duration == 0)
                    {
                        this.changeValue = this.changeValue*(-1);
                        ApplyEffects();
                        return true;
                    }
                }
                    return false;
            }
            public void ApplyEffects()
            {
                switch (conditionType)
                {
                    case ConditionType.Strength:
                        character.ab += (int)changeValue / 2;
                        break;
                    case ConditionType.Dexterity:
                        character.ranged += (int)changeValue / 2;
                        character.ac += (int)changeValue / 2;
                        character.refl += (int)changeValue / 2;
                        break;
                    case ConditionType.Constitution:
                        //character.hp += character.hp + (character.cr * (int)changeValue / 2);
                        character.fort += (int)changeValue / 2;
                        break;
                    case ConditionType.Inteligence:
                        break;
                    case ConditionType.Wisdom:
                        character.will += (int)changeValue / 2;
                        break;
                    case ConditionType.Charisma:
                        break;
                    case ConditionType.AttackBonus:
                        character.ab += (int)changeValue;
                        character.ranged += (int)changeValue;
                        break;
                    case ConditionType.ArmorClass:
                        character.ac += (int)changeValue;
                        break;
                    case ConditionType.HP:
                        character.hp += (int)changeValue;
                        break;
                    case ConditionType.Fortitude:
                        character.ranged += (int)changeValue;
                        break;
                    case ConditionType.Reflex:
                        character.refl += (int)changeValue;
                        break;
                    case ConditionType.Will:
                        character.will += (int)changeValue;
                        break;
                    case ConditionType.Poison:
                        break;
                    case ConditionType.Disease:
                        break;
                    case ConditionType.Stun:
                        break;
                    case ConditionType.Blind:
                        break;
                    case ConditionType.Shaken:
                        break;
                    case ConditionType.Nausea:
                        break;
                    case ConditionType.Other:
                        break;
                    default:
                        break;
                }
            }
        }
    public class Character
    {
        public double init;
        public string nome;
        public int hp;
        public int initMod;
        public int maxHP;
        public int fort;
        public int refl;
        public int will;
        public int ab;
        public int ranged;
        public int ac;
        public int spot;
        public int listen;
        public int sense;
        public int cr;
        public int xp;
        public bool pc;
        public static Random random = new Random();
        public List<TempCondition> conditions;

        public Character()
        {
            conditions = new List<TempCondition>();
        }
        public bool UpdateCharacter(sheet cSheet)
        {
            this.nome = cSheet.names.Text;
            try
            {
                this.initMod = System.Convert.ToInt32(cSheet.initMod.Text);
            }
            catch (FormatException)
            {
                this.initMod = 0;
                cSheet.initMod.Text = "0";
            }
            try
            {
                this.init = System.Convert.ToDouble(cSheet.inits.Text);
             }
            catch (FormatException)
            {
                this.init = 0;
                cSheet.inits.Text = "0";
            }
            try
            {
                this.maxHP = System.Convert.ToInt32(cSheet.maxHP.Text);
            }
            catch (FormatException)
            {
                this.maxHP = 0;
                cSheet.maxHP.Text = "0";
            }
            try
            {
                this.hp = System.Convert.ToInt32(cSheet.hP.Text);
            }
            catch (FormatException)
            {
                this.hp = 0;
                cSheet.hP.Text = "0";
            }
            try
            {
                this.fort = System.Convert.ToInt32(cSheet.fort.Text);
            }
            catch (FormatException)
            {
                this.fort = 0;
                cSheet.fort.Text = "0";
            }
            try
            {
                this.refl = System.Convert.ToInt32(cSheet.refl.Text);
                }
            catch (FormatException)
            {
                this.refl = 0;
                cSheet.refl.Text = "0";
            }
            try
            {
                this.will = System.Convert.ToInt32(cSheet.will.Text);
                }
            catch (FormatException)
            {
                this.will = 0;
                cSheet.will.Text = "0";
            }
            try
            {
                this.ac = System.Convert.ToInt32(cSheet.ac.Text);
                }
            catch (FormatException)
            {
                this.ac = 0;
                cSheet.ac.Text = "0";
            }
            try
            {
                this.ab = System.Convert.ToInt32(cSheet.ab.Text);
                }
            catch (FormatException)
            {
                this.ab = 0;
                cSheet.ab.Text = "0";
            }
            try
            {
                this.ranged = System.Convert.ToInt32(cSheet.ranged.Text);
                }
            catch (FormatException)
            {
                this.ranged = 0;
                cSheet.ranged.Text = "0";
            }
            try
            {
                this.listen = System.Convert.ToInt32(cSheet.listen.Text);
                }
            catch (FormatException)
            {
                this.listen = 0;
                cSheet.listen.Text = "0";
            }
            try
            {
                this.spot = System.Convert.ToInt32(cSheet.spot.Text);
                }
            catch (FormatException)
            {
                this.spot = 0;
                cSheet.spot.Text = "0";
            }
            try
            {
                this.sense = System.Convert.ToInt32(cSheet.sense.Text);
                }
            catch (FormatException)
            {
                this.sense = 0;
                cSheet.sense.Text = "0";
            }
            try
            {
                this.cr = System.Convert.ToInt32(cSheet.cr.Text);
                }
            catch (FormatException)
            {
                this.cr = 0;
                cSheet.cr.Text = "0";
            }
            try
            {
                this.xp = System.Convert.ToInt32(cSheet.xp.Text);
            }
            catch (FormatException)
            {
                this.xp = 0;
                cSheet.xp.Text = "0";
            }
            this.pc = (bool)cSheet.pC.IsChecked;
            if (this.maxHP > 0)
               return true;
            else
               return false;
        }
        public void UpdateSheet(sheet cSheet)
        {
            for (int i = 0; i < 16; i++)
            {
                if (this.maxHP > 0)
                {
                    cSheet.names.Text = this.nome;
                    cSheet.initMod.Text = System.Convert.ToString(this.initMod);
                    cSheet.maxHP.Text = System.Convert.ToString(this.maxHP);
                    cSheet.inits.Text = System.Convert.ToString(this.init);
                    cSheet.hP.Text = System.Convert.ToString(this.hp);
                    cSheet.fort.Text = System.Convert.ToString(this.fort);
                    cSheet.refl.Text = System.Convert.ToString(this.refl);
                    cSheet.will.Text = System.Convert.ToString(this.will);
                    cSheet.ac.Text = System.Convert.ToString(this.ac);
                    cSheet.ab.Text = System.Convert.ToString(this.ab);
                    cSheet.ranged.Text = System.Convert.ToString(this.ranged);
                    cSheet.spot.Text = System.Convert.ToString(this.spot);
                    cSheet.listen.Text = System.Convert.ToString(this.listen);
                    cSheet.sense.Text = System.Convert.ToString(this.sense);
                    cSheet.cr.Text = System.Convert.ToString(this.cr);
                    cSheet.xp.Text = System.Convert.ToString(this.xp);
                    cSheet.pC.IsChecked = this.pc;
                }
                else
                {
                    cSheet.names.Text = "";
                    cSheet.initMod.Text = "0";
                    cSheet.maxHP.Text = "0";
                    cSheet.inits.Text = "0";
                    cSheet.hP.Text = "0";
                    cSheet.fort.Text = "0";
                    cSheet.refl.Text = "0";
                    cSheet.will.Text = "0";
                    cSheet.ac.Text = "0";
                    cSheet.ab.Text = "0";
                    cSheet.ranged.Text = "0";
                    cSheet.spot.Text = "0";
                    cSheet.listen.Text = "0";
                    cSheet.sense.Text = "0";
                    cSheet.cr.Text = "0";
                    cSheet.xp.Text = "0";
                    cSheet.pC.IsChecked = false;
                }
            }
        }
        public string UpdateConditions()
        {
            string conditionInfo = "";
            if (conditions.Count > 0)
            {
                conditionInfo = this.nome + "'s Conditions: ";
                for(int i = 0 ; i < conditions.Count; i++)
                {
                    if (conditions[i].Update())
                    {
                        conditionInfo += String.Format("{1} {0} Finished | ", conditions[i].name, conditions[i].changeValue.ToString());
                        conditions.Remove(conditions[i]);
                    }
                    else
                    {
                        conditionInfo += String.Format("{1} {0} has {2} rounds left | ", conditions[i].name, conditions[i].changeValue.ToString(), conditions[i].duration.ToString());
                    }
                }
            }
            return conditionInfo;
        }
        public TempCondition NewCondition(ConditionType type, int amount, int duration)
        {
            TempCondition tempCondition = new TempCondition(type, duration, this, amount);
            conditions.Add(tempCondition);
            return tempCondition;
        }
        public void Clear()
        {
            this.nome = "";
            this.initMod = 0;
            this.maxHP = 0;
            this.init = 0;
            this.hp = 0;
            this.ac = 0;
            this.ab = 0;
            this.ranged = 0;
            this.fort = 0;
            this.refl = 0;
            this.will = 0;
            this.spot = 0;
            this.listen = 0;
            this.sense = 0;
        }
        public void RollInit()//int roll)
        {
            this.init = this.initMod + random.Next(1,21);
        }
        public void ResetInit()
        {
            this.init = this.initMod;
        }
        public void SetHP()
        {
           
            this.hp = this.maxHP;
        }
        
    }
}
