using System;

namespace StateMachinesLab.States
{
    public class GenericState<TData> : IState<TData>
    {
        private readonly Func<TData, int> _execNextStep;
        private readonly Action<TData> _onStart;
        
        public GenericState(Func<TData, int> execNextStep, Action<TData> onStart)
        {
            _execNextStep = execNextStep;
            _onStart = onStart;
        }
        
        public int ExecuteNextStep(TData data) => _execNextStep(data);
        
        public void OnStart(TData data) => _onStart(data);
    }
}
