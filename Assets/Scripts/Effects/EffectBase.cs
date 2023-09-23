using System;
using UnityEngine;

namespace Units
{
    /// <summary>
    /// Базовый эффект, которым может обладать юнит
    /// </summary>
    [Serializable]
    public abstract class EffectBase

    {
        [SerializeField] protected int duration;
        [SerializeField] protected UnitModel unit;
        public int Duration { get => duration; internal set => duration = value; }

        public EffectBase(UnitModel thisUnit, int effectDuration)
        {
            unit = thisUnit;
            duration = effectDuration;
        }
    }
}