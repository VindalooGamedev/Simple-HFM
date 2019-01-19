namespace HFM {
    /// <summary>
    /// This class is used to handle <see cref="Machine{TData}"/> as nodes of a Behaviour Tree,
    /// becoming the starting point where to execute the algorithm.
    /// </summary>
    /// <typeparam name="TData">Data to use on the Machines (nodes)</typeparam>
    public abstract class BTNode<TData> : Machine<BTAdapter<TData>> {
        public override void OnStart(BTAdapter<TData> data) => data.AddState(this);
    }
}
