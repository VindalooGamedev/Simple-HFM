using System;

namespace StateMachinesLab.DecisionTrees.WithActions.Recursive
{
    public class DTDichotomicNode<TData> : ITransition<TData, int>
    {
        private readonly Func<TData, bool> _condition;
        private readonly ITransition<TData, int> _onTrue, _onFalse;
        
        public DTDichotomicNode(Func<TData, bool> condition, ITransition<TData, int> onTrue, ITransition<TData, int> onFalse)
        {
            _condition = condition;
            _onTrue = onTrue;
            _onFalse = onFalse;
        }
        
        public int Evaluate(TData data)
            => (_condition(data)) ? _onTrue.Evaluate(data) : _onFalse.Evaluate(data);
    }
}
