using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Recursive
{
    public class DTNode<TData, T> : ITransition<TData, T>
    {
        private readonly Func<TData, int> _condition;
        private readonly ITransition<TData, T>[] _nextLayer;

        public DTNode(Func<TData, int> condition, ITransition<TData, T>[] nextLayer)
        {
            _condition = condition;
            _nextLayer = nextLayer;
        }

        public T Evaluate(TData data) => _nextLayer[_condition(data)].Evaluate(data);
    }
}
