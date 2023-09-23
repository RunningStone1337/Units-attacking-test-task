using UnityEngine;

namespace Units
{
    /// <summary>
    /// ������, ����������� ����� ��������� ��������� ����� ����������.
    /// </summary>
    [SerializeField]
    public interface IAttackMomentEffect
    {
        void ApplyEffectTo(UnitModel target);
    }
}