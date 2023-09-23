using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "VampirismSelfEffectFactory", menuName = "Factories/VampirismSelfEffectFactory")]
    public class VampirismSelfEffectFactory : EffectFactoryMethod
    {
        public override EffectBase CreateEffect(UnitModel unit, int effectDuration)
        {
            return new VampirismSelf(unit, effectDuration);
        }
    }
}