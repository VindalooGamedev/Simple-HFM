using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Recursive
{
    public class DTDichotomicNode<TData, T> : ITransition<TData, T>
    {
        private readonly Func<TData, bool> _condition;
        private readonly ITransition<TData, T> _onTrue, _onFalse;
        
        public DTDichotomicNode(Func<TData, bool> condition, ITransition<TData, T> onTrue, ITransition<TData, T> onFalse)
        {
            _condition = condition;
            _onTrue = onTrue;
            _onFalse = onFalse;
        }
        
        public T Evaluate(TData data)
            => (_condition(data)) ? _onTrue.Evaluate(data) : _onFalse.Evaluate(data);
    }
}
