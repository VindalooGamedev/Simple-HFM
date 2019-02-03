namespace StateMachinesLab.States
{
    /// <include file = 'docs/StatesLab.xml' path='doc/IOnStartEventListener/interface'/>
    public interface IOnStartEventListener<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/IOnStartEventListener/OnStart'/>
        void OnStart(TData data);
    }
}
