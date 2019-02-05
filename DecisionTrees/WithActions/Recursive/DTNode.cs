using System;

namespace StateMachinesLab.DecisionTrees.WithActions.Recursive
{
    /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/class'/>
    public class DTNode<TData> : ITransition<TData>
    {
        private readonly Func<TData, bool> _condition;
        private readonly ITransition<TData> _onTrue, _onFalse;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/ctor'/>
        public DTNode(Func<TData, bool> condition, ITransition<TData> onTrue, ITransition<TData> onFalse)
        {
            _condition = condition;
            _onTrue = onTrue;
            _onFalse = onFalse;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/Evaluate'/>
        public int Evaluate(TData data)
            => (_condition(data)) ? _onTrue.Evaluate(data) : _onFalse.Evaluate(data);
    }
}
