using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Iterative
{
    public struct DTNode<TData>
    {
        private readonly Func<TData, bool> _condition;
        private readonly int _condIsTrue, _condIsFalse;
        
        public DTNode(Func<TData, bool> condition, int condIsTrue, int condIsFalse)
        {
            _condition = condition;
            _condIsTrue = condIsTrue;
            _condIsFalse = condIsFalse;
        }
        
        public int Evaluate(TData data) => (_condition(data)) ? _condIsTrue : _condIsFalse;
    }
}
