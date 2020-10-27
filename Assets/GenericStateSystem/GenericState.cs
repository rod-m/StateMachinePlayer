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
        public abstract void BeginState();
        public abstract void UpdateState();
        public abstract void PhysicsControl();
        public abstract void TransitionState();
        public abstract void EndState();

    }
}
