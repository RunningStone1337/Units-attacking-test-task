using UnityEngine;

namespace Units
{
    /// <summary>
    /// ��������� ����� ��� ���������������� ���������� �������� � ��������.
    /// </summary>
    public abstract class EffectFactoryMethod : ScriptableObject
    {
        public abstract EffectBase CreateEffect(UnitModel unit, int effectDuration);
    }
}