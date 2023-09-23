using UnityEngine;

namespace Units
{
    /// <summary>
    /// Ёффект, примен€емый ѕќ—Ћ≈ нанесени€ основного урона противнику.
    /// </summary>
    [SerializeField]
    public interface IAttackMomentEffect
    {
        void ApplyEffectTo(UnitModel target);
    }
}