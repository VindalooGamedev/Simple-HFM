namespace StateMachinesLab
{
    public interface ITransition<TData>
    {
        int Evaluate(TData data);
    }
}