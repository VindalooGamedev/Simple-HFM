namespace StateMachinesLab.States
{
    /// <include file = 'docs/StatesLab.xml' path='doc/IState/interface'/>
    public interface IState<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/IState/Next'/>
        int ExecuteNextStep(TData data);
    }
}
