using StateMachinesLab.States;
using System;

namespace StateMachinesLab
{
    /// <include file = 'docs/StatesLab.xml' path='doc/Machine/class'/>
    public abstract class Machine<TData> : IStateInitializable<LogicLayer<TData>>
    {
        private IStateInitializable<LogicLayer<TData>>[] States { get; }
        private int[][] TransitionTable { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/ctor'/>
        public Machine(IStateInitializable<LogicLayer<TData>>[] states, int[][] transitionTable)
        {
            States = states;
            TransitionTable = transitionTable;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/OnStart'/>
        public void OnStart(LogicLayer<TData> data)
        {
            data.ActiveState = 0;
            data.AddState(this);
            States[0].OnStart(data);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next'/>
        public int ExecuteNextStep(LogicLayer<TData> data)
        {
            int transitionValue;
            for (; ; )
            {
                transitionValue = States[data.ActiveState].ExecuteNextStep(data);
                if (transitionValue == 0) break;
                if (transitionValue > 0)
                {
                    // It uses initial transitionValue to reach final transitionValue.
                    transitionValue = TransitionTable[data.ActiveState][transitionValue - 1];
                    if (transitionValue == 0) break;
                    if (transitionValue > 0)
                    {
                        data.ActiveState = transitionValue - 1;
                        States[data.ActiveState].OnStart(data);
                    }
                    else
                    {
                        transitionValue = -transitionValue;
                        break;
                    }
                }
                else throw new Exception("Invalid Exit Value from nested StateEvaluator");
            }
            return transitionValue;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next2'/>
        public int Next(LogicLayer<TData> data, int startAt)
        {
            data.ActiveState = startAt;
            return ExecuteNextStep(data);
        }
    }
}
