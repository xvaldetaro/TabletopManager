using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WpfApplication1
{

    public class CombatTable : ObservableCollection<Combatant>
    {
        Combatant currentCombatant;
        bool encounter;
        int turn;
        public void startEncounter()
        {
            if (!encounter)
            {
                turn = 0;
                encounter = true;
                setCurrent(0);
            }
        }
        public void finishEncounter()
        {
            if (encounter)
            {
                turn = 0;
                encounter = false;
                currentCombatant.Turn = false;
                currentCombatant = null;
            }
        }
        public void setCurrent( int index )
        {
            if (index < this.Count)
            {
                if (currentCombatant != null)
                    currentCombatant.Turn = false;
                currentCombatant = this.ElementAt(index);
                currentCombatant.Turn = true;
            }
        }
        public void setCurrent(Combatant combatant)
        {

            if (this.Contains(combatant))
            {
                if (currentCombatant != null)
                    currentCombatant.Turn = false;
                this.currentCombatant = combatant;
                currentCombatant.Turn = true;
            }
        }
        public Combatant getCurrent()
        {
            return currentCombatant;
        }
        public void nextCombatant()
        {
            int currentIndex = this.IndexOf(currentCombatant);
            if (currentIndex < this.Count-1)
                setCurrent(currentIndex + 1);
            else
                setCurrent(0);
        }
        public void previousCombatant()
        {
            int currentIndex = this.IndexOf(currentCombatant);
            if (currentIndex > 0)
                setCurrent(currentIndex - 1);
            else
                setCurrent(this.Count - 1);
        }
        public CombatTable()
            : base()
        {
        }
    }
}
