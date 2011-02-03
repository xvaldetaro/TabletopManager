using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    public abstract class UndoableCommand
    {
        public static List<UndoableCommand> executedCommList = new List<UndoableCommand>();
        public static List<UndoableCommand> undoneCommList = new List<UndoableCommand>();
        public static void Undo()
        {
            if (executedCommList.Count > 0)
            {
                UndoableCommand previousComm = executedCommList[executedCommList.Count - 1];
                previousComm.Unexecute();
            }
        }
        public static void Redo()
        {
            if (undoneCommList.Count > 0)
            {
                redoing = true;
                UndoableCommand previousComm = undoneCommList[undoneCommList.Count - 1];
                previousComm.Execute();
                undoneCommList.Remove(previousComm);
            }
        }
        // Flag: in case redoing a list of commands, one does not want to clear the undone comm list.
        // in case of just executing one does want to clear it.
        private static bool redoing = false;
        public virtual void Execute()
        {
            executedCommList.Add(this);
            if (!redoing)
            {
                undoneCommList.Clear();
            }
            redoing = false;
        }
        public virtual void Unexecute()
        {
            executedCommList.Remove(this);
            undoneCommList.Add(this);
        }
    }
    public class CommCommandPackStarter : UndoableCommand
    {
        List<UndoableCommand> commandList;
        bool firstExecution;
        public CommCommandPackStarter(List<UndoableCommand> commandList)
        {
            firstExecution = true;
            this.commandList = commandList;
        }
        public override void Execute()
        {
            
            if(firstExecution)
            {
                base.Execute();
                foreach (UndoableCommand comm in commandList)
                {
                    comm.Execute();
                }
                CommCommandPackCloser packCloser = new CommCommandPackCloser(commandList.Count);
                packCloser.Execute();
                firstExecution = false;
            }
            else
            {
                executedCommList.Add(this);
                undoneCommList.Remove(this);
                foreach (UndoableCommand comm in commandList)
                {
                    UndoableCommand.Redo();
                }
                UndoableCommand.Redo();
            }        
        }
        public override void Unexecute()
        {
            base.Unexecute();
        }
    }
    public class CommCommandPackCloser : UndoableCommand
    {
        int numCommandsInPack;
        public CommCommandPackCloser(int numCommandsInPack)
        {
            this.numCommandsInPack = numCommandsInPack;
        }
        public override void Execute()
        {
            base.Execute();
        }
        public override void Unexecute()
        {
            base.Unexecute();
            for (int i = 0; i < numCommandsInPack; i++)
            {
                UndoableCommand.Undo();
            }
            UndoableCommand.Undo();
            
        }
    }
    public class CommAddCombatant : UndoableCommand
    {
        CombatTable combatTable;
        Combatant combatant;
        int combatantIndex;
        public CommAddCombatant(CombatTable combatTable,  Combatant combatant)
        {
            this.combatant = combatant;
            this.combatTable = combatTable;
        }
        public override void Execute()
        {
            combatantIndex = combatTable.Count;
            combatTable.Add(combatant);
            base.Execute();
        }
        public override void Unexecute()
        {
            combatTable.Remove(combatant);
            base.Unexecute();
        }
    }
    public class CommRemoveCombatant : UndoableCommand
    {
        CombatTable combatTable;
        Combatant combatant;
        int combatantIndex;
        public CommRemoveCombatant(CombatTable combatTable, Combatant combatant)
        {
            this.combatant = combatant;
            this.combatTable = combatTable;
        }
        public override void Execute()
        {
            combatantIndex = combatTable.IndexOf(combatant);
            combatTable.Remove(combatant);
            base.Execute();
        }
        public override void Unexecute()
        {
            combatTable.Insert(combatantIndex, combatant);
            base.Unexecute();
        }
    }
    public class CommRepositionCombatant : UndoableCommand
    {
        CombatTable combatTable;
        Combatant combatant;
        int combatantPreviousIndex;
        int combatantNewIndex;
        public CommRepositionCombatant(CombatTable combatTable, Combatant combatant, int shift)
        {
            this.combatant = combatant;
            this.combatTable = combatTable;
            combatantPreviousIndex = combatTable.IndexOf(combatant);
            combatantNewIndex = combatantPreviousIndex + shift;
        }
        public override void Execute()
        {
            if (combatantNewIndex >= 0 && combatantNewIndex < combatTable.Count && combatTable.Count > 1)
            {
                combatTable.Move(combatantPreviousIndex, combatantNewIndex);
                base.Execute();
            }
        }
        public override void Unexecute()
        {
            combatTable.Move(combatantNewIndex, combatantPreviousIndex);
            base.Unexecute();
        }
    }
    public class CommUpdateCombatant : UndoableCommand
    {
        Combatant combatant;
        object attributeNewValue;
        object attributeOldValue;
        CombatantAttributes attribute;
        public CommUpdateCombatant(Combatant combatant, CombatantAttributes attribute, object attributeNewValue)
        {
            this.combatant = combatant;
            this.attribute = attribute;
            this.attributeNewValue = attributeNewValue;
        }
        public override void Execute()
        {
            this.attributeOldValue = combatant.getAttribute(attribute);
            combatant.setAttribute(attribute, attributeNewValue);
            base.Execute();
        }
        public override void Unexecute()
        {
            this.attributeNewValue = combatant.getAttribute(attribute);
            combatant.setAttribute(attribute, attributeOldValue);
            base.Unexecute();
        }
    }
    public class CommReorderTable : UndoableCommand
    {
        CombatTable combatTable;
        IEnumerable<Combatant> previousSorting;
        IEnumerable<Combatant> nextSorting;
        public CommReorderTable(CombatTable combatTable, IEnumerable<Combatant> sortedCombatants)
        {
            this.combatTable = combatTable;
            this.previousSorting = combatTable.ToArray();
            this.nextSorting = sortedCombatants;
        }
        public override void Execute()
        {
            int count = combatTable.Count;
            for (int i = 0; i < count; i++)
            {
                Combatant combatant = nextSorting.ElementAt(i);
                combatTable.Remove(combatant);
                combatTable.Insert(i, combatant);
            }
            base.Execute();
        }
        public override void Unexecute()
        {
            int count = combatTable.Count;
            for (int i = 0; i < count; i++)
            {
                Combatant combatant = previousSorting.ElementAt(i);
                combatTable.Remove(combatant);
                combatTable.Insert(i, combatant);
            }
            base.Unexecute();
        }
    }
    public class CommStartEncounter : UndoableCommand
    {
        CombatTable table;
        public CommStartEncounter(CombatTable table)
        {
            this.table = table;
        }
        public override void Execute()
        {
            table.startEncounter();
            base.Execute();
        }
        public override void Unexecute()
        {
            table.finishEncounter();
            base.Unexecute();
        }
    }
    public class CommFinishEncounter : UndoableCommand
    {
        CombatTable table;
        Combatant currentCombatant;
        public CommFinishEncounter(CombatTable table)
        {
            this.table = table;
        }
        public override void Execute()
        {
            currentCombatant = table.getCurrent();
            table.finishEncounter();
            base.Execute();
        }
        public override void Unexecute()
        {
            table.startEncounter();
            table.setCurrent(currentCombatant);
            base.Unexecute();
        }
    }
    public class CommNextCombatant : UndoableCommand
    {
        CombatTable table;
        public CommNextCombatant(CombatTable table)
        {
            this.table = table;
        }
        public override void Execute()
        {
            table.nextCombatant();
            base.Execute();
        }
        public override void Unexecute()
        {
            table.previousCombatant();
            base.Unexecute();
        }
    }
    public class CommPreviousCombatant : UndoableCommand
    {
        CombatTable table;
        public CommPreviousCombatant(CombatTable table)
        {
            this.table = table;
        }
        public override void Execute()
        {
            table.previousCombatant();
            base.Execute();
        }
        public override void Unexecute()
        {
            table.nextCombatant();
            base.Unexecute();
        }
    }
    public class CommClearCombatTable : UndoableCommand
    {
        CombatTable table;
        IEnumerable<Combatant> prevTable;
        public CommClearCombatTable(CombatTable table)
        {
            this.table = table;
        }
        public override void Execute()
        {
            prevTable = table.ToArray();
            table.Clear();
            base.Execute();
        }
        public override void Unexecute()
        {
            foreach (Combatant combatant in prevTable)
            {
                table.Add(combatant);
            }
            base.Unexecute();
        }
    }
}
