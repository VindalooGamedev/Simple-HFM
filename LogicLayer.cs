using System.Collections.Generic;

namespace HFM
{
    /// <summary>
    /// See <see cref="Machine{TData}"/> to know the execution process of nodes.
    /// This class execute nodes isolating them to be capable of direct access on 
    /// the next query. When a node starts it must register themselves to the Behaviour
    /// Tree and when it returns a positive value it will keep the execution until
    /// it gets a zero returned to wait until next step or negative value to go to the
    /// parent node on the behaviour tree.
    /// </summary>
    /// <typeparam name="TData">Data adapted to be used in Behavior Trees</typeparam>
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
