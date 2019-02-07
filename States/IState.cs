namespace StateMachinesLab.States
{
    public interface IState<TData>
    {
        int ExecuteNextStep(TData data);
    }
}
