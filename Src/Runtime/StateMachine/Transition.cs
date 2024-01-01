using System;

namespace LD.StateMachine
{
    public class Transition<TStateKey>
        where TStateKey : struct, Enum
    {
        public Func<bool> transitionLambda = null;
        private StateMachine<TStateKey> RootStateMachine { get; }

        public TStateKey Src { get; set; }
        public TStateKey Dest { get; set; }

        public Transition(TStateKey src, TStateKey dest, Func<bool> lambda = null)
        {
            this.Src = src;
            this.Dest = dest; 
            this.transitionLambda = lambda;
        }

        protected bool CheckTransition()
        {
            if (transitionLambda != null) 
                return transitionLambda();
            return true;
        }

        public bool CanTransition()
        {     
            if (transitionLambda != null) 
                return transitionLambda();
            else
            { 
                return CheckTransition();
            } 
        }
    }
}