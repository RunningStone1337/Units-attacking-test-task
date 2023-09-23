using System;
using UnityEngine;

namespace Units
{
    /// <summary>
    /// Броня -25, вампиризм +50
    /// </summary>
    [Serializable]
    public class VampirismSelf : AdditionTimeEffectBase
    {
        private const int ARMOR_CHANGE_VALUE = 25;
        private const int VAMPIRISM_CHANGE_VALUE = 50;
        private int armorToRestore;

        public VampirismSelf(UnitModel thisUnit, int effectDuration) : base(thisUnit, effectDuration)
        {
        }

        public override void ExecuteCommand()
        {
            unit.Vampirism += VAMPIRISM_CHANGE_VALUE;
            armorToRestore = Mathf.Min(ARMOR_CHANGE_VALUE, unit.Armor);
            unit.Armor -= ARMOR_CHANGE_VALUE;
        }

        public override void UndoCommand()
        {
            unit.Vampirism -= VAMPIRISM_CHANGE_VALUE;
            unit.Armor += armorToRestore;
        }
    }
}