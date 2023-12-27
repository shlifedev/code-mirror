using System;

namespace LD.StateMachine
{
    public abstract class Transition<TStateKey, TState>
        where TStateKey : struct, Enum
        where TState : State<TStateKey>
    {
        private StateMachine<TStateKey> RootStateMachine { get; }

        public Transition(StateMachine<TStateKey> rootStateMachine)
        {
            RootStateMachine = rootStateMachine;
        } 
        
        public void CheckTransition()
        {
            if (CanTransition())
            {
                // do transition
            }
            else
            {
                
            }
        }

        protected abstract bool CanTransition();
    }
}