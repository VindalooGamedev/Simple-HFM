using System;

namespace HFM {
    /// <summary>
    /// Esta clase define un nódo de las máquinas de estado jerárquicas. Estos nodos pueden usarse como
    /// la raíz o un estado intermedio dentro de la jerarquía, usando los estados como nodos hoja.
    /// 
    /// Fases de comportamiento:
    ///  + Fase inicial: Ejecutando OnStart Se prepara para el primer estado que coindice con el estado
    ///    de entrada.
    ///    
    ///  + Fase en bucle: En esta fase cada vez que se llama a next el estado actual de la lógica se 
    ///    actualiza pudiendo cambiar de estado y volver a un nodo anterior de la jerarquía.
    ///    
    ///  + Fase final: Debido a los valores devueltos por los nodos hijos el proceso termina y este 
    ///    nodo devuelve un valor que define el tipo de término que ha tenido el proceso.
    /// 
    /// Comportamiento:
    ///    El proceso de inicialización está asociado directamente con OnStart, cuando se ejecuta el 
    ///    método OnStart se asocia el primer estado como el 0 y luego se llama al OnStart del hijo,
    ///    de modo que depende de donde se llame a base.OnStart el orden de adaptación al primer estado
    ///    sucederá en un orden u otro.
    ///    
    ///    El el proceso de ejecución se cubren las fases de bucle y final funciona de la siguiente manera.
    ///    Al llamarse a Next este nodo llama al Next del nodo activo y dependiendo del valor de retorno
    ///    este nodo actuará de una forma u otra.
    ///    El valor obtenido valorDeTransición (inicial) no puede ser negativo, los valores viables son:
    ///     + Si valorDeTransición igualQue 0: el estado activo se mantiene.
    ///     + Si valorDeTransición mayorQue 0: el valor devuelto se consulta en la tabla de transición y se
    ///       obtiene el valorDeTransición (final).
    ///       - Si el valorDeTransición igualQue 0: el estado activo se mantiene.
    ///       - Si el valorDeTransición menorQue 0: Es una transición de salida y se sale de este nodo de
    ///         transición con el valor devuelto con ExitStep al que se le pasa el valorDeTransición con 
    ///         signo cambiado (de esta forma el nodo padre elegirá el estado con su tabla de transición).
    ///         En caso de que el valor devuelto sea de la raíz de la estructura este valor de salida puede
    ///         servir para recordar desde que estado se ha salido si es que esto es importante.
    ///       - Si el valorDeTransición mayorQue 0: Es una transición interna por lo que cambiará de 
    ///         nodo activo y se llamará a OnStart para inicializarlo antes de ser llamado en el mismo 
    ///         ciclo de ejecución.
    /// </summary>
    /// <typeparam name="TData">Data managed by the Machine</typeparam>
    public abstract class Machine<TData> : IStateEvaluator<TData> {
        public int ActiveState { get; set; }
        protected IStateEvaluator<TData>[] States;
        protected int[][] StatesReferences;

        private int NextState(int transitionValue) => StatesReferences[ActiveState][transitionValue - 1];

        public virtual void OnStart(TData data) {
            ActiveState = 0;
            States[0].OnStart(data);
        }

        protected abstract int ExitStep(TData data, int nextState);

        public int Next(TData data) {
            int transitionValue;
            for (; ; ) {
                transitionValue = States[ActiveState].Next(data);
                if (transitionValue == 0) break;
                if (transitionValue > 0) {
                    transitionValue = NextState(transitionValue);
                    if (transitionValue == 0) break;
                    if (transitionValue > 0) {
                        ActiveState = transitionValue - 1;
                        States[ActiveState].OnStart(data);
                    }
                    else {
                        transitionValue = ExitStep(data, -transitionValue);
                        break;
                    }
                }
                else throw new Exception("Invalid Exit Value from nested StateEvaluator");
            }
            return transitionValue;
        }

        public int Next(TData data, int startAt) {
            ActiveState = startAt;
            return Next(data);
        }
    }
}
