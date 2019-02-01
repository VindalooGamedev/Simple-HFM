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
            int transitionValue = Transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);

            if (transitionValue >= 0)
            {
                logicLayer.ActiveState = transitionValue;
                States[logicLayer.ActiveState].OnStart(logicLayer);    
            }

            States[logicLayer.ActiveState].ExecuteNextStep(logicLayer);
        }
    }
}
