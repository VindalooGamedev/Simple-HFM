using StateMachinesLab;
using System;

namespace StateMachinesLab.States
{
    public class GenericStateInitializable<TData> : IState<TData>
    {
        private Func<TData, int> _execNextStep;
        private Action<TData> _onStart;

        public GenericStateInitializable(Func<TData, int> execNextStep, Action<TData> onStart)
        {
            _execNextStep = execNextStep;
            _onStart = onStart;
        }

        public int ExecuteNextStep(TData data) => _execNextStep(data);
        public void OnStart(TData data) => _onStart(data);
    }
}
