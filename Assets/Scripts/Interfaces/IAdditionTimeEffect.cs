namespace Units
{
    /// <summary>
    /// ������ ������� ���������� �����
    /// </summary>
    public interface IAdditionTimeEffect : ICommand
    {
        void ApplyEffect();

        void RemoveEffect();
    }
}