namespace HFM {
    public abstract class Machine<TData> : IStateEvaluator<TData> {
        protected int ActiveState { get; private set; }

        protected abstract IStateEvaluator<TData> this[int x] { get; }

        public abstract void OnStart(TData data);

        protected abstract int ExitStep(TData data, int nextState);

        public int Next(TData data) {
            for (; ; ) {
                ActiveState = this[ActiveState].Next(data);
                if (ActiveState > 0) {
                    this[ActiveState].OnStart(data);
                }
                else { break; }
            }
            if (ActiveState < 0) { ActiveState = ExitStep(data, -ActiveState); }
            return ActiveState;
        }

        public int Next(TData data, int startAt) {
            ActiveState = startAt;
            return Next(data);
        }
    }
}
