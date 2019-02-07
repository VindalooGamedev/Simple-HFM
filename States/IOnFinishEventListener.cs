namespace StateMachinesLab.States
{
    public interface IOnFinishEventListener<TData>
    {
        void OnFinish(TData data);
    }
}
