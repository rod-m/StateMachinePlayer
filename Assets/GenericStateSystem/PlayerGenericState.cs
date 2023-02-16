namespace GenericStateSystem
{
    abstract public class PlayerGenericState:IState
    {
        protected PlayerBaseCharacter _character;
        protected StateMachine _stateMachine;
        protected PlayerGenericState(BaseCharacter _c, StateMachine _s)
        {
            _character = _c as PlayerBaseCharacter;
            _stateMachine = _s;
        }
        public abstract void BeginState();
        public abstract void UpdateState();
        public abstract void UpdatePhysicsState();
        public abstract void TransitionState();
        public abstract void EndState();
    }
}