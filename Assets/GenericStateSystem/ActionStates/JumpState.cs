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
            _anim.SetTrigger("Jump");
            if (_character.IsGrounded())
            {
                _character.rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
           
        }

        public override void UpdateState()
        {
        }

        public override void UpdatePhysicsState()
        {
            if (_character.IsGrounded() && _startJump > 90)
            {
                // return to move state
                Debug.Log($"_startJump {_startJump}");
                
                _character.stateMachine.MakeTransition(_character.defaultState);
            }

            _startJump ++;
        }

        public override void TransitionState()
        {
        }

        public override void EndState()
        {
            // trigger land animation... 
        }
    }
}