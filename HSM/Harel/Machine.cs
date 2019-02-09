using StateMachinesLab.States;
using System;

namespace StateMachinesLab.HSM.Harel
{
    public abstract class Machine<TData> : IStateComplete<HarelLogicLayer<TData>>
    {
        private readonly IStateComplete<HarelLogicLayer<TData>>[] _states;
        private readonly int[][] _transitionTable;
        private readonly ITransition<TData, int>[] _transitions;
        private readonly Action<TData> _onEnter, _onExit;
        
        public Machine(
            IStateComplete<HarelLogicLayer<TData>>[] states,
            ITransition<TData, int>[] transitions,
            Action<TData> onEnter,
            Action<TData> onExit,
            int[][] transitionTable)
        {
            _states = states;
            _transitions = transitions;
            _transitionTable = transitionTable;
            _onEnter = onEnter;
            _onExit = onExit;
        }
        
        public void OnStart(HarelLogicLayer<TData> logicLayer)
        {
            logicLayer.AddState(this);
            _states[0].OnStart(logicLayer);
        }
        
        public int ExecuteNextStep(HarelLogicLayer<TData> logicLayer)
        {
            int transitionValue = _transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);
            // It leads to an external transition.
            if (transitionValue < 0)
                return (-transitionValue) - 1;

            // There is an internal state transition.
            if (transitionValue > 0)
            {
                _states[logicLayer.ActiveState].OnExit(logicLayer);
                logicLayer.ActiveState = transitionValue;
                _states[logicLayer.ActiveState].OnStart(logicLayer);
            }

            _states[logicLayer.ActiveState].ExecuteNextStep(logicLayer);
            return 0;
        }
        
        public int ExecuteNextStep(HarelLogicLayer<TData> logicLayer, int transitionValue)
        {
            logicLayer.ActiveState = _transitionTable[logicLayer.ActiveState][transitionValue];
            return ExecuteNextStep(logicLayer);
        }

        public void OnExit(HarelLogicLayer<TData> logicLayer) => _onExit?.Invoke(logicLayer.DataLayer);
        public void OnEnter(HarelLogicLayer<TData> logicLayer) => _onEnter?.Invoke(logicLayer.DataLayer);
    }
}
