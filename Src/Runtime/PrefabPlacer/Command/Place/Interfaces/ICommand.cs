namespace LD
{
    public interface ICommand
    {
        void Execute(); 
        void Undo();
        void Redo();
    }
}