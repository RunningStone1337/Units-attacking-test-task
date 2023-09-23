namespace Units
{
    /// <summary>
    /// Ёффект времени добавлени€ юниту
    /// </summary>
    public interface IAdditionTimeEffect : ICommand
    {
        void ApplyEffect();

        void RemoveEffect();
    }
}