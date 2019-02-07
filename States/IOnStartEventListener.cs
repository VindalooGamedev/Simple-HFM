namespace StateMachinesLab.States
{
    public interface IOnStartEventListener<TData>
    {
        void OnStart(TData data);
    }
}
