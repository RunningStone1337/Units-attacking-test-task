using System;
using UnityEngine;

namespace Units
{
    [Serializable]
    public class EffectBase
        
    {
        [SerializeField] protected int abilityDuration;
        [SerializeField] protected UnitModel unit;
        public EffectBase(UnitModel thisUnit)
        {
            unit = thisUnit;
        }
    }
}