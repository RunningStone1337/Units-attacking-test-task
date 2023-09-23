using UnityEngine;

namespace Units
{
    /// <summary>
    /// Фабричный метод для инстанциирования конкретных эффектов в рантайме.
    /// </summary>
    public abstract class EffectFactoryMethod : ScriptableObject
    {
        public abstract EffectBase CreateEffect(UnitModel unit, int effectDuration);
    }
}