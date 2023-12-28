using System;
using UnityEngine;

namespace LD
{
    public class CharacterInputController
    {
        public enum Type
        {
            AI, Player
        }
    }

    public struct CharacterVars
    { 
        public Vector3 velocity;
        public float currentSpeed;
        public float maxSpeed;
        public float gravity; 
    }
 
    public class CharacterController : MonoBehaviour
    {
        private Vector3 _velocity;
        protected virtual bool IsGrounded { get; set; }

        protected virtual void PreRender()
        {
            
        }

        protected virtual void OnUpdate()
        {
            
        }

        protected virtual void OnPhysicsUpdate()
        {
            
        }

        protected virtual void OnRendered()
        {
            
        }

        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
         
        }

        private void LateUpdate()
        {
            OnRendered();
        }

        private void Update()
        {
            OnUpdate();
        }

        private void FixedUpdate()
        {
            OnPhysicsUpdate();
        }
    }
}