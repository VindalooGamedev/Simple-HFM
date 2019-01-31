using System;

namespace StateMachinesLab.DecisionTrees.Recursive
{
    public class DTNode<TData> : ITransition<TData>
    {
        private readonly Func<TData, bool> _condition;
        private readonly ITransition<TData> _onTrue, _onFalse;

        public DTNode(Func<TData, bool> condition, ITransition<TData> onTrue, ITransition<TData> onFalse)
        {
            _condition = condition;
            _onTrue = onTrue;
            _onFalse = onFalse;
        }

        public int Evaluate(TData data)
            => (_condition(data)) ? _onTrue.Evaluate(data) : _onFalse.Evaluate(data);
    }
}
