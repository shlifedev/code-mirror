using UnityEngine;

namespace LD
{
    public interface ILDCharacterController
    {
        public bool IsFalling { get; set; }
        public bool IsGrounded { get; set; }
        public void Move(Vector3 position);
        public void Velocity(Vector3 dir);
        public void Jump(float power);
    }
}