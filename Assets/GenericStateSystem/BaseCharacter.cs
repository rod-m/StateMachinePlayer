using System;
using GenericStateSystem.ActionStates;
using UnityEngine;

namespace GenericStateSystem
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseCharacter : MonoBehaviour
    {
        #region Variables
        public bool useCharacterForward = false;
        [HideInInspector] public Animator anim;
        [HideInInspector] public Rigidbody rb;
     
        public float collisionOverlapRadius = 0.1f;
        public LayerMask whatIsGround;
        public float jumpForce = 3f;
        #endregion Variables

        #region States

        public IState defaultState;

        #endregion

        #region StateMachineVariables

        public GenericStateMachine stateMachine;

        #endregion StateMachineVariables

        #region Animation
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

        void Update()
        {
            stateMachine.ActiveState.UpdateState();
        }
    
        private void FixedUpdate()
        {
            stateMachine.ActiveState.UpdatePhysicsState();
        }

        #endregion MonoBehaviour Callbacks
    }
}