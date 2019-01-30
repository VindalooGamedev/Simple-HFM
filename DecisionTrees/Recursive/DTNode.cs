using System;

namespace DecisionTrees.Recursive
{
    public class DTNode<TData> : IDTNode<TData>
    {
        private readonly Func<TData, bool> _condition;
        private readonly IDTNode<TData> _onTrue, _onFalse;

        public DTNode(Func<TData, bool> condition, IDTNode<TData> onTrue, IDTNode<TData> onFalse) {
            _condition = condition;
            _onTrue = onTrue;
            _onFalse = onFalse;
        }

        public int Evaluate(TData data)
            => (_condition(data)) ? _onTrue.Evaluate(data) : _onFalse.Evaluate(data);
    }
}
