using System;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    /// <summary>
    /// ������� ����� ���������� �����: ��������, �����, �����, ����������, etc
    /// </summary>
    [Serializable]
    public abstract class UnitComponentBase 
    {
        [SerializeField] protected UnitModel unit;
        protected UnitComponentBase(UnitModel thisUnit)
        {
            unit = thisUnit;
        }

        /// <summary>
        /// ���������� �������� ���� ����� ���������� �� ������� � �������� �������
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="newValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="changedValueEvent"></param>
        /// <returns></returns>
        protected int TryRefreshValue(int currentValue, int newValue, int maxValue, UnityEvent<int> changedValueEvent = default)
        {
            newValue = Mathf.Clamp(newValue, 0, maxValue);
            if (newValue != currentValue)
                changedValueEvent?.Invoke(newValue);
            return newValue;
        }
    }
}