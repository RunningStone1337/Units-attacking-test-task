using Gameplay;
using UnityEngine;

namespace Units
{
    /// <summary>
    /// Интерфейс взаимодействия с юнитом через его компоненты.
    /// </summary>
    public class UnitModel : MonoBehaviour, IResetable
    {
        [SerializeField] private UnitView thisView;

        #region unit stats

        [SerializeField] private UnitArmorHandler armorHandler;
        [SerializeField] private UnitAttackHandler attackHandler;
        [SerializeField] private UnitEffectsHandler effectssHandler;
        [SerializeField] private UnitHealthHandler healthHandler;
        [SerializeField] private UnitVampyrismHandler vampyrismHandler;

        #endregion unit stats

        internal bool TryAttack(UnitModel target)
        {
            if (CanAttack)
            {
                AttackTarget(target);
                return true;
            }
            return false;
        }

        public int Armor { get => armorHandler.Armor; set => armorHandler.Armor = value; }
        public bool CanAttack => attackHandler.CanAttack;
        public int Damage { get => attackHandler.Damage; set => attackHandler.Damage = value; }
        public int Health => healthHandler.Health;
        public int Vampirism { get => vampyrismHandler.Vampirism; set => vampyrismHandler.Vampirism = value; }

        public void AddHealth(int healthToRestore)
        {
            healthHandler.Health += healthToRestore;
        }

        public void ApplyAttackEffects(UnitModel target)
        {
            effectssHandler.ApplyAttackEffects(target);
        }

        public void AttackTarget(UnitModel target)
        {
            attackHandler.AttackTarget(target);
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
            thisView.OnDamageTaked();
            return tempHealth - healthHandler.Health;
        }

        public void OnNewRoundStarted()
        {
            attackHandler.OnNewRoundStarted();
            effectssHandler.OnNewRoundStarted();
        }

        public void ResetValues()
        {
            healthHandler.ResetValues();
            attackHandler.ResetValues();
            vampyrismHandler.ResetValues();
            armorHandler.ResetValues();
            effectssHandler.ResetValues();
        }

        public bool TryApplyRandomEffect()
        {
            return effectssHandler.TryApplyRandomEffect();
        }
    }
}