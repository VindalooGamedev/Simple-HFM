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
            int transitionValue = Transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);

            if (transitionValue >= 0)
                logicLayer.ActiveState = transitionValue;
                        
            States[logicLayer.ActiveState](logicLayer.DataLayer);
        }
    }
}
