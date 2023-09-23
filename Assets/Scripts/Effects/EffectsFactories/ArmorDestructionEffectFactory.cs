using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "ArmorDestructionEffectFactory", menuName = "Factories/ArmorDestructionEffectFactory")]
    public class ArmorDestructionEffectFactory : EffectFactoryMethod
    {
        public override EffectBase CreateEffect(UnitModel unit, int effectDuration)
        {
            return new ArmorDestruction(unit, effectDuration);
        }
    }
}