namespace StateMachinesLab.States
{
    public interface IOnStartEventListener<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/StateEvaluator/OnStart'/>
        void OnStart(TData data);
    }
}
