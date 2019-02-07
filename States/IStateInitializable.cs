namespace StateMachinesLab.States
{
    public interface IStateInitializable<TData> : IState<TData>, IOnStartEventListener<TData> { }
}
