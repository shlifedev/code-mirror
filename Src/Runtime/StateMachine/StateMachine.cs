using System;
using System.Collections.Generic;

namespace LD.StateMachine
{
 
    public sealed class StateMachine<TStateKey> : ITickable where TStateKey : struct, Enum
    { 
        private State<TStateKey> CurrentState { get; set; }
        private List<State<TStateKey>> States { get; }
        private Dictionary<TStateKey, State<TStateKey>> StatesMap;
        public List<Transition<TStateKey>> Transitions = new List<Transition<TStateKey>>();
        public StateMachine(List<State<TStateKey>> list, TStateKey initialState)
        {
            StatesMap = new Dictionary<TStateKey, State<TStateKey>>();
            this.States = list; 
            foreach (var state in States) 
                StatesMap[state.Key] = state; 
            CurrentState = StatesMap[initialState]; 
            CurrentState.Enter(); 
        }

        public void AddTransition(Transition<TStateKey> transition)
        {
            this.Transitions.Add(transition);
        }

        private void CheckTransition()
        { 
            foreach (var transition in this.Transitions)
            {
                if (transition.Src.Equals(CurrentState.Key))
                {
                    if (transition.CanTransition())
                    {
                        ChangeState(transition.Dest);
                        break;
                    }
                } 
            }
        }
        public void ChangeState(TStateKey key)
        {
            if (CurrentState != null)
            {
                CurrentState.Exit();
                if (StatesMap.TryGetValue(key, out var state))
                {
                    CurrentState = state;
                    state.Enter();
                }
                else
                {
                    throw new Exception($"State를 변경하려 하였으나 주어진 key가 잘못되었습니다. key to string => {key.ToString()}");
                }
            }
            else
            {
                throw new Exception($"현재 State 가 없습니다.");
            }
        }

        public void Tick(float dt)
        {
            if (CurrentState != null)
            {
                CheckTransition();
                CurrentState.Update();
            }
            else
            {
                throw new Exception("Current state is null");
            }
        }
    }
}