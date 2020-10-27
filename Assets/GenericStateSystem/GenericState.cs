using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericStateSystem
{
    public abstract class GenericState : IState
    {
        protected BaseCharacter _character;
        protected GenericStateMachine _stateMachine;

        protected GenericState(BaseCharacter _c, GenericStateMachine _s)
        {
            _character = _c;
            _stateMachine = _s;
        }

        public virtual void BeginState()
        {
        }

        public void TransitionState()
        {
   
        }
        public void UpdateState()
        {
        }

        public virtual void EndState()
        {
        }

        public virtual void MovementControl()
        {
        }
        
        public virtual void PhysicsControl()
        {
        }
    }
}
