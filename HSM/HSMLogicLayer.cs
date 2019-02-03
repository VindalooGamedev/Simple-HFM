using System.Collections.Generic;

namespace StateMachinesLab.HSM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/class'/>
    public class HSMLogicLayer<TData> : ILogicLayer<TData>
    {
        private Stack<HierarchyLevel<TData>> _currentExecution = new Stack<HierarchyLevel<TData>>();

        private HierarchyLevel<TData> _currHierarchyLevel;

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/ActiveState'/>
        public int ActiveState
        {
            get { return _currHierarchyLevel.State; }
            set { _currHierarchyLevel.State = value; }
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/DataLayer'/>
        public TData DataLayer { get; }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/ctor'/>
        public HSMLogicLayer(TData data) => DataLayer = data;

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/Init'/>
        public void Init(Machine<TData> rootMachine)
        {
            _currentExecution.Clear();
            rootMachine.OnStart(this);
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/AddState'/>
        public void AddState(Machine<TData> machine)
        {
            HierarchyLevel<TData> currHierarchyLevel = new HierarchyLevel<TData>(machine, 0);
            _currentExecution.Push(currHierarchyLevel);
            _currHierarchyLevel = currHierarchyLevel;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HSMLogicLayer/Next'/>
        public void Next()
        {
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
