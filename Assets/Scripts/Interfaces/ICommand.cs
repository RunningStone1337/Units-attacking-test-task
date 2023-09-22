namespace Units
{
    public interface ICommand
    {
        void DoCommand();
        void UndoCommand();
    }
}