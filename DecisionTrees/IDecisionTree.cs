namespace DecisionTrees
{
    public interface IDTNode<TData>
    {
        int Evaluate(TData data);
    }
}