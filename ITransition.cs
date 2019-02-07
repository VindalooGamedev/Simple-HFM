namespace StateMachinesLab
{
    public interface ITransition<TData, T>
    {
        T Evaluate(TData data);
    }
}
