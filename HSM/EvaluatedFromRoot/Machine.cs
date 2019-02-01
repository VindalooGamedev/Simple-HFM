using StateMachinesLab.States;
using System;

namespace StateMachinesLab.HSM.EvaluatedFromRoot
{
    /// <include file = 'docs/StatesLab.xml' path='doc/Machine/class'/>
    public abstract class Machine<TData> : IStateInitializable<LogicLayer<TData>>
    {
        private IStateInitializable<LogicLayer<TData>>[] States { get; }
        private int[][] TransitionTable { get; }
        private ITransition<TData>[] Transitions { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/ctor'/>
        public Machine(
            IStateInitializable<LogicLayer<TData>>[] states,
            ITransition<TData>[] transitions,
            int[][] transitionTable
            )
        {
            States = states;
            Transitions = transitions;
            TransitionTable = transitionTable;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/OnStart'/>
        public void OnStart(LogicLayer<TData> data)
        {
            data.ActiveState = 0;
            States[0].OnStart(data);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next'/>
        public int ExecuteNextStep(LogicLayer<TData> logicLayer)
        {
            int transitionValue = Transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);
            // It leads to an external transition.
            if (transitionValue < 0)
                return (-transitionValue) - 1;

            // There is an internal state transition.
            if (transitionValue > 0)
            {
                logicLayer.ActiveState = TransitionTable[logicLayer.ActiveState][transitionValue];
                States[logicLayer.ActiveState].OnStart(logicLayer);
            }

            States[logicLayer.ActiveState].ExecuteNextStep(logicLayer);
            return 0;
        }
    }
}
