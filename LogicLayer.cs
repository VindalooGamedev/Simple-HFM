using System.Collections.Generic;

namespace HFM
{
    public class LogicLayer<TData> : ILogicLayer<TData>
    {
        Stack<Machine<TData>> _currentExecution;

        public int ActiveState { get; set; }
        
        public void Init(Machine<TData> logicNet) {
            _currentExecution.Clear();
            AddState(logicNet);
        }

        public void AddState(Machine<TData> state) {
            _currentExecution.Push(state);
            state.OnStart(this);
        }

        public void Next() {
            int nextStep = 0;
            for (; ; ) {
                if (nextStep == 0) nextStep = _currentExecution.Peek().Next(this);
                else {
                    _currentExecution.Pop();
                    nextStep = _currentExecution.Peek().Next(this, nextStep);
                }
            }
        }
    }
}
