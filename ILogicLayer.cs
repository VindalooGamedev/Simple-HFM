namespace HFM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/ILogicLayer/class'/>
    public interface ILogicLayer<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/ILogicLayer/ActiveState'/>
        int ActiveState { get; set; }
    }
}