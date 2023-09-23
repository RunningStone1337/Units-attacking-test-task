using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "ArmorSelfEfeectFactory", menuName = "Factories/ArmorSelfEfeectFactory")]
    public class ArmorSelfEffectFactory : EffectFactoryMethod
    {
        public override EffectBase CreateEffect(UnitModel unit, int effectDuration)
        {
            return new ArmorSelf(unit, effectDuration);
        }
    }
}