using StateMachinesLab.States;

namespace StateMachinesLab.HSM
{
    public abstract class Machine<TData> : IStateInitializable<HSMLogicLayer<TData>>
    {
        private readonly IStateInitializable<HSMLogicLayer<TData>>[] _states;
        private readonly int[][] _transitionTable;
        private readonly ITransition<TData, int>[] _transitions;
        
        public Machine(
            IStateInitializable<HSMLogicLayer<TData>>[] states,
            ITransition<TData, int>[] transitions,
            int[][] transitionTable)
        {
            _states = states;
            _transitions = transitions;
            _transitionTable = transitionTable;
        }
        
        public void OnStart(HSMLogicLayer<TData> logicLayer)
        {
            logicLayer.AddState(this);
            _states[0].OnStart(logicLayer);
        }
        
        public int ExecuteNextStep(HSMLogicLayer<TData> logicLayer)
        {
            int transitionValue = _transitions[logicLayer.ActiveState].Evaluate(logicLayer.DataLayer);
            // It leads to an external transition.
            if (transitionValue < 0)
                return (-transitionValue) - 1;

            // There is an internal state transition.
            if (transitionValue > 0)
            {
                logicLayer.ActiveState = transitionValue;
                _states[logicLayer.ActiveState].OnStart(logicLayer);
            }

            _states[logicLayer.ActiveState].ExecuteNextStep(logicLayer);
            return 0;
        }
        
        public int ExecuteNextStep(HSMLogicLayer<TData> logicLayer, int transitionValue)
        {
            logicLayer.ActiveState = _transitionTable[logicLayer.ActiveState][transitionValue];
            return ExecuteNextStep(logicLayer);
        }
    }
}
