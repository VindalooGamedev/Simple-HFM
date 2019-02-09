using System;

namespace StateMachinesLab.DecisionTrees.WithActions.Recursive
{
    public class DTNode<TData> : ITransition<TData, int>
    {
        private readonly Func<TData, int> _condition;
        private readonly ITransition<TData, int>[] _transitions;

        public DTNode(Func<TData, int> condition, ITransition<TData, int>[] transitions)
        {
            _condition = condition;
            _transitions = transitions;
        }

        public int Evaluate(TData data) => _transitions[_condition(data)].Evaluate(data);
    }
}
