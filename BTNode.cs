using System;
namespace HFM {
    public abstract class BTNode<TData> : Machine<BTAdapter<TData>> {
        public override void OnStart(BTAdapter<TData> data) => data.AddState(this);
    }
}
