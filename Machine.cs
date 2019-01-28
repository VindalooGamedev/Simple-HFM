using System;

namespace HFM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/Machine/class'/>
    public sealed class Machine<Data> : IStateEvaluator<LogicLayer<Data>> {
        private IStateEvaluator<LogicLayer<Data>>[] States { get; }
        private int[][] TransitionTable { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/ctor'/>
        public Machine(IStateEvaluator<LogicLayer<Data>>[] states, int[][] transitionTable) {
            States = states;
            TransitionTable = transitionTable;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/OnStart'/>
        public void OnStart(LogicLayer<Data> data) {
            data.ActiveState = 0;
            data.AddState(this);
            States[0].OnStart(data);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next'/>
        public int Next(LogicLayer<Data> data) {
            int transitionValue;
            for (; ; ) {
                transitionValue = States[data.ActiveState].Next(data);
                if (transitionValue == 0) break;
                if (transitionValue > 0) {
                    // It uses initial transitionValue to reach final transitionValue.
                    transitionValue = TransitionTable[data.ActiveState][transitionValue - 1];
                    if (transitionValue == 0) break;
                    if (transitionValue > 0) {
                        data.ActiveState = transitionValue - 1;
                        States[data.ActiveState].OnStart(data);
                    }
                    else {
                        transitionValue = -transitionValue;
                        break;
                    }
                }
                else throw new Exception("Invalid Exit Value from nested StateEvaluator");
            }
            return transitionValue;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next2'/>
        public int Next(LogicLayer<Data> data, int startAt) {
            data.ActiveState = startAt;
            return Next(data);
        }
    }
}
