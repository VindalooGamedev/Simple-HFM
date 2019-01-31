using System;

namespace StateMachinesLab.FSM.Simplest
{
    public class Machine<TData>
    {
        private Func<TData, int>[] States { get; }
        private ITransition<TData>[] Transitions { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/ctor'/>
        public Machine(Func<TData, int>[] states, ITransition<TData>[] transitions)
        {
            States = states;
            Transitions = transitions;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/OnStart'/>
        public void Clear(LogicLayer<TData> data) => data.ActiveState = 0;

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next'/>
        public void Next(LogicLayer<TData> logicLayer)
        {
            // Transition if it needs it.
            int transitionValue = Transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);

            // If it doesn't need to transition then just execute.
            if (transitionValue == 0)
                transitionValue = States[logicLayer.ActiveState](logicLayer.DataLayer);

            // If need to transition then move to next state and execute the state.
            if (transitionValue > 0)
            {
                logicLayer.ActiveState = transitionValue - 1;
                States[logicLayer.ActiveState](logicLayer.DataLayer);
            }
            else throw new Exception("Invalid Exit Value from nested StateEvaluator");
        }
    }
}
