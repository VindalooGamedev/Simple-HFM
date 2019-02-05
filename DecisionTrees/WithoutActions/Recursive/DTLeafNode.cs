using System;

namespace StateMachinesLab.DecisionTrees.WithoutActions.Recursive
{
    /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/class'/>
    public class DTLeafNode<TData, T> : ITransition<TData, T>
    {
        private readonly T _value;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/ctor'/>
        public DTLeafNode(T value) => _value = value;

        /// <include file = 'docs/StatesLab.xml' path='doc/DecisionTree/Recursive/DecisionTree/Evaluate'/>
        public T Evaluate(TData data) => _value;
    }
}
