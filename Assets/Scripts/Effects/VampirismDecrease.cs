using System;

namespace Units
{
    /// <summary>
    /// Вампиризм противнику при атаке - 25
    /// </summary>
    [Serializable]
    public class VampirismDecrease : EffectBase, IAttackMomentEffect
    {
        const int VAMPIRISM_DECREASE_VALUE = 25;
        public VampirismDecrease(UnitModel thisUnit) : base(thisUnit) { }
        public void ApplyEffectTo(UnitModel target)
        {
            target.Vampirism -= VAMPIRISM_DECREASE_VALUE;
        }
    }
}