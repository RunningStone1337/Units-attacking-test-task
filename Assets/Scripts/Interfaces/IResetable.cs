namespace Gameplay
{
    /// <summary>
    /// Модет быть сброшен до начальных значений.
    /// Реализуется объектами, которые должны быть повторно использованы в новой сессии.
    /// </summary>
    public interface IResetable
    {
        void ResetValues();
    }
}