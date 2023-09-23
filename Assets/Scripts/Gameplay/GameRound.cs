using System;
using System.Collections.Generic;
using Units;

namespace Gameplay
{
    /// <summary>
    /// —щдержит информацию о конкретном игровом раунде:
    /// истори€ совершенных действий каждым игроком,
    /// пор€дковый номер раунда.
    /// </summary>
    [Serializable]
    public class GameRound
    {
        private int thisRoundNumber;

        private Dictionary<UnitModel, UnitActionsHistory> unitsActionsDictionary = new();

        private class UnitActionsHistory
        {
            private Dictionary<LoopActionType, int> actionTypeCounts = new()
            {
                { LoopActionType.Attack, 0 },
                { LoopActionType.ApplyEffect, 0 },
            };

            public int this[LoopActionType key]
            {
                get => actionTypeCounts[key];
                set => actionTypeCounts[key] = value;
            }
        }

        public int Number => thisRoundNumber;

        public GameRound(int roundNumber)
        {
            thisRoundNumber = roundNumber;
        }

        public void ApplyAction(LoopActionType action, UnitModel unit)
        {
            if (!unitsActionsDictionary.ContainsKey(unit))
                unitsActionsDictionary.Add(unit, new UnitActionsHistory());
            unitsActionsDictionary[unit][action]++;
        }

        public bool ContainsActionsOfType(UnitModel unit, LoopActionType action)
        {
            if (unitsActionsDictionary.TryGetValue(unit, out UnitActionsHistory history))
            {
                if (history[action] > 0)
                    return true;
            }
            return false;
        }

        public GameRound Next()
        {
            return new GameRound(thisRoundNumber + 1);
        }
    }
}