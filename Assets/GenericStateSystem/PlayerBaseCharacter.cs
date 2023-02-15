using UnityEngine;
namespace GenericStateSystem
{
    public class PlayerBaseCharacter: BaseCharacter
    {
        public bool useCharacterForward = false;
        public float collisionOverlapRadius = 0.1f;
        public LayerMask whatIsGround;
      
        public float jumpForce = 3f;
        public bool IsGrounded()
        {
            return Physics.OverlapSphere(transform.position, collisionOverlapRadius, whatIsGround).Length > 0;
        }
    }
}