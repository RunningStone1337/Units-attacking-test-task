using System;

namespace Units
{
    /// <summary>
    /// Броня -25, вампиризм +50
    /// </summary>
    [Serializable]
    public class VampirismSelf : EffectBase, ICommand, ISelfTargetEffect
    {
        const int VAMPIRISM_CHANGE_VALUE = 50;
        const int ARMOR_CHANGE_VALUE = 25;
        public VampirismSelf(UnitModel thisUnit) : base(thisUnit)
        {
        }

        public void ApplyEffect()
        {
            DoCommand();
        }

        public void DoCommand()
        {
            unit.Vampirism += VAMPIRISM_CHANGE_VALUE;
            unit.Armor -= ARMOR_CHANGE_VALUE;
        }

        public void UndoCommand()
        {
            unit.Vampirism -= VAMPIRISM_CHANGE_VALUE;
            unit.Armor += ARMOR_CHANGE_VALUE;
        }
    }
}