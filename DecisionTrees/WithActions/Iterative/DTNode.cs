using System;

namespace StateMachinesLab.DecisionTrees.WithActions.Iterative
{
    public struct DTNode<TData>
    {
        private readonly Func<TData, int> _condition;
        private readonly int[] _returnedValue;

        public DTNode(Func<TData, int> condition, int[] returnedValue)
        {
            _condition = condition;
            _returnedValue = returnedValue;
        }

        public int Evaluate(TData data) => _returnedValue[_condition(data)];
    }
}
