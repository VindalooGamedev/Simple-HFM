using System;

namespace StateMachinesLab.DecisionTrees.Recursive
{
    /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/class'/>
    public class DTLeafNode<TData> : ITransition<TData>
    {
        private readonly Action<TData> _action;
        private readonly int _state;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/ctor'/>
        public DTLeafNode(Action<TData> action, int state)
        {
            _action = action;
            _state = state;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/Evaluate'/>
        public int Evaluate(TData data)
        {
            _action?.Invoke(data);
            return _state;
        }
    }
}
