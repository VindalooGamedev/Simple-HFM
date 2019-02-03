using System;

namespace StateMachinesLab.DecisionTrees.Iterative
{
    /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DecisionTree/class'/>
    public struct DecisionTree<TData> : ITransition<TData>
    {
        private readonly DTNode<TData>[] _nodes;
        private readonly Action<TData>[] _actions;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DecisionTree/ctor'/>
        public DecisionTree(DTNode<TData>[] nodes, Action<TData>[] actions)
        {
            _nodes = nodes;
            _actions = actions;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DecisionTree/Evaluate'/>
        public int Evaluate(TData data)
        {
            int currNode = 0;
            do
            {
                currNode = _nodes[currNode].Evaluate(data);
            } while (currNode >= 0);
            currNode = -currNode;
            _actions[--currNode]?.Invoke(data);
            return currNode;
        }
    }
}
