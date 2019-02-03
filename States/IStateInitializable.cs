namespace StateMachinesLab.States
{
    /// <include file = 'docs/StatesLab.xml' path='doc/IStateInitializable/interface'/>
    public interface IStateInitializable<TData> : IState<TData>, IOnStartEventListener<TData> { }
}
