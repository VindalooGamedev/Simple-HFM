namespace HFM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/StateEvaluator/class'/>
    public interface IStateEvaluator<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/StateEvaluator/Next'/>
        int Next(TData data);

        /// <include file = 'docs/StatesLab.xml' path='doc/StateEvaluator/OnStart'/>
        void OnStart(TData data);
    }
}
