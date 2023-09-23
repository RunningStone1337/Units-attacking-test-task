namespace Units
{
    public interface ICommand
    {
        void ExecuteCommand();

        void UndoCommand();
    }
}