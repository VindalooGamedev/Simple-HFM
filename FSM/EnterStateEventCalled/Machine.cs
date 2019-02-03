﻿using StateMachinesLab.States;

namespace StateMachinesLab.FSM.EnterStateEventCalled
{
    /// <include file = 'docs/StatesLab.xml' path='doc/FSM/EnterStateEventCalled/Machine/class'/>
    public class Machine<TData>
    {
        private readonly IStateInitializable<ILogicLayer<TData>>[] _states;
        private readonly ITransition<TData>[] _transitions;

        /// <include file = 'docs/StatesLab.xml' path='doc/FSM/EnterStateEventCalled/Machine/ctor'/>
        public Machine(IStateInitializable<ILogicLayer<TData>>[] states, ITransition<TData>[] transitions)
        {
            _states = states;
            _transitions = transitions;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/FSM/EnterStateEventCalled/Machine/OnStart'/>
        public void OnStart(ILogicLayer<TData> data)
        {
            data.ActiveState = 0;
            _states[0].OnStart(data);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/FSM/EnterStateEventCalled/Machine/Next'/>
        public void Next(ILogicLayer<TData> logicLayer)
        {
            int transitionValue = _transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);

            if (transitionValue >= 0)
            {
                logicLayer.ActiveState = transitionValue;
                _states[logicLayer.ActiveState].OnStart(logicLayer);    
            }

            _states[logicLayer.ActiveState].ExecuteNextStep(logicLayer);
        }
    }
}
