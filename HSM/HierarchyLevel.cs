namespace StateMachinesLab.HSM
{
    /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HierarchyLevel/class'/>
    public class HierarchyLevel<TData>
    {
        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HierarchyLevel/Machine'/>
        public Machine<TData> Machine { get; set; }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HierarchyLevel/State'/>
        public int State { get; set; }

        /// <include file = 'docs/StatesLab.xml' path='doc/HSM/HierarchyLevel/ctor'/>
        public HierarchyLevel(Machine<TData> currMachine, int currState)
        {
            Machine = currMachine;
            State = currState;
        }
    }
}
