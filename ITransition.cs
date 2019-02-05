namespace StateMachinesLab
{
    /// <include file = 'docs/StatesLab.xml' path='doc/ITransition/interface'/>
    public interface ITransition<TData, T>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/ITransition/Evaluate'/>
        T Evaluate(TData data);
    }
}
