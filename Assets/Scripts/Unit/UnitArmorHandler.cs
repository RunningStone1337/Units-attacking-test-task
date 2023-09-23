using Gameplay;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Units
{
    [Serializable]
    public class UnitArmorHandler : UnitComponentBase, IResetable
    {
        [SerializeField] private UnityEvent<int, int> onArmorValueChanged;
        [SerializeField, Range(0, 100)] private int tempArmour = 0;
        public const int MAX_ARMOR_VALUE = 100;
        public int Armor
        {
            get => tempArmour;
            set
            {
                tempArmour = TryRefreshValue(tempArmour, value, MAX_ARMOR_VALUE, onArmorValueChanged);
            }
        }

        public UnitArmorHandler(UnitModel unit, int armorValue = 0) : base(unit)
        {
            Armor = armorValue;
        }

        public void ResetValues()
        {
            Armor = 0;
        }
    }
}