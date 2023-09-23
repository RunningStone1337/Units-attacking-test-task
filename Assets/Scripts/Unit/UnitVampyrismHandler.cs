using Gameplay;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    /// <summary>
    /// Подсистема управления механикой вампиризма юнита.
    /// </summary>
    [Serializable]
    public class UnitVampyrismHandler : UnitComponentBase, IResetable
    {
        [SerializeField] private UnityEvent<int, int> onVampyrismValueChanged;
        [SerializeField, Range(0, 100)] private int tempVampirism = 0;
        public const int MAX_VAMPYRISM_VALUE = 100;
        public int Vampirism
        {
            get => tempVampirism;
            set
            {
                tempVampirism = TryRefreshValue(tempVampirism, value, MAX_VAMPYRISM_VALUE, onVampyrismValueChanged);
            }
        }

        public UnitVampyrismHandler(UnitModel thisUnit, int tempValue = 0) : base(thisUnit)
        {
            Vampirism = tempValue;
        }

        public int CalculateVampyrism(int doneDamage)
        {
            return Mathf.RoundToInt(doneDamage * (float)Vampirism / MAX_VAMPYRISM_VALUE);
        }

        public void ResetValues()
        {
            Vampirism = 0;
        }
    }
}