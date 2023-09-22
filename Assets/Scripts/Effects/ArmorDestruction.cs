using System;

namespace Units
{
    /// <summary>
    /// Броня при атаке -10
    /// </summary>
    [Serializable]
    public class ArmorDestruction : EffectBase, IAttackMomentEffect
    {
        const int ARMOR_DECREASE_VALUE = 10;
        public ArmorDestruction(UnitModel thisUnit) : base(thisUnit) { }
        public void ApplyEffectTo(UnitModel target)
        {
            target.Armor -= ARMOR_DECREASE_VALUE;
        }
    }
}