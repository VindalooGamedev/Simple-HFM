using System;

namespace DecisionTrees.Recursive
{
    public class DTLeafNode<TData> : IDTNode<TData>
    {
        private readonly Action<TData> _action;
        private readonly int _state;

        public DTLeafNode(Action<TData> action, int state) {
            _action = action;
            _state = state;
        }

        public int Evaluate(TData data) {
            _action?.Invoke(data);
            return _state;
        }
    }
}
