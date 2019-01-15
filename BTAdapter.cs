using System.Collections.Generic;

namespace HFM {
    public class BTAdapter<TData> {
        Stack<BTNode<TData>> _currentExecution;

        public void AddState(BTNode<TData> state) => _currentExecution.Push(state);

    }
}
