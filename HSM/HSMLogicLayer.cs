using System.Collections.Generic;

namespace StateMachinesLab.HSM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/class'/>
    public class HSMLogicLayer<TData> : ILogicLayer<TData>
    {
        private HierarchyLevel<TData>[] _hierarchyLevels;
        private int _currHierarchyLevel;
        
        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/ActiveState'/>
        public int ActiveState
        {
            get { return _hierarchyLevels[_currHierarchyLevel].State; }
            set { _hierarchyLevels[_currHierarchyLevel].State = value; }
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/DataLayer'/>
        public TData DataLayer { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/ctor'/>
        public HSMLogicLayer(TData data) => DataLayer = data;

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/Init'/>
        public void Init(Machine<TData> rootMachine)
        {
            _currHierarchyLevel = -1;
            rootMachine.OnStart(this);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/AddState'/>
        public void AddState(Machine<TData> machine)
        {
            HierarchyLevel<TData> currHierarchyLevel = new HierarchyLevel<TData>(machine, 0);
            _hierarchyLevels[++_currHierarchyLevel] = currHierarchyLevel;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/Next'/>
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
