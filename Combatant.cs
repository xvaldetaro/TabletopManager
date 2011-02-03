using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
    public enum CombatantAttributes
    {
         cName,  pName,  hp,  initiative,  aC,  aB,  maxHP,
                             initMod,  fort,  refl,  will,  listen,  sense,  spot, isNPC
        ,turn, xp, gold, skills, abilities
    }
    public class Combatant
    {
        #region Members
        string cName;
        string pName;
        float hP;
        float initiative;
        float aC;
        float aB;
        float maxHP;
        float initMod;
        float fort;
        float refl;
        float will;
        float listen;
        float sense;
        float spot;
        float xP;
        float gold;
        bool turn;
        bool isNPC;

        bool isComplete = false;
        ObservableCollection<Skill> skills;
        ObservableCollection<string> items;
        ObservableCollection<string> feats;
        string notes;
        int[] abilities;
        #endregion

        #region events
        public event EventHandler CNameChanged;
        private void OnCNameChanged()
        {
            if (CNameChanged != null)
                CNameChanged(this, EventArgs.Empty);
        }
        public event EventHandler PNameChanged;
        private void OnPNameChanged()
        {
            if (PNameChanged != null)
                PNameChanged(this, EventArgs.Empty);
        }
        public event EventHandler HPChanged;
        private void OnHPChanged()
        {
            if (HPChanged != null)
                HPChanged(this, EventArgs.Empty);
        }
        public event EventHandler InitiativeChanged;
        private void OnInitiativeChanged()
        {
            if (InitiativeChanged != null)
                InitiativeChanged(this, EventArgs.Empty);
        }
        public event EventHandler ACChanged;
        private void OnACChanged()
        {
            if (ACChanged != null)
                ACChanged(this, EventArgs.Empty);
        }
        public event EventHandler ABChanged;
        private void OnABChanged()
        {
            if (ABChanged != null)
                ABChanged(this, EventArgs.Empty);
        }
        public event EventHandler MaxHPChanged;
        private void OnMaxHPChanged()
        {
            if (MaxHPChanged != null)
                MaxHPChanged(this, EventArgs.Empty);
        }
        public event EventHandler InitModChanged;
        private void OnInitModChanged()
        {
            if (InitModChanged != null)
                InitModChanged(this, EventArgs.Empty);
        }
        public event EventHandler FortChanged;
        private void OnFortChanged()
        {
            if (FortChanged != null)
                FortChanged(this, EventArgs.Empty);
        }
        public event EventHandler ReflChanged;
        private void OnReflChanged()
        {
            if (ReflChanged != null)
                ReflChanged(this, EventArgs.Empty);
        }
        public event EventHandler WillChanged;
        private void OnWillChanged()
        {
            if (WillChanged != null)
                WillChanged(this, EventArgs.Empty);
        }
        public event EventHandler ListenChanged;
        private void OnListenChanged()
        {
            if (ListenChanged != null)
                ListenChanged(this, EventArgs.Empty);
        }
        public event EventHandler SenseChanged;
        private void OnSenseChanged()
        {
            if (SenseChanged != null)
                SenseChanged(this, EventArgs.Empty);
        }
        public event EventHandler SpotChanged;
        private void OnSpotChanged()
        {
            if (SpotChanged != null)
                SpotChanged(this, EventArgs.Empty);
        }
        public event EventHandler isNPCChanged;
        private void OnIsNPCChanged()
        {
            if (isNPCChanged != null)
                isNPCChanged(this, EventArgs.Empty);
        }
        public event EventHandler InnerColorChanged;
        private void OnInnerColorChanged()
        {
            if (InnerColorChanged != null)
                InnerColorChanged(this, EventArgs.Empty);
        }
        public event EventHandler HPColorChanged;
        private void OnHPColorChanged()
        {
            if (HPColorChanged != null)
                HPColorChanged(this, EventArgs.Empty);
        }
        public event EventHandler XPChanged;
        private void OnXPChanged()
        {
            if (XPChanged != null)
                XPChanged(this, EventArgs.Empty);
        }
        public event EventHandler GoldChanged;
        private void OnGoldChanged()
        {
            if (GoldChanged != null)
                GoldChanged(this, EventArgs.Empty);
        }
        public event EventHandler TurnChanged;
        private void OnTurnChanged()
        {
            if (TurnChanged != null)
                TurnChanged(this, EventArgs.Empty);
        }
        public event EventHandler TurnColorChanged;
        private void OnTurnColorChanged()
        {
            if (TurnColorChanged != null)
                TurnColorChanged(this, EventArgs.Empty);
        }
        #endregion

        #region Getters and Setters
        public string CName
        {
            get { return cName; }
            set
            {
                cName = value;
                OnCNameChanged();
            }
        }
        public string PName
        {
            get { return pName; }
            set
            {
                pName = value;
                OnPNameChanged();
            }
        }
        public float HP
        {
            get { return hP; }
            set
            {
                hP = value;
                OnHPChanged();
                OnHPColorChanged();
            }
        }
        public float Initiative
        {
            get { return initiative; }
            set
            {
                initiative = value;
                OnInitiativeChanged();
            }
        }
        public float AC
        {
            get { return aC; }
            set
            {
                aC = value;
                OnACChanged();
            }
        }
        public float AB
        {
            get { return aB; }
            set
            {
                aB = value;
                OnABChanged();
            }
        }
        public float MaxHP
        {
            get { return maxHP; }
            set
            {
                maxHP = value;
                OnMaxHPChanged();
            }
        }
        public float InitMod
        {
            get { return initMod; }
            set
            {
                initMod = value;
                OnInitModChanged();
            }
        }
        public float Fort
        {
            get { return fort; }
            set
            {
                fort = value;
                OnFortChanged();
            }
        }
        public float Refl
        {
            get { return refl; }
            set
            {
                refl = value;
                OnReflChanged();
            }
        }
        public float Will
        {
            get { return will; }
            set
            {
                will = value;
                OnWillChanged();
            }
        }
        public float Listen
        {
            get { return getSkillRank(eSkills.Listen); }
            set
            {
                setSkillRank(eSkills.Listen, (int)value);
            }
        }
        public float Sense
        {
            get { return getSkillRank(eSkills.Sense_Motive); }
            set
            {
                setSkillRank(eSkills.Sense_Motive, (int)value);
            }
        }
        public float Spot
        {
            get { return getSkillRank(eSkills.Spot); }
            set
            {
                setSkillRank(eSkills.Spot, (int)value);
            }
        }
        public bool IsNPC
        {
            get { return isNPC; }
            set
            {
                isNPC = value;
                OnIsNPCChanged();
                OnInnerColorChanged();
            }
        }
        public float XP
        {
            get { return xP; }
            set
            {
                xP = value;
                OnXPChanged();
            }
        }
        public float Gold
        {
            get { return gold; }
            set
            {
                gold = value;
                OnGoldChanged();
            }
        }
        public bool Turn
        {
            get { return turn; }
            set
            {
                turn = value;
                OnTurnChanged();
                OnInnerColorChanged();
            }
        }
        public string InnerColor
        {
            get
            {
                if (isNPC)
                {
                    if (turn)
                        return "LightSalmon";
                    return "Brown";
                }
                if (turn)
                    return "LimeGreen";
                return "Green";
            }
        }
        public string HPColor
        {
            get
            {
                float hPPercentage = hP/maxHP;
                if (hPPercentage > 0.6f)
                    return "Green";
                else if (hPPercentage > 0.3f)
                    return "Orange";
                else
                    return "Red";
            }
        }
        public string TurnColor
        {
            get
            {
                if (turn)
                    return "BlueViolet";
                else
                    return "Transparent";
            }
        }
        public ObservableCollection<Skill> Skills
        {
            get
            {
                return this.skills;
            }
        }
        public ObservableCollection<string> Items
        {
            get
            {
                return this.items;
            }
        }
        public ObservableCollection<string> Feats
        {
            get
            {
                return this.feats;
            }
        }
        public string Notes
        {
            get
            {
                return this.notes;
            }
            set
            {
                this.notes = value;
            }
        }
        public int AbilitySTR
        {
            get { return abilities[0]; }
            set { abilities[0] = value; }
        }
        public int AbilityDEX
        {
            get { return abilities[1]; }
            set { abilities[1] = value; }
        }
        public int AbilityCON
        {
            get { return abilities[2]; }
            set { abilities[2] = value; }
        }
        public int AbilityINT
        {
            get { return abilities[3]; }
            set { abilities[3] = value; }
        }
        public int AbilityWIS
        {
            get { return abilities[4]; }
            set { abilities[4] = value; }
        }
        public int AbilityCHA
        {
            get { return abilities[5]; }
            set { abilities[5] = value; }
        }
        #endregion

        #region constructors
        public Combatant(string cName, string pName, float hp, float initiative, float aC, float aB, float maxHP,
                            float initMod, float fort, float refl, float will, float listen, float sense, float spot, bool isNPC)
        {
            this.cName = cName;
            this.pName = pName;
            this.hP = hp;
            this.initiative = initiative;
            this.aC = aC;
            this.aB = aB;
            this.maxHP = maxHP;
            this.initMod = initMod;
            this.fort = fort;
            this.refl = refl;
            this.will = will;
            setSkillRank(eSkills.Listen, (int)listen);
            setSkillRank(eSkills.Sense_Motive, (int)sense);
            setSkillRank(eSkills.Spot, (int)spot);
            this.isNPC = isNPC;
            this.xP = 0.0f;
            this.Gold = 0.0f;
            this.turn = false;
            enableCompleteCharacter();
        }
        public Combatant(string cName, string pName, string hp, string initiative, string aC, string aB, string maxHP,
                            string initMod, string fort, string refl, string will, string listen, string sense, string spot, bool isNPC)
        {
            enableCompleteCharacter();
            this.cName = cName;
            this.pName = pName;
            this.hP = App.getFloatFromString(hp);
            this.initiative = App.getFloatFromString(initiative);
            this.aC = App.getFloatFromString(aC);
            this.aB = App.getFloatFromString(aB);
            this.maxHP = App.getFloatFromString(maxHP);
            this.initMod = App.getFloatFromString(initMod);
            this.fort = App.getFloatFromString(fort);
            this.refl = App.getFloatFromString(refl);
            this.will = App.getFloatFromString(will);
            setSkillRank(eSkills.Listen, (int)App.getFloatFromString(listen));
            setSkillRank(eSkills.Sense_Motive, (int)App.getFloatFromString(sense));
            setSkillRank(eSkills.Spot, (int)App.getFloatFromString(spot));
            this.isNPC = isNPC;
            this.xP = 0.0f;
            this.Gold = 0.0f;
            this.turn = false;

        }
        public Combatant(string savedString)
        {
            enableCompleteCharacter();
            string[] loadedLine = savedString.Split('¨');
            if (App.getFloatFromString(loadedLine[0]) == 1)
                IsNPC = false;
            else
                IsNPC = true;
            CName = loadedLine[1];
            PName = loadedLine[2];
            HP = App.getFloatFromString(loadedLine[3]);
            Initiative = App.getFloatFromString(loadedLine[4]);
            AC = App.getFloatFromString( loadedLine[5]);
            AB = App.getFloatFromString(loadedLine[6]);
            MaxHP = App.getFloatFromString(loadedLine[7]);
            InitMod = App.getFloatFromString(loadedLine[8]);
            Fort = App.getFloatFromString(loadedLine[9]);
            Refl = App.getFloatFromString(loadedLine[10]);
            Will = App.getFloatFromString(loadedLine[11]);
            XP = App.getFloatFromString(loadedLine[12]);
            Gold = App.getFloatFromString(loadedLine[13]);
            notes = loadedLine[14];
            fillSkillsFromString(loadedLine[15]);
            fillAbilitiesFromString(loadedLine[16]);
            fillItemsFromString(loadedLine[17]);
            fillFeatsFromString(loadedLine[18]);
            
        }
        #endregion

        public object getAttribute(CombatantAttributes attribute)
        {
            switch (attribute)
            {
                case CombatantAttributes.cName:
                    return CName;
                case CombatantAttributes.pName:
                    return PName;               
                case CombatantAttributes.hp:
                    return HP;                   
                case CombatantAttributes.initiative:
                    return Initiative;                   
                case CombatantAttributes.aC:
                    return AC;                   
                case CombatantAttributes.aB:
                    return AB;                   
                case CombatantAttributes.maxHP:
                    return MaxHP;                   
                case CombatantAttributes.initMod:
                    return InitMod;                   
                case CombatantAttributes.fort:
                    return Fort;                   
                case CombatantAttributes.refl:
                    return Refl;                    
                case CombatantAttributes.will:
                    return Will;                   
                case CombatantAttributes.listen:
                    return getSkillRank(eSkills.Listen);                    
                case CombatantAttributes.sense:
                    return getSkillRank(eSkills.Sense_Motive);                   
                case CombatantAttributes.spot:
                    return getSkillRank(eSkills.Spot);
                case CombatantAttributes.isNPC:
                    return IsNPC;
                case CombatantAttributes.gold:
                    return Gold;
                case CombatantAttributes.xp:
                    return XP;
                    
                default:
                    return null;
                    
            }
        }
        public void setAttribute(CombatantAttributes attribute, object value)
        {
            switch (attribute)
            {
                case CombatantAttributes.cName:
                    CName = (string)value;
                    break;
                case CombatantAttributes.pName:
                    PName = (string)value;
                    break;
                case CombatantAttributes.hp:
                    HP = (float)value;
                    break;
                case CombatantAttributes.initiative:
                    Initiative = (float)value;
                    break;
                case CombatantAttributes.aC:
                    AC = (float)value;
                    break;
                case CombatantAttributes.aB:
                    AB = (float)value;
                    break;
                case CombatantAttributes.maxHP:
                    MaxHP = (float)value;
                    break;
                case CombatantAttributes.initMod:
                    InitMod = (float)value;
                    break;
                case CombatantAttributes.fort:
                    Fort = (float)value;
                    break;
                case CombatantAttributes.refl:
                    Refl = (float)value;
                    break;
                case CombatantAttributes.will:
                    Will = (float)value;
                    break;
                case CombatantAttributes.listen:
                    setSkillRank(eSkills.Listen,(int)value);
                    break;
                case CombatantAttributes.sense:
                    setSkillRank(eSkills.Sense_Motive, (int)value);
                    break;
                case CombatantAttributes.spot:
                    setSkillRank(eSkills.Spot, (int)value);
                    break;
                case CombatantAttributes.isNPC:
                    IsNPC = (bool)value;
                    break;
                case CombatantAttributes.gold:
                    Gold = (float)value;
                    break;
                case CombatantAttributes.xp:
                    XP = (float)value;
                    break;
                default:
                    break;
            }
        }
        private void enableCompleteCharacter()
        {
            isComplete = true;
            abilities = new int[6];
            for (int i = 0; i < 6; i++)
			{
                abilities[i] = 10;
            }
            skills = new ObservableCollection<Skill>();
            for (int i = 0; i <= (int)eSkills.Use_Rope; i++)
            {
                skills.Add(new Skill((eSkills)i, 0));
            }
            items = new ObservableCollection<string>();
            feats = new ObservableCollection<string>();
        }
        private void fillSkillsFromString(string skillData)
        {
            string[] skillInfoArray = skillData.Split('|');
            for (int i = 0; i < skillInfoArray.Count(); i++)
            {
                skills[i].SkillRank = (int)App.getFloatFromString(skillInfoArray[i]);
            }
        }
        private void fillItemsFromString(string itemsData)
        {
            if (itemsData.Length > 1)
            {
                string[] itemsDataArray = itemsData.Split('|');
                for (int i = 0; i < itemsDataArray.Count(); i++)
                {
                    items.Add(itemsDataArray[i]);
                }
            }
        }
        private void fillFeatsFromString(string featsData)
        {
            if (featsData.Length > 1)
            {
                string[] featsDataArray = featsData.Split('|');
                for (int i = 0; i < featsDataArray.Count(); i++)
                {
                    feats.Add(featsDataArray[i]);
                }
            }
        }
        private void fillAbilitiesFromString(string abilityData)
        {
            string[] abilityDataArray = abilityData.Split('|');
            for (int i = 0; i < abilityDataArray.Count(); i++)
            {
                abilities[i] = (int)App.getFloatFromString(abilityDataArray[i]);
            }
        }
        public void setSkillRank(eSkills skill, int rank)
        {
            if (skill == eSkills.Listen || skill == eSkills.Sense_Motive || skill == eSkills.Spot)
            {
                OnListenChanged();
                OnSpotChanged();
                OnSenseChanged();
            }
            skills[(int)skill].SkillRank = rank;
        }
        public int getSkillRank(eSkills skill)
        {
            return skills[(int)skill].SkillRank;
        }
        public override string ToString()
        {
            string isNpcWritten;
            if (isNPC)
                isNpcWritten = "0";
            else
                isNpcWritten = "1";
            string advString =  isNpcWritten + "¨" + cName + "¨" + pName + "¨" + hP.ToString() + "¨" + initiative.ToString() + "¨" + aC.ToString() + "¨" + aB.ToString() + "¨" + maxHP.ToString()
                             + "¨" + initMod.ToString() + "¨" + fort.ToString() + "¨" + refl.ToString() + "¨" + will.ToString() + "¨" + ((int)XP).ToString() + "¨" + ((int)Gold).ToString() + "¨" + notes;
            advString += "¨" + skills[0].SkillRank.ToString();
            for (int i = 1; i < skills.Count; i++)
            {
                advString +=  "|" + skills[i].SkillRank.ToString();
            }
            advString += "¨" + abilities[0];
            for (int i = 1; i < abilities.Count(); i++)
            {
                advString += "|" + abilities[i].ToString();
            }
            advString += "¨";
            if (items.Count > 0)
            {
                advString += items[0];
                for (int i = 1; i < items.Count; i++)
                {
                    advString += "|" + items[i];
                }
            }
            advString += "¨";
            if (feats.Count > 0)
            {
                advString += feats[0];
                for (int i = 1; i < feats.Count; i++)
                {
                    advString += "|" + feats[i];
                }
            }
            return advString;
        }
    }

    
}
