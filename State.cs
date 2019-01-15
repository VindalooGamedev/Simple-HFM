namespace HFM {
    public abstract class State<TData> : IStateEvaluator<TData> {
        public abstract void OnStart(TData data);
        public abstract int Next(TData data);
    }
}
