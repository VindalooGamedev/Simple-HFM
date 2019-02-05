using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Recursive
{
    /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/class'/>
    public class DTNode<TData, T> : ITransition<TData, T>
    {
        private readonly Func<TData, bool> _condition;
        private readonly ITransition<TData, T> _onTrue, _onFalse;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/ctor'/>
        public DTNode(Func<TData, bool> condition, ITransition<TData, T> onTrue, ITransition<TData, T> onFalse)
        {
            _condition = condition;
            _onTrue = onTrue;
            _onFalse = onFalse;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/Evaluate'/>
        public T Evaluate(TData data)
            => (_condition(data)) ? _onTrue.Evaluate(data) : _onFalse.Evaluate(data);
    }
}
