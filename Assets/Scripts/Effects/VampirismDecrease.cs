using System;

namespace Units
{
    /// <summary>
    /// Вампиризм противнику при атаке - 25
    /// </summary>
    [Serializable]
    public class VampirismDecrease : EffectBase, IAttackMomentEffect
    {
        private const int VAMPIRISM_DECREASE_VALUE = 25;

        public VampirismDecrease(UnitModel thisUnit, int effectDuration) : base(thisUnit, effectDuration)
        {
        }

        public void ApplyEffectTo(UnitModel target)
        {
            target.Vampirism -= VAMPIRISM_DECREASE_VALUE;
        }
    }
}