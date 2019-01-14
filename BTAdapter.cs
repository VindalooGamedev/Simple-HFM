using System.Collections.Generic;

namespace HFM {
    public class BTAdapter<TData> {
        Stack<IStateEvaluator<TData>> _currentExecution;

        public void AddState(IStateEvaluator<TData> state) {
            _currentExecution.Push(state);
        }

    }
}
