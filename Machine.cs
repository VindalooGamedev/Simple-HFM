using System;

namespace HFM
{
    /// <summary>
    /// This class define a node of hierarchical state machines. These nodes are used as the root or
    /// internal node of the tree type hierarchy, leaf nodes will be the states.
    /// 
    /// Behavior phase:
    ///  + Initial phase: Executing OnStart it prepares the data for the first state that match with 
    ///    the entry state.
    ///  
    ///  + Loop phase:  In this phase every time the next method is called, the current state of the 
    ///    logic is updated, being able to change active state and return to a previous node of the 
    ///    hierarchy. 
    ///    
    ///  + End phase: Due to the values ​​returned by the child nodes, the process ends and this node
    ///    returns a value that defines the ending the process has had.
    ///    
    ///  Behavior:
    ///    The initialization process is directly associated with OnStart, when the OnStart method 
    ///    is executed, the first state is associated with 0 and then the child's OnStart is called,
    ///    so it depends on where base.OnStart is called the adaptation order to the First state will
    ///    happen in one order or another.
    ///    
    ///    The execution process covers the loop and final phases works as follows.
    ///    When called to Next this node calls the Next of the active node and depending on the return
    ///    value this node will act in one way or another.
    ///    The value obtained transitionValue (initial) can not be negative, the viable values ​​are:
    ///    
    ///    + If valueTransition is equal to 0: the active state is maintained.
    ///    
    ///    + If valueTransition is greater than 0: the returned value is queried in the transition table
    ///      and the valueTransition(final) is obtained.
    ///      
    ///       - If valueTransition is equal to 0: the active state is maintained.
    ///       
    ///       - If valueTransition is less than 0: It is an exit transition and this node is exited 
    ///         with the value returned with ExitStep that has transitionValue with changed sign as 
    ///         parameter (returned value will be used by the parent to choose the next state with its
    ///         transition table). In case the value returned is from the root of the structure this 
    ///         output value can serve to remember from which state it has left if this is important.
    ///         
    ///       - If valueTransition is greater than 0: It is an internal transition so it will change
    ///         the active node and call OnStart to initialize it before being called in the same 
    ///         execution cycle.
    /// </summary>
    /// <typeparam name="TData">Data managed by the Machine</typeparam>
    public abstract class Machine<TData> : IStateEvaluator<TData> {
        public int ActiveState { get; set; }
        protected IStateEvaluator<TData>[] States;
        protected int[][] StatesReferences;

        private int NextState(int transitionValue) => StatesReferences[ActiveState][transitionValue - 1];

        public virtual void OnStart(TData data) {
            ActiveState = 0;
            States[0].OnStart(data);
        }

        protected abstract int ExitStep(TData data, int nextState);

        public int Next(TData data) {
            int transitionValue;
            for (; ; ) {
                transitionValue = States[ActiveState].Next(data);
                if (transitionValue == 0) break;
                if (transitionValue > 0) {
                    transitionValue = NextState(transitionValue);
                    if (transitionValue == 0) break;
                    if (transitionValue > 0) {
                        ActiveState = transitionValue - 1;
                        States[ActiveState].OnStart(data);
                    }
                    else {
                        transitionValue = ExitStep(data, -transitionValue);
                        break;
                    }
                }
                else throw new Exception("Invalid Exit Value from nested StateEvaluator");
            }
            return transitionValue;
        }

        public int Next(TData data, int startAt) {
            ActiveState = startAt;
            return Next(data);
        }
    }
}
