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
        float xP;
        float gold;
        float load;
        float loadProportion;
        bool turn;
        bool isNPC;

        ObservableCollection<Skill> skills;
        ObservableCollection<Item> items;
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
        public event EventHandler LoadChanged;
        private void OnLoadChanged()
        {
            if (LoadChanged != null)
                LoadChanged(this, EventArgs.Empty);
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
        public event EventHandler FormattedHPChanged;
        private void OnFormattedHPChanged()
        {
            if (FormattedHPChanged != null)
                FormattedHPChanged(this, EventArgs.Empty);
        }
        public event EventHandler LoadColorChanged;
        private void OnLoadColorChanged()
        {
            if (LoadColorChanged != null)
                LoadColorChanged(this, EventArgs.Empty);
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
        public string FormattedHP
        {
            get { return hP.ToString() + "/" + maxHP.ToString() ; }
        }
        public float HP
        {
            get { return hP; }
            set
            {
                hP = value;
                OnHPChanged();
                OnHPColorChanged();
                OnFormattedHPChanged();
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
                OnFormattedHPChanged();
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
        public string Load
        {
            get 
            { 
                float x = abilities[0];
                float maxLoad = (0.00105364251f * x * x * x * x) - (0.02295160962f * x * x * x) + (0.262456409f * x * x) + (1.989551162f * x) + 1.461694726f;
                loadProportion = load / maxLoad;
                if (loadProportion < 1)
                    return "Light";
                else if (loadProportion >= 1 && loadProportion < 2)
                    return "Medium";
                else
                    return "Heavy";
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
                    return "LightBlue";
                return "Blue";
            }
        }
        public string HPColor
        {
            get
            {
                float hPPercentage = hP/maxHP;
                if (hPPercentage > 0.6f)
                    return "White";
                else if (hPPercentage > 0.3f)
                    return "Yellow";
                else
                    return "Red";
            }
        }
        public string LoadColor
        {
            get
            {
                if (loadProportion < 1.0f)
                    return "White";
                else if (loadProportion >= 1.0f && loadProportion < 2.0f)
                    return "Yellow";
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
            set
            {
                skills = value;
            }
        }
        public ObservableCollection<Item> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                items = value;
            }
        }
        public ObservableCollection<string> Feats
        {
            get
            {
                return this.feats;
            }
            set
            {
                feats = value;
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
            set { 
                abilities[0] = value;
                OnLoadChanged();
                OnLoadColorChanged();
            }
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

        #region constructors and init
        private void enableCompleteCharacter()
        {
            load = 0;
            loadProportion = 0;
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
            items = new ObservableCollection<Item>();
            feats = new ObservableCollection<string>();
        }
        public Combatant(string cName, string pName, float hp, float initiative, float aC, float aB, float maxHP,
                            float initMod, float fort, float refl, float will, float listen, float sense, float spot, bool isNPC)
        {

            enableCompleteCharacter();
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
        public Combatant(string name, bool enableComplete)
        {
            enableCompleteCharacter();
            this.cName = name;
        }
        public Combatant Clone()
        {
            return new Combatant(cName, pName, hP, initiative, aC, aB, maxHP,
                            initMod, fort, refl, will, skills[(int)eSkills.Listen].SkillRank, skills[(int)eSkills.Sense_Motive].SkillRank, skills[(int)eSkills.Spot].SkillRank, isNPC);
        }
        #endregion

        #region Collections Getters and Setters
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
                    setSkillRank(eSkills.Listen, (int)value);
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
        public void addItem(Item item)
        {
            items.Add(item);
            load += item.WeightPounds;
            OnLoadChanged();
            OnLoadColorChanged();
        }
        public void removeItem(Item item)
        {
            items.Remove(item);
            load -= item.WeightPounds;
            OnLoadChanged();
            OnLoadColorChanged();
        }
        public void removeItem(int index)
        {
            removeItem(items[index]);
        }
        #endregion
    }

    
}
