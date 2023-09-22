using Gameplay;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    [Serializable]
    public class UnitVampyrismHandler : UnitComponentBase,IResetable
    {
        [SerializeField, Range(0, 100)] int tempVampirism = 0;
        [SerializeField] UnityEvent<int> onVampyrismValueChanged;
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

        public void ResetValues()
        {
            Vampirism = 0;
        }

        public int CalculateVampyrism(int doneDamage)
        {
            return Mathf.RoundToInt(doneDamage * (float)Vampirism / MAX_VAMPYRISM_VALUE);
        }
    }
}