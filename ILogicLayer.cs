namespace StateMachinesLab
{
    /// <include file = 'docs/StatesLab.xml' path='doc/ILogicLayer/class'/>
    public interface ILogicLayer<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/ILogicLayer/ActiveState'/>
        int ActiveState { get; set; }

        /// <include file = 'docs/StatesLab.xml' path='doc/ILogicLayer/DataLayer'/>
        TData DataLayer { get; }
    }
}
