using System;

namespace Units
{
    /// <summary>
    /// +50 брони
    /// </summary>
    [Serializable]
    public class ArmorSelf : AdditionTimeEffectBase
    {
        private const int ARMOR_VALUE = 50;

        public ArmorSelf(UnitModel unit, int effectDuration) : base(unit, effectDuration)
        {
        }

        public override void ExecuteCommand()
        {
            unit.Armor += ARMOR_VALUE;
        }

        public override void UndoCommand()
        {
            unit.Armor -= ARMOR_VALUE;
        }
    }
}