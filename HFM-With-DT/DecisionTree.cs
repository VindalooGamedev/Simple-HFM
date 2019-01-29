using System;

namespace HFM.HFM_With_DT
{
    public struct DecisionTree<TData>
    {
        private readonly DTNode<TData>[] _nodes;
        private readonly Action<TData>[] _actions;

        public DecisionTree(DTNode<TData>[] nodes, Action<TData>[] actions) {
            _nodes = nodes;
            _actions = actions;
        }

        public int Evaluate(TData data) {
            int currNode = 0;
            do {
                currNode = _nodes[currNode].Evaluate(data);
            } while (currNode >= 0);
            currNode = -currNode;
            _actions[--currNode]?.Invoke(data);
            return currNode;
        }
    }
}
