namespace HFM {
    public abstract class State<TData> : IStateEvaluator {
        protected TData Data { get; private set; }

        public State(TData data) => Data = data;

        public abstract void OnStart();
        public abstract int Next();
    }
}
