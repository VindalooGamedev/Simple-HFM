using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Iterative
{
    /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DTNode/class'/>
    public struct DTNode<TData>
    {
        private readonly Func<TData, bool> _condition;
        private readonly int _condIsTrue, _condIsFalse;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DTNode/ctor'/>
        public DTNode(Func<TData, bool> condition, int condIsTrue, int condIsFalse)
        {
            _condition = condition;
            _condIsTrue = condIsTrue;
            _condIsFalse = condIsFalse;
        }

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Iterative/DTNode/Evaluate'/>
        public int Evaluate(TData data) => (_condition(data)) ? _condIsTrue : _condIsFalse;
    }
}
