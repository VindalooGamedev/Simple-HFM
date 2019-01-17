namespace HFM {
    public interface IStateEvaluator<TData> {
        int Next(TData data);
        void OnStart(TData data);
    }
}
