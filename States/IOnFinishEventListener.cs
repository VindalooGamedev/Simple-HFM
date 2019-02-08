namespace StateMachinesLab.States
{
    public interface IOnFinishEventListener<TData>
    {
        void OnExit(TData data);
    }
}
