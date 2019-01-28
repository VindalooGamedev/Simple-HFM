namespace HFM {
    /// <include file = 'docs/StatesLab.xml' path='doc/State/class'/>
    public abstract class State<TData> : IStateEvaluator<TData> {

        /// <include file = 'docs/StatesLab.xml' path='doc/State/OnStart'/>
        public abstract void OnStart(TData data);

        /// <include file = 'docs/StatesLab.xml' path='doc/State/Next'/>
        public abstract int Next(TData data);
    }
}
