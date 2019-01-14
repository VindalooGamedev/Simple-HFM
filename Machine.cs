namespace HFM {
    public abstract class Machine<TData> : IStateEvaluator<TData> {
        protected int ActiveState { get; private set; }

        protected abstract IStateEvaluator<TData> this[int x, int y] { get; }

        public abstract void OnStart(TData data);

        protected abstract int ExitStep(int nextState);

        public int Next(TData data) {
            for (; ; ) {
                ActiveState = this[ActiveState, 0].Next(data);
                if (ActiveState > 0) { this[ActiveState, 0].OnStart(data); }
                else { break; }
            }
            if (ActiveState < 0) { ActiveState = ExitStep(-ActiveState); }
            return ActiveState;
        }

        public int Next(TData data, int startAt) {
            ActiveState = startAt;
            return Next(data);
        }
    }
}
