using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Iterative
{
    public struct DecisionTree<TData, T> : ITransition<TData, T>
    {
        private readonly DTDichotomicNode<TData>[] _nodes;
        private readonly T[] _values;
        
        public DecisionTree(DTDichotomicNode<TData>[] nodes, T[] values)
        {
            _nodes = nodes;
            _values = values;
        }
        
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
