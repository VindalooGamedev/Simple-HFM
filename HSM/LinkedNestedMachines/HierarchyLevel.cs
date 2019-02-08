namespace StateMachinesLab.HSM.LinkedNestedMachines
{
    public class HierarchyLevel<TData>
    {
        public Machine<TData> Machine { get; set; }
        
        public int State { get; set; }
        
        public HierarchyLevel(Machine<TData> currMachine, int currState)
        {
            Machine = currMachine;
            State = currState;
        }
    }
}
