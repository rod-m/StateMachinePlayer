using GenericStateSystem.ActionStates;
using UnityEngine;

namespace GenericStateSystem
{
    [RequireComponent(typeof(Animator))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        #region Variables

        [HideInInspector] public Animator anim;
        [HideInInspector] public Rigidbody rb;
        public float collisionOverlapRadius = 0.1f;
        public LayerMask whatIsGround;

        #endregion Variables

        #region States

        public DefaultState defaultState;

        #endregion

        #region StateMachineVariables

        public GenericStateMachine stateMachine;

        #endregion StateMachineVariables

        #region AbstractMethods

        public abstract void Move(Vector2 _move);

        #endregion AbstractMethods

        #region Animation

        public void SetAnimationBool(int param, bool value)
        {
            anim.SetBool(param, value);
        }

        public void TriggerAnimation(int param)
        {
            anim.SetTrigger(param);
        }

        public bool IsGrounded()
        {
            return Physics.OverlapSphere(transform.position, collisionOverlapRadius, whatIsGround).Length > 0;
        }

        #endregion Animation

        #region MonoBehaviour Callbacks

        public virtual void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            stateMachine = new GenericStateMachine();
            defaultState = new DefaultState(this, stateMachine);
            stateMachine.InitState(defaultState);
        }

        private void Update()
        {
            stateMachine.ActiveState.UpdateState();
        }
        private void FixedUpdate(){    
            stateMachine.ActiveState.PhysicsControl();
        }
        #endregion MonoBehaviour Callbacks
    }
}