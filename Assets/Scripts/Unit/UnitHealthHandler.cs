using Gameplay;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    [Serializable]
    public class UnitHealthHandler : UnitComponentBase, IResetable
    {
        [SerializeField, Range(0, 100)] int tempHealth = HEALTH_MAX_VALUE;
        [SerializeField] UnityEvent<int> onHealthValueChanged;
        const int HEALTH_MAX_VALUE = 100;

        public UnitHealthHandler(UnitModel unitModel, int health = HEALTH_MAX_VALUE) : base(unitModel)
        {
            Health = health;
        }

        public int Health
        {
            get => tempHealth;
            set
            {
                tempHealth = TryRefreshValue(tempHealth, value, HEALTH_MAX_VALUE, onHealthValueChanged);
            }
        }

        public void ResetValues()
        {
            Health = HEALTH_MAX_VALUE;
        }
    }
}