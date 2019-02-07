using System;

namespace StateMachinesLab.FSM.Moore.Simplest
{
    public class Machine<TData>
    {
        private readonly Action<TData>[] _states;
        private readonly ITransition<TData, int>[] _transitions;
        
        public Machine(Action<TData>[] states, ITransition<TData, int>[] transitions)
        {
            _states = states;
            _transitions = transitions;
        }
        
        public void Clear(ILogicLayer<TData> data) => data.ActiveState = 0;
        
        public void Next(ILogicLayer<TData> logicLayer)
        {
            int transitionValue = _transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);

            if (transitionValue >= 0)
                logicLayer.ActiveState = transitionValue;
                        
            _states[logicLayer.ActiveState](logicLayer.DataLayer);
        }
    }
}
