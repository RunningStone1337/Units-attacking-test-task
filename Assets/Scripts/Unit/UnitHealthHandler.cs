using Gameplay;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    /// <summary>
    /// Обработчик уровня здоровья юнита.
    /// </summary>
    [Serializable]
    public class UnitHealthHandler : UnitComponentBase, IResetable
    {
        private const int HEALTH_MAX_VALUE = 100;
        [SerializeField] private UnityEvent<int, int> onHealthValueChanged;
        [SerializeField, Range(0, 100)] private int tempHealth = HEALTH_MAX_VALUE;
        public int Health
        {
            get => tempHealth;
            set
            {
                tempHealth = TryRefreshValue(tempHealth, value, HEALTH_MAX_VALUE, onHealthValueChanged);
            }
        }

        public UnitHealthHandler(UnitModel unitModel, int health = HEALTH_MAX_VALUE) : base(unitModel)
        {
            Health = health;
        }

        public void ResetValues()
        {
            Health = HEALTH_MAX_VALUE;
        }
    }
}