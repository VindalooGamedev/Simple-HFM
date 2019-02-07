using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Recursive
{
    public class DTLeafNode<TData, T> : ITransition<TData, T>
    {
        private readonly T _value;
        
        public DTLeafNode(T value) => _value = value;
        
        public T Evaluate(TData data) => _value;
    }
}
