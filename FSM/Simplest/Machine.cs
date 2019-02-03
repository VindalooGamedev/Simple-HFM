using System;

namespace StateMachinesLab.FSM.Simplest
{
    /// <include file = 'docs/StatesLab.xml' path='doc/FSM/Simplest/Machine/class'/>
    public class Machine<TData>
    {
        private readonly Func<TData, int>[] _states;
        private readonly ITransition<TData>[] _transitions;

        /// <include file = 'docs/StatesLab.xml' path='doc/FSM/Simplest/Machine/ctor'/>
        public Machine(Func<TData, int>[] states, ITransition<TData>[] transitions)
        {
            _states = states;
            _transitions = transitions;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/FSM/Simplest/Machine/Clear'/>
        public void Clear(ILogicLayer<TData> data) => data.ActiveState = 0;

        /// <include file = 'docs/StatesLab.xml' path='doc/FSM/Simplest/Machine/Next'/>
        public void Next(ILogicLayer<TData> logicLayer)
        {
            int transitionValue = _transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);

            if (transitionValue >= 0)
                logicLayer.ActiveState = transitionValue;
                        
            _states[logicLayer.ActiveState](logicLayer.DataLayer);
        }
    }
}
