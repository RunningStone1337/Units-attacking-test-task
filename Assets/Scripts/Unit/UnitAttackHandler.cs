using Gameplay;
using System;
using UnityEngine;

namespace Units
{
    [Serializable]
    public class UnitAttackHandler : UnitComponentBase,IResetable
    {
        [SerializeField, Range(0, 100)] int unitDamage = 15;
        [SerializeField] bool canAttack;
        public UnitAttackHandler(UnitModel thisUnit, int baseDamage = 15) : base(thisUnit)
        {
            unitDamage = baseDamage;
        }

        public bool CanAttack { get => canAttack; private set => canAttack = value; }
        public int Damage { get=> unitDamage; set=> unitDamage = TryRefreshValue(unitDamage, value, int.MaxValue); }

        public void ResetValues()
        {
            Damage = 15;
        }

        public void AttackTarget(UnitModel target)
        {
            var calculatedDamage = CalculateAbsValueToDamage(target);//������� ���������� �������� ���������� ����� � ������ �����
            var doneDamage = target.DealDamage(calculatedDamage);//������� ����, �������� ������� ���������(����� ���� �������)
            var healthToRestore =  unit.CalculateHealthToRestore(doneDamage);//������� ���������� �������� ��� ��������������
            ///��������� ��������� �������
            unit.ApplyAttackEffects(target);
            unit.AddHealth(healthToRestore);//��������� ���������
        }

        private int CalculateAbsValueToDamage(UnitModel target)
        {
            var maxArmor = (float)UnitArmorHandler.MAX_ARMOR_VALUE;//abs value
            var damagePercentageToDeal = (maxArmor - target.Armor) / maxArmor;//% from base damage to deal
            var calculatedDamage = Mathf.RoundToInt(Damage * damagePercentageToDeal);
            return calculatedDamage;
        }
    }
}