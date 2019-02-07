using StateMachinesLab.States;

namespace StateMachinesLab.FSM.Moore.OnlyEnterEvent
{
    public class Machine<TData>
    {
        private readonly IStateInitializable<ILogicLayer<TData>>[] _states;
        private readonly ITransition<TData, int>[] _transitions;

        public Machine(IStateInitializable<ILogicLayer<TData>>[] states, ITransition<TData, int>[] transitions)
        {
            _states = states;
            _transitions = transitions;
        }
        
        public void OnStart(ILogicLayer<TData> data)
        {
            data.ActiveState = 0;
            _states[0].OnStart(data);
        }
        
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
