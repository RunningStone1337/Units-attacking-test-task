using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "DoubleDamageEffectFactory", menuName = "Factories/DoubleDamageEffectFactory")]
    public class DoubleDamageEffectFactory : EffectFactoryMethod
    {
        public override EffectBase CreateEffect(UnitModel unit, int effectDuration)
        {
            return new DoubleDamage(unit, effectDuration);
        }
    }
}