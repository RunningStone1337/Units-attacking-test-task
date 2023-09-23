namespace Units
{
    /// <summary>
    /// *2 урон для себя
    /// </summary>
    public class DoubleDamage : AdditionTimeEffectBase
    {
        private const int DAMAGE_MULTIPLIER = 2;
        private int oldDamage;

        public DoubleDamage(UnitModel thisUnit, int effectDuration) : base(thisUnit, effectDuration)
        {
        }

        public override void ExecuteCommand()
        {
            oldDamage = unit.Damage;
            unit.Damage *= DAMAGE_MULTIPLIER;
        }

        public override void UndoCommand()
        {
            unit.Damage = oldDamage;
        }
    }
}