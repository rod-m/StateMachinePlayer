using UnityEngine;

namespace GenericStateSystem.ActionStates
{
    public class ChaseState: NPCGenericState
    {

        private Quaternion _lookRotation;
        //private float _rotationSpeed = 5f;
        public ChaseState(BaseCharacter _c, GenericStateMachine _s) : base(_c, _s)
        {
        }

        public override void BeginState()
        {   
            Debug.Log("Chase Me");
          

          
        }

        public override void UpdateState()
        {
            _character.FaceCurrentTarget(0f);
                // go here
           
                _character.anim.SetFloat("Speed", _character.chaseSpeed);
             
            
        }

        public override void UpdatePhysicsState()
        {
    
        }

        public override void TransitionState()
        {
            if (_character.currentTarget == null)
            {
                var newState = new PatrolState(_character, _character.stateMachine);
                _character.stateMachine.MakeTransition(newState);
                return;
            }
            float dist = Vector3.Distance(_character.transform.position, _character.currentTarget.position);
            if (dist > 6f)
            {
                //arrived
                Debug.Log($"Lost him  {_character.currentTarget.name}");
                var newState = new PatrolState(_character, _character.stateMachine);
                _character.stateMachine.MakeTransition(newState);
                    
            } else if (dist < 2f)
            {
                //attack
                Debug.Log($"Attack him  {_character.currentTarget.name}");
                var newState = new AttackState(_character, _character.stateMachine);
                _character.stateMachine.MakeTransition(newState);
            }
        }

        public override void EndState()
        {

        }
    }
}