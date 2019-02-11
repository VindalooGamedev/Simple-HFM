using StateMachinesLab.States;

namespace StateMachinesLab.HSM.Harel
{
    public class MachineCluster<TData> : IStateComplete<HarelLogicLayer<TData>>
    {
        private readonly Machine<TData>[] _machines;

        public int ExecuteNextStep(HarelLogicLayer<TData> logicLayer)
        {
            foreach (var item in _machines)
                item.ExecuteNextStep(logicLayer);
            return 0;
        }

        public void OnStart(HarelLogicLayer<TData> logicLayer)
        {
            foreach (var item in _machines)
                item.OnStart(logicLayer);
        }

        public void OnExit(HarelLogicLayer<TData> logicLayer) {
            foreach (var item in _machines)
                item.OnExit(logicLayer);
        }
    }
}
