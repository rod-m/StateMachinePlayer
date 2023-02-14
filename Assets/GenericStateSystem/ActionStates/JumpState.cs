using UnityEngine;

namespace GenericStateSystem.ActionStates
{
    public class JumpState : GenericState
    {
        private Animator _anim;
        public float JumpForce = 10f;
        private int _startJump = 0;
        public JumpState(BaseCharacter _c, GenericStateMachine _s) : base(_c, _s)
        {
        }

        public override void BeginState()
        {
            // set anim
            _startJump = 0;
            _anim = _character.anim;
            if (_character.IsGrounded())
            {
                _anim.applyRootMotion = false;
                _character.rb.AddForce(Vector3.up * _character.jumpForce, ForceMode.Impulse);
            }
            _anim.SetTrigger("Jump");
           
           
        }

        public override void UpdateState()
        {
        }

        public override void UpdatePhysicsState()
        {
            // use raycast to trigger before ground hit
            RaycastHit hit;
            //float distToGround = 999999999f;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(_character.transform.position, _character.transform.TransformDirection(Vector3.down), out hit, 3f, _character.whatIsGround))
            {
                Debug.DrawRay(_character.transform.position, _character.transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                if (_character.rb.velocity.y < -0.1f && hit.distance < 1.75f)
                {
                    Debug.Log($"Did Hit dist {hit.distance} velocity y {_character.rb.velocity.y}");

                    _character.stateMachine.MakeTransition(_character.defaultState);
                }
            }

            /*if (_character.IsGrounded() && _startJump > 90)
            {
                // return to move state
                Debug.Log($"_startJump {_startJump}");
                
                _character.stateMachine.MakeTransition(_character.defaultState);
            }*/

            _startJump ++;
        }

        public override void TransitionState()
        {
            
        }

        public override void EndState()
        {
            // trigger land animation... 
            _startJump = 0;
            _anim.SetTrigger("Landed");
            _anim.applyRootMotion = true;
        }
    }
}