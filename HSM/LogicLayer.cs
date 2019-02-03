using System.Collections.Generic;

namespace StateMachinesLab.HSM
{
    public class HSMLogicLayer<TData> : ILogicLayer<TData>
    {
        private Stack<HierarchyLevel<TData>> _currentExecution = new Stack<HierarchyLevel<TData>>();

        private HierarchyLevel<TData> _currHierarchyLevel;

        public int ActiveState
        {
            get { return _currHierarchyLevel.State; }
            set { _currHierarchyLevel.State = value; }
        }

        public TData DataLayer { get; }
        public HSMLogicLayer(TData data) => DataLayer = data;

        public void Init(Machine<TData> rootMachine)
        {
            _currentExecution.Clear();
            rootMachine.OnStart(this);
        }

        public void AddState(Machine<TData> machine)
        {
            HierarchyLevel<TData> currHierarchyLevel = new HierarchyLevel<TData>(machine, 0);
            _currentExecution.Push(currHierarchyLevel);
            _currHierarchyLevel = currHierarchyLevel;
        }

        public void Next()
        {
            // TODO: Evaluate this behavior.
            int nextStep;
            do
            {
                nextStep = _currHierarchyLevel.Machine.ExecuteNextStep(this);
                if (nextStep > 0)
                {
                    RemoveLastHierarchyLevel();
                    nextStep = _currHierarchyLevel.Machine.ExecuteNextStep(this, nextStep);
                }
            } while (nextStep != 0);
        }

        private void RemoveLastHierarchyLevel()
        {
            _currentExecution.Pop();
            _currHierarchyLevel = _currentExecution.Peek();
        }
    }
}
