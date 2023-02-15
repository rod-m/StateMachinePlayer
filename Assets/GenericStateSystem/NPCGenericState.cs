namespace GenericStateSystem
{
    abstract public class NPCGenericState: IState
    {
        protected NPCBaseCharacter _character;
        protected GenericStateMachine _stateMachine;
        protected NPCGenericState(BaseCharacter _c, GenericStateMachine _s)
        {
            _character = _c as NPCBaseCharacter;
            _stateMachine = _s;
        }
        public abstract void BeginState();
        public abstract void UpdateState();
        public abstract void UpdatePhysicsState();
        public abstract void TransitionState();
        public abstract void EndState();
    }
}