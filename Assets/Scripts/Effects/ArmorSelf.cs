using System;

namespace Units
{
    /// <summary>
    /// +50 брони
    /// </summary>
    [Serializable]
    public class ArmorSelf : EffectBase, ICommand, ISelfTargetEffect
    {
        const int ARMOR_VALUE = 50;
        public ArmorSelf(UnitModel unit) : base(unit) { }

        public void ApplyEffect()
        {
            DoCommand();
        }
        public void DoCommand()
        {
            unit.Armor += ARMOR_VALUE;
        }

        public void UndoCommand()
        {
            unit.Armor -= ARMOR_VALUE;
        }
    }
}