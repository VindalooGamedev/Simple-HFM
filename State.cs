namespace HFM {
    /// <summary>
    /// If you have readed <see cref="Machine{TData}"/> this becomes obvious.
    /// 
    /// Methods:
    ///  + Next is used to execute the process this state is designed to, the returned value is
    ///    zero when it don't need to change, positive if it's a value chosen for the same Machine,
    ///    negative if it's an exception. It should be like this to be decoupled.
    ///  + OnStart is executed before the first Next is called. It's used to prepare the data.
    /// </summary>
    /// <typeparam name="TData">Data managed by the State</typeparam>
    public abstract class State<TData> : IStateEvaluator<TData> {
        public abstract void OnStart(TData data);
        public abstract int Next(TData data);
    }
}
