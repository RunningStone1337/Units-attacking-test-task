using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "VampirismDecreaseEffectFactory", menuName = "Factories/VampirismDecreaseEffectFactory")]
    public class VampirismDecreaseEffectFactory : EffectFactoryMethod
    {
        public override EffectBase CreateEffect(UnitModel unit, int effectDuration)
        {
            return new VampirismDecrease(unit, effectDuration);
        }
    }
}