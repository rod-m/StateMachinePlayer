using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericStateSystem
{
    public abstract class GenericState
    {
        protected BaseCharacter character;
        protected GenericStateMachine stateMachine;

        protected GenericState(BaseCharacter _c, GenericStateMachine _s)
        {
            this.character = _c;
            this.stateMachine = _s;
        }

        public virtual void BeginState()
        {
        }

        public virtual void EndState()
        {
        }

        public virtual void MovementControl()
        {
        }

        public virtual void StateTransition()
        {
        }

        public virtual void PhysicsControl()
        {
        }
    }
}
