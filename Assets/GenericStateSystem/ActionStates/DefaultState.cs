namespace GenericStateSystem.ActionStates
{
    public class DefaultState : GenericState
    {
        public DefaultState(BaseCharacter c, GenericStateMachine s) : base(c, s)
        {
        }
        public override void BeginState() { }

        public override void UpdateState()
        {
            // input control
        }

        public override void UpdatePhysicsState()
        {
            // fixedUpdates
        }

        public override void TransitionState()
        {
            // something that changes state here
        } 
        public override void EndState() { }
    }
}