using System;
namespace StateMachinesLab.DecisionTrees.WithoutActions.Iterative
{
    public struct DTNode<TData>
    {
        private readonly Func<TData, int> _condition;
        private readonly int[] _returnedValues;

        public DTNode(Func<TData, int> condition, int[] returnedValues)
        {
            _condition = condition;
            _returnedValues = returnedValues;
        }

        public int Evaluate(TData data) => _returnedValues[_condition(data)];
    }
}
