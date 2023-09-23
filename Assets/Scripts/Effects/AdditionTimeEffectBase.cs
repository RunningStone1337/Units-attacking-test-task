namespace Units
{
    /// <summary>
    /// Базовый эффект, который применяется во мремя добавления юниту
    /// </summary>
    public abstract class AdditionTimeEffectBase : EffectBase, IAdditionTimeEffect
    {
        protected AdditionTimeEffectBase(UnitModel thisUnit, int effectDuration) : base(thisUnit, effectDuration)
        {
        }

        public virtual void ApplyEffect()
        { ExecuteCommand(); }

        public abstract void ExecuteCommand();

        public virtual void RemoveEffect()
        { UndoCommand(); }

        public abstract void UndoCommand();
    }
}