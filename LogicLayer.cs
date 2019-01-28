using System.Collections.Generic;

namespace HFM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/LogicLayer/class'/>
    public class LogicLayer<TData> : ILogicLayer<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/LogicLayer/CurrentExecution'/>
        private Stack<Machine<TData>> _currentExecution = new Stack<Machine<TData>>();

        /// <include file = 'docs/StatesLab.xml' path='doc/LogicLayer/ActiveState'/>
        public int ActiveState { get; set; }

        /// <include file = 'docs/StatesLab.xml' path='doc/LogicLayer/Init'/>
        public void Init(Machine<TData> logicNet) {
            _currentExecution.Clear();
            AddState(logicNet);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/LogicLayer/AddState'/>
        public void AddState(Machine<TData> state) {
            _currentExecution.Push(state);
            state.OnStart(this);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/LogicLayer/Next'/>
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
