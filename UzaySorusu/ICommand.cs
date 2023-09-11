namespace Quiz
{
    public interface ICommand
    {
        void Execute(Pleateu pleateu, int roverId);
    }
}