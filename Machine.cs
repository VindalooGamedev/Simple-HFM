using System;

namespace HFM
{
    public abstract class Machine<Data> : IStateEvaluator<LogicLayer<Data>> {
        protected IStateEvaluator<LogicLayer<Data>>[] States { get; }
        protected int[][] TransitionTable { get; }

        public virtual void OnStart(LogicLayer<Data> data) {
            data.ActiveState = 0;
            data.AddState(this);
            States[0].OnStart(data);
        }

        protected abstract int ExitStep(LogicLayer<Data> data, int nextState);

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
                        transitionValue = ExitStep(data, -transitionValue);
                        break;
                    }
                }
                else throw new Exception("Invalid Exit Value from nested StateEvaluator");
            }
            return transitionValue;
        }

        public int Next(LogicLayer<Data> data, int startAt) {
            data.ActiveState = startAt;
            return Next(data);
        }
    }
}
