namespace GenericStateSystem
{
    public class GenericStateMachine
    {
        public GenericState ActiveState { get; private set; }
        public void InitState(GenericState beginState)
        {
            ActiveState = beginState;
            beginState.BeginState();
        }
        public void MakeTransitionState(GenericState nextState)
        {
            ActiveState.EndState();
            ActiveState = nextState;
            nextState.BeginState();
        }
    }
}