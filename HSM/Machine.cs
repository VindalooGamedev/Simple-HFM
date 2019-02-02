using StateMachinesLab.States;

namespace StateMachinesLab.HSM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/Machine/class'/>
    public abstract class Machine<TData> : IStateInitializable<HSMLogicLayer<TData>>
    {
        private IStateInitializable<HSMLogicLayer<TData>>[] States { get; }
        private int[][] TransitionTable { get; }
        private ITransition<TData>[] Transitions { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/ctor'/>
        public Machine(
            IStateInitializable<HSMLogicLayer<TData>>[] states,
            ITransition<TData>[] transitions,
            int[][] transitionTable)
        {
            States = states;
            Transitions = transitions;
            TransitionTable = transitionTable;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/OnStart'/>
        public void OnStart(HSMLogicLayer<TData> logicLayer)
        {
            logicLayer.AddState(this);
            States[0].OnStart(logicLayer);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next'/>
        public int ExecuteNextStep(HSMLogicLayer<TData> logicLayer)
        {
            int transitionValue = Transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);
            // It leads to an external transition.
            if (transitionValue < 0)
                return (-transitionValue) - 1;

            // There is an internal state transition.
            if (transitionValue > 0)
            {
                logicLayer.ActiveState = transitionValue;
                States[logicLayer.ActiveState].OnStart(logicLayer);
            }

            States[logicLayer.ActiveState].ExecuteNextStep(logicLayer);
            return 0;
        }

        public int ExecuteNextStep(HSMLogicLayer<TData> logicLayer, int transitionValue)
        {
            logicLayer.ActiveState = TransitionTable[logicLayer.ActiveState][transitionValue];
            return ExecuteNextStep(logicLayer);
        }
    }
}
