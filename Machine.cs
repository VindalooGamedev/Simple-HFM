using System;

namespace HFM {
    /// <summary>
    /// This class is one node of a Hierarchical State Machine, it works as an FSM is used alone.
    /// It's behaviour is based on the returned value (inner value) of the State Evaluator called
    /// from him (it can be another machine or an state) and then it returns another value (outter
    /// value) to define its situation.
    ///  - If (innerValue GREATER_THAN 0) then it changes from the active state to the one assigned to that 
    ///    place and keep running at the new state.
    ///  - If (innerValue EQUAL_THAN 0) then it won't change from that state and return 0 to tell outters
    ///    machines that its job is unfinished.
    ///  - If (innerValue LOWER_THAN 0) then it will change its sign and derived to non abstract definition,
    ///    this way this machine will define which value it will be returned and changed at the next level.
    /// 
    /// Values:
    ///  + ActiveState will define which state is the one active.
    ///  + NextState will hold a code that will mean which state will be the next in the Machine process
    ///    or it will mean the exit value of that state that with the help of the derivative classes will 
    ///    return the next state of the outter machine.
    ///    
    /// Methods:
    ///  + Next Will make the next step of the process and if it changes from one state to another it will
    ///    keep working on it until it returns a value that will stop on a state or change an outter state.
    ///     - A variant is used to define the firstState will be used (It's useful when the Machine has more
    ///       than one entry point).
    ///  + OnStart is executed before the first Next is called. It's used to prepare the data.
    ///  + ExitStep is called when the state called return an exit code (lower than zero) to decide which 
    ///    exit code the machine will have. It must be used with ActiveState value to decide and it should
    ///    not be defined at state to have them decoupled from the machine.
    /// </summary>
    /// <typeparam name="TData">Data managed by the Machine</typeparam>
    public abstract class Machine<TData> : IStateEvaluator<TData> {
        public int ActiveState { get; set; }

        protected abstract IStateEvaluator<TData>[] States { get; }
        protected abstract int[][] StatesReferences { get; }

        private int NextState(int transitionValue) => StatesReferences[ActiveState][transitionValue - 1];

        public virtual void OnStart(TData data) => ActiveState = 0;

        protected abstract int ExitStep(TData data, int nextState);

        public int Next(TData data) {
            int transitionValue;
            for (; ; ) {
                transitionValue = States[ActiveState].Next(data);
                if (transitionValue > 0) {
                    transitionValue = NextState(transitionValue);
                    Console.WriteLine($"{transitionValue}...{ActiveState}");
                    if (transitionValue <= 0) break;
                    ActiveState = transitionValue-1;
                    States[ActiveState].OnStart(data);
                }
                else {
                    throw new System.Exception("Invalid Exit Value from nested StateEvaluator");
                }
            }
            if (transitionValue < 0) { transitionValue = ExitStep(data, -ActiveState); }
            return transitionValue;
        }

        public int Next(TData data, int startAt) {
            ActiveState = startAt;
            return Next(data);
        }
    }
}
