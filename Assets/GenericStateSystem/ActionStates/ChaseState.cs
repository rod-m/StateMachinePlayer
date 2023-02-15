using UnityEngine;

namespace GenericStateSystem.ActionStates
{
    public class ChaseState: NPCGenericState
    {
        private Transform chasingCharacter;
        private Quaternion _lookRotation;
        private float _rotationSpeed = 5f;
        public ChaseState(BaseCharacter _c, GenericStateMachine _s) : base(_c, _s)
        {
        }

        public override void BeginState()
        {   
            Debug.Log("Chase Me");
            Vector3 p1 = _character.transform.position + Vector3.up;
        
            RaycastHit hit;
            Debug.DrawRay(p1,
                _character.transform.TransformDirection(Vector3.forward) * 6f, Color.red);
            if (Physics.SphereCast(p1, 1.5f, _character.transform.forward, out hit, 10, _character.whatToChase))
            {
                
                if (hit.distance < 4f)
                {
                    chasingCharacter = hit.transform;
                }
            }

          
        }

        public override void UpdateState()
        {
            
                // go here
                //find the vector pointing from our position to the target
                Vector3 _direction = (chasingCharacter.position - _character.transform.position).normalized;

                //create the rotation we need to be in to look at the target
                //_character.transform.rotation = Quaternion.LookRotation(_direction);
                _lookRotation = Quaternion.LookRotation(_direction);
                var eulerY = _lookRotation.eulerAngles.y;
                var euler = new Vector3(0, eulerY, 0);
                _character.transform.rotation = Quaternion.Slerp(_character.transform.rotation, Quaternion.Euler(euler),
                    Time.deltaTime * _rotationSpeed);
                _character.anim.SetFloat("Speed", 0.6f);
             
            
        }

        public override void UpdatePhysicsState()
        {
    
        }

        public override void TransitionState()
        {
            if (chasingCharacter == null)
            {
                var newState = new PatrolState(_character, _character.stateMachine);
                _character.stateMachine.MakeTransition(newState);
                return;
            }
            float dist = Vector3.Distance(_character.transform.position, chasingCharacter.position);
            if (dist > 6f)
            {
                //arrived
                Debug.Log($"Lost him  {chasingCharacter.name}");
                var newState = new PatrolState(_character, _character.stateMachine);
                _character.stateMachine.MakeTransition(newState);
                    
            } else if (dist < 1f)
            {
                //attack
                Debug.Log($"Attack him  {chasingCharacter.name}");
            }
        }

        public override void EndState()
        {

        }
    }
}