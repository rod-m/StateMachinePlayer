using UnityEngine;
namespace GenericStateSystem.ActionStates
{
    public class AttackState: NPCGenericState
    {
        private int cooloff = 190;
        private int lastAttack = 0;
        public AttackState(BaseCharacter _c, StateMachine _s) : base(_c, _s)
        {
        }

        public override void BeginState()
        {
            _character.anim.SetFloat("Speed", 0.0f);
            _character.anim.SetTrigger("DrawSword");
            lastAttack = -100; // delay strike until sword drawn
        }

        public override void UpdateState()
        {
            _character.FaceCurrentTarget(45f);
            Debug.DrawRay(_character.transform.position,
                _character.transform.TransformDirection(Vector3.forward) * 2f, Color.red);
            if (lastAttack > cooloff)
            {
                lastAttack = 0;
                // hit him
                _character.anim.SetTrigger("SwingSword");
            }

            lastAttack++;
            
        }

        public override void UpdatePhysicsState()
        {
    
        }

        public override void TransitionState()
        {
            float dist = Vector3.Distance(_character.transform.position, _character.currentTarget.position);
            if (dist > 3f)
            {
                //arrived
                Debug.Log($"Lost him  {_character.currentTarget.name}");
                var newState = new ChaseState(_character, _character.stateMachine);
                _character.stateMachine.MakeTransition(newState);
                    
            }
        }

        public override void EndState()
        {
            _character.anim.SetTrigger("SheathSword");
        }
    }
}