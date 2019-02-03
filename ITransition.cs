namespace StateMachinesLab
{
    /// <include file = 'docs/StatesLab.xml' path='doc/ITransition/interface'/>
    public interface ITransition<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/ITransition/Evaluate'/>
        int Evaluate(TData data);
    }
}
