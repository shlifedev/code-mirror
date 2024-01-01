using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD.StateMachine.Test
{
    public class SMTestBehaviour : MonoBehaviour
    {
        public class AState : State<STATE>
        {
            public AState(STATE key) : base(key)
            {
            }

            protected override void OnStateEnter()
            {
               Debug.Log($"Enter State {this.ToString()}");
            }

            protected override void OnStateExit()
            {
                Debug.Log($"Exit State {this.ToString()}");
            }

            protected override void OnStateUpdate()
            {
                Debug.Log($"Update State {this.ToString()}");
            }
        }
        public class BState : State<STATE>
        {
            public BState(STATE key) : base(key)
            {
            }

            protected override void OnStateEnter()
            {
                Debug.Log($"Enter State {this.ToString()}");
            }

            protected override void OnStateExit()
            {
                Debug.Log($"Exit State {this.ToString()}");
            }

            protected override void OnStateUpdate()
            {
                Debug.Log($"Update State {this.ToString()}");
            }
        }
        public class CState : State<STATE>
        {
            public CState(STATE key) : base(key)
            {
            }

            protected override void OnStateEnter()
            {
                Debug.Log($"Enter State {this.ToString()}");
            }

            protected override void OnStateExit()
            {
                Debug.Log($"Exit State {this.ToString()}");
            }

            protected override void OnStateUpdate()
            {
                Debug.Log($"Update State {this.ToString()}");
            }
        }
        public enum STATE
        {
            A,B,C
        }
        public StateMachine<STATE> sm;
        private void Awake()
        { 
            sm = new StateMachine<STATE>(new List<State<STATE>>()
            {
                new AState(STATE.A),
                new BState(STATE.B),
                new CState(STATE.C),
            }, STATE.A); 
            
            sm.AddTransition(new Transition<STATE>(STATE.A, STATE.B, () =>
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }));
            
        }

        private void Update()
        {
            sm.Tick(Time.deltaTime); 
        }

        private void OnGUI()
        {
            if (GUILayout.Button("To A"))
            {
                sm.ChangeState(STATE.A);
            }
            if (GUILayout.Button("To B"))
            {
                sm.ChangeState(STATE.B);
            }
            if (GUILayout.Button("To C"))
            {
                sm.ChangeState(STATE.C);
            }
        }
    }
}