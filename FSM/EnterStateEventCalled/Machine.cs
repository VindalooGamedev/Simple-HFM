using StateMachinesLab.States;
using System;

namespace StateMachinesLab.FSM.EnterStateEventCalled
{
    public class Machine<TData>
    {
        private IStateInitializable<LogicLayer<TData>>[] States { get; }
        private ITransition<TData>[] Transitions { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/ctor'/>
        public Machine(IStateInitializable<LogicLayer<TData>>[] states, ITransition<TData>[] transitions)
        {
            States = states;
            Transitions = transitions;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/OnStart'/>
        public void OnStart(LogicLayer<TData> data)
        {
            data.ActiveState = 0;
            States[0].OnStart(data);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/Machine/Next'/>
        public void Next(LogicLayer<TData> logicLayer)
        {
            // Transition if it needs it.
            int transitionValue = Transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);

            // If it doesn't need to transition then just execute.
            if (transitionValue == 0)
                transitionValue = States[logicLayer.ActiveState].ExecuteNextStep(logicLayer);

            // If need to transition then move to next state and execute the state.
            if (transitionValue > 0)
            {
                logicLayer.ActiveState = transitionValue - 1;
                var currState = States[logicLayer.ActiveState];
                currState.OnStart(logicLayer);
                currState.ExecuteNextStep(logicLayer);
            }
            // There is some problem at definition point, it can't use negative values.
            else throw new Exception("transitionValue can't be a negative value.");
        }
    }
}
