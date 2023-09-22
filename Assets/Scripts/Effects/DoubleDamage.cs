namespace Units
{
    /// <summary>
    /// *2 урон для себя
    /// </summary>
    public class DoubleDamage : EffectBase, ICommand, ISelfTargetEffect
    {
        const int DAMAGE_MULTIPLIER = 2;
        int oldDamage;
        public DoubleDamage(UnitModel thisUnit) : base(thisUnit)
        {
        }
        public void ApplyEffect()
        {
            DoCommand();
        }
        public void DoCommand()
        {
            oldDamage = unit.Damage;
            unit.Damage *= DAMAGE_MULTIPLIER;
        }

        public void UndoCommand()
        {
            unit.Damage = oldDamage;
        }
    }
}