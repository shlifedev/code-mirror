using System;

namespace LD.StateMachine
{
    public abstract class State<TStateKey> where TStateKey : struct, Enum
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

        protected abstract void OnStateEnter();
        protected abstract void OnStateUpdate();
        protected abstract void OnStateExit();


        public override string ToString() => "State "+this.Key.ToString();
    }
}