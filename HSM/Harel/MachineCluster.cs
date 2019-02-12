using StateMachinesLab.States;
using System;

namespace StateMachinesLab.HSM.Harel
{
    public class MachineCluster<TData> : IStateComplete<HarelLogicLayer<TData>>
    {
        private readonly Machine<TData>[] _machines;
        private readonly Action<TData> _onEnter, _onExit;

        public MachineCluster(Machine<TData>[] machines, Action<TData> onEnter, Action<TData> onExit)
        {
            _machines = machines;
            _onEnter = onEnter;
            _onExit = onExit;
        }

        public int ExecuteNextStep(HarelLogicLayer<TData> logicLayer)
        {
            int exitCode;
            foreach (var item in _machines)
            {
                exitCode = item.ExecuteNextStep(logicLayer);
                if (exitCode > 0)
                {
                    OnExit(logicLayer);
                    return exitCode;
                }
            }
            return 0;
        }

        public void OnStart(HarelLogicLayer<TData> logicLayer)
        {

            _onEnter?.Invoke(logicLayer.DataLayer);
            foreach (var item in _machines)
                item.OnStart(logicLayer);
        }

        public void OnExit(HarelLogicLayer<TData> logicLayer)
        {
            _onExit?.Invoke(logicLayer.DataLayer);
            foreach (var item in _machines)
                item.OnExit(logicLayer);
        }
    }
}
