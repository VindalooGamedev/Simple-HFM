using System;

namespace StateMachinesLab.DecisionTrees.WithActions.Iterative
{
    public struct DTRootNode<TData> : ITransition<TData, int>
    {
        private readonly DTNode<TData>[] _nodes;
        private readonly Action<TData>[] _actions;
        
        public DTRootNode(DTNode<TData>[] nodes, Action<TData>[] actions)
        {
            _nodes = nodes;
            _actions = actions;
        }
        
        public int Evaluate(TData data)
        {
            int currNode = 0;
            do
            {
                currNode = _nodes[currNode].Evaluate(data);
            } while (currNode >= 0);
            currNode = (-currNode) - 1;
            _actions[currNode]?.Invoke(data);
            return currNode;
        }
    }
}
