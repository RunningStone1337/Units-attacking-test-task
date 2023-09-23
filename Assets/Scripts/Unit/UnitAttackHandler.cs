using Gameplay;
using System;
using UnityEngine;

namespace Units
{
    [Serializable]
    public class UnitAttackHandler : UnitComponentBase, IResetable
    {
        [SerializeField, Range(1, 10)] private int attacksPerRound = 1;
        [SerializeField] private int attackTimesOnThisRound;
        [SerializeField, Range(0, 100)] private int unitDamage = 15;

        private int CalculateAbsValueToDamage(UnitModel target)
        {
            var maxArmor = (float)UnitArmorHandler.MAX_ARMOR_VALUE;//abs value
            var damagePercentageToDeal = (maxArmor - target.Armor);//% from base damage to deal
            var calculatedDamage = Mathf.RoundToInt(Damage * damagePercentageToDeal / 100f);
            return calculatedDamage;
        }

        public bool CanAttack { get => attacksPerRound > attackTimesOnThisRound; }

        public int Damage { get => unitDamage; set => unitDamage = TryRefreshValue(unitDamage, value, int.MaxValue); }

        public UnitAttackHandler(UnitModel thisUnit, int baseDamage = 15) : base(thisUnit)
        {
            unitDamage = baseDamage;
        }

        public void AttackTarget(UnitModel target)
        {
            var calculatedDamage = CalculateAbsValueToDamage(target);//считаем абсолютное значение наносимого урона с учётом брони
            var doneDamage = target.DealDamage(calculatedDamage);//наносим урон, получаем реально нанесённый(может быть оверхед)
            var healthToRestore = unit.CalculateHealthToRestore(doneDamage);//считаем абсолютное здоровья для восстановления
            ///применить возможные эффекты
            unit.ApplyAttackEffects(target);
            unit.AddHealth(healthToRestore);//применяем вампиризм
            attackTimesOnThisRound++;
        }

        public void OnNewRoundStarted()
        {
            attackTimesOnThisRound = default;
        }

        public void ResetValues()
        {
            Damage = 15;
            attackTimesOnThisRound = default;
        }
    }
}