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
        
        [HideInInspector] public Animator anim;
        [HideInInspector] public Rigidbody rb;
     
       
        #endregion Variables

        #region States

        public IState defaultState;

        #endregion

        #region StateMachineVariables

        public StateMachine stateMachine;

        #endregion StateMachineVariables

        #region MonoBehaviour Callbacks

        public virtual void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            stateMachine = new StateMachine();
            defaultState = new DefaultState(this, stateMachine);
            stateMachine.InitState(defaultState);
        }

        void Update()
        {
            stateMachine.ActiveState.TransitionState();
            stateMachine.ActiveState.UpdateState();

        }
    
        private void FixedUpdate()
        {
            stateMachine.ActiveState.UpdatePhysicsState();
        }

        #endregion MonoBehaviour Callbacks
    }
}