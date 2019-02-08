using System.Collections.Generic;

namespace StateMachinesLab.HSM.LinkedNestedMachines
{
    public class HSMLogicLayer<TData> : ILogicLayer<TData>
    {
        private HierarchyLevel<TData>[] _hierarchyLevels;
        private int _currHierarchyLevel;
        
        public int ActiveState
        {
            get { return _hierarchyLevels[_currHierarchyLevel].State; }
            set { _hierarchyLevels[_currHierarchyLevel].State = value; }
        }
        
        public TData DataLayer { get; }
        
        public HSMLogicLayer(TData data) => DataLayer = data;
        
        public void Init(Machine<TData> rootMachine)
        {
            _currHierarchyLevel = -1;
            rootMachine.OnStart(this);
        }

        public void AddState(Machine<TData> machine)
        {
            HierarchyLevel<TData> currHierarchyLevel = new HierarchyLevel<TData>(machine, 0);
            _hierarchyLevels[++_currHierarchyLevel] = currHierarchyLevel;
        }
        
        public void Next()
        {
            int nextStep;
            do
            {
                nextStep = _hierarchyLevels[_currHierarchyLevel].Machine.ExecuteNextStep(this);
                if (nextStep > 0)
                {
                    RemoveLastHierarchyLevel();
                    nextStep = _hierarchyLevels[_currHierarchyLevel].Machine.ExecuteNextStep(this, nextStep);
                }
            } while (nextStep != 0);
        }

        private void RemoveLastHierarchyLevel() => _hierarchyLevels[_currHierarchyLevel--] = null;
    }
}
