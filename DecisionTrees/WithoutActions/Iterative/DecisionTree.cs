using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Iterative
{
    /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DecisionTree/class'/>
    public struct DecisionTree<TData, T> : ITransition<TData, T>
    {
        private readonly DTNode<TData>[] _nodes;
        private readonly T[] _values;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DecisionTree/ctor'/>
        public DecisionTree(DTNode<TData>[] nodes, T[] values)
        {
            _nodes = nodes;
            _values = values;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DecisionTree/Evaluate'/>
        public T Evaluate(TData data)
        {
            int currNode = 0;
            do
            {
                currNode = _nodes[currNode].Evaluate(data);
            } while (currNode >= 0);
            currNode = (-currNode) - 1;
            return _values[currNode];
        }
    }
}
