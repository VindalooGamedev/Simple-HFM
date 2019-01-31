namespace StateMachinesLab.States
{
    /// <include file = 'docs/StatesLab.xml' path='doc/State/class'/>
    public interface IStateInitializable<TData> : IState<TData>, IOnStartEventListener<TData> { }
}
