using UnityEngine;

namespace Units
{
    [SerializeField]
    public interface IAttackMomentEffect
    {
        void ApplyEffectTo(UnitModel target);
    }
}