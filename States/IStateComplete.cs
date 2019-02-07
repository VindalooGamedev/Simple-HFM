namespace StateMachinesLab.States
{
    public interface IStateComplete<TData> 
        : IState<TData>,
        IOnStartEventListener<TData>, 
        IOnFinishEventListener<TData> { }
}