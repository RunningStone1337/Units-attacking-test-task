using System;
using System.Collections.Generic;
using Units;

namespace Gameplay
{
    [Serializable]
    public class GameRound
    {
        class UnitActionsHistory
        {
            Dictionary<LoopActionType, int> actionTypeCounts = new()
            {
                { LoopActionType.Attack, 0 }, 
                { LoopActionType.ApplyBuff, 0 }, 
            };

            public int this[LoopActionType key]
            {
                get => actionTypeCounts[key];
                set => actionTypeCounts[key] = value;
            }
        }

        Dictionary<UnitModel, UnitActionsHistory> unitsActiondDictionary;
        public bool ContainsActionsOfType(UnitModel unit, LoopActionType action)
        {
            if (unitsActiondDictionary.TryGetValue(unit, out UnitActionsHistory history))
            {
                if (history[action] > 0)
                    return true;
            }
            return false;
        }

        public void ApplyAction(LoopActionType action, UnitModel unit)
        {
            if (!unitsActiondDictionary.ContainsKey(unit))
                unitsActiondDictionary.Add(unit, new UnitActionsHistory());
            unitsActiondDictionary[unit][action]++;
        }
    }
}