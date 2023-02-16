using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericStateSystem
{
    public abstract class GenericState : IState
    {
        protected BaseCharacter _character;
        protected StateMachine _stateMachine;
        protected GenericState(BaseCharacter _c, StateMachine _s)
        {
            _character = _c;
            _stateMachine = _s;
        }
        public abstract void BeginState();
        public abstract void UpdateState();
        public abstract void UpdatePhysicsState();
        public abstract void TransitionState();
        public abstract void EndState();

    }
}
