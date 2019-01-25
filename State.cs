namespace HFM {
    /// <summary>
    /// If you have readed <see cref="Machine{TData}"/> this becomes obvious.
    /// 
    /// Behavior:
    ///  + OnStart is executed before the first Next is called. It's used to prepare the data.
    ///  
    ///  + Next is used to execute the process this state is designed to, the returned value 
    ///    will be:
    ///     - Equal to zero: When this state must be maintained as active.
    ///     - Greater than zero: When this state must exit (different numbers for different 
    ///       exits that can lead to different state changes at parent node).
    /// </summary>
    /// <typeparam name="TData">Data managed by the State</typeparam>
    public abstract class State<TData> : IStateEvaluator<TData> {
        public abstract void OnStart(TData data);
        public abstract int Next(TData data);
    }
}
