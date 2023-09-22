using Gameplay;
using UnityEngine;

namespace Units
{
    public class UnitModel : MonoBehaviour, IResetable
    {
        [SerializeField] UnitView thisView;

        #region unit stats
        [SerializeField] UnitAttackHandler attackHandler;
        [SerializeField] UnitHealthHandler healthHandler;
        [SerializeField] UnitArmorHandler armorHandler;
        [SerializeField] UnitVampyrismHandler vampyrismHandler;
        [SerializeField] UnitAbilitiesHandler abilitiesHandler;        
        #endregion

        public bool CanAttack => attackHandler.CanAttack;

        public int Armor { get => armorHandler.Armor; set => armorHandler.Armor = value; }
        public int Damage { get=>attackHandler.Damage; set=> attackHandler.Damage = value; }
        public int Vampirism { get => vampyrismHandler.Vampirism; set => vampyrismHandler.Vampirism = value; }

        public void ResetValues()
        {
            healthHandler.ResetValues();
            attackHandler.ResetValues();
            vampyrismHandler.ResetValues();
            armorHandler.ResetValues();
            abilitiesHandler.ResetValues();
        }
        private void Awake()
        {
            attackHandler = new(this);
            healthHandler = new(this);
            vampyrismHandler = new(this);
            armorHandler = new(this);
            abilitiesHandler = new(this);
        }

        public void ApplyAttackEffects(UnitModel target)
        {
            abilitiesHandler.ApplyAttackEffects(target);
        }

        public bool TryApplyRandomBuff()
        {
            return abilitiesHandler.TryApplyRandomBuff();
        }

        public void AttackTarget(UnitModel target)
        {
            attackHandler.AttackTarget(target);
          
        }
        public void AddHealth(int healthToRestore)
        {
            healthHandler.Health += healthToRestore;
        }
        public int CalculateHealthToRestore(int doneDamage)
        {
            return vampyrismHandler.CalculateVampyrism(doneDamage);
        }
        /// <summary>
        /// Возвращает реально нанесённый урон
        /// </summary>
        /// <param name="calculatedDamage"></param>
        /// <returns></returns>
        public int DealDamage(int calculatedDamage)
        {
            var tempHealth = healthHandler.Health;
            healthHandler.Health -= calculatedDamage;
            return tempHealth - healthHandler.Health;
        }
        internal bool TryAttack(UnitModel target)
        {
            if (CanAttack)
            {
                AttackTarget(target);
                return true;
            }
            return false;
        }
    }
}