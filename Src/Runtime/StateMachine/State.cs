using System;

namespace LD.StateMachine
{
    public class State<TStateKey> where TStateKey : struct, Enum
    {
        public State(TStateKey key)
        {
            this.Key = key;
        }

        public TStateKey Key { get; }

        public void Enter()
        {
            OnStateEnter();
        }

        public void Update()
        {
            OnStateUpdate();
        }

        public void Exit()
        {
            OnStateExit();
        }
        
        protected virtual void OnStateEnter()
        {
        }

        protected virtual void OnStateUpdate()
        {
        }

        protected virtual void OnStateExit()
        {
        }
        
        
    }
}