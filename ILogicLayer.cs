namespace StateMachinesLab
{
    public interface ILogicLayer<TData>
    {
        int ActiveState { get; set; }
        
        TData DataLayer { get; }
    }
}
