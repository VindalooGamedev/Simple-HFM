using System;

namespace StateMachinesLab.States
{
    /// <include file = 'docs/StatesLab.xml' path='doc/States/GenericState/class'/>
    public class GenericState<TData> : IState<TData>
    {
        private readonly Func<TData, int> _execNextStep;
        private readonly Action<TData> _onStart;

        /// <include file = 'docs/StatesLab.xml' path='doc/States/GenericState/ctor'/>
        public GenericState(Func<TData, int> execNextStep, Action<TData> onStart)
        {
            _execNextStep = execNextStep;
            _onStart = onStart;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/States/GenericState/ExecuteNextStep'/>
        public int ExecuteNextStep(TData data) => _execNextStep(data);

        /// <include file = 'docs/StatesLab.xml' path='doc/States/GenericState/OnStart'/>
        public void OnStart(TData data) => _onStart(data);
    }
}
