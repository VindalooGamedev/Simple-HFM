namespace StateMachinesLab
{
    /// <include file = 'docs/StatesLab.xml' path='doc/StateEvaluator/class'/>
    public interface IState<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/StateEvaluator/Next'/>
        int ExecuteNextStep(TData data);
    }
}
