using UnityEngine;

namespace GenericStateSystem
{
    public class GenericStateMachine
    {
        public IState ActiveState { get; private set; }
        public void InitState(IState beginState)
        {
            ActiveState = beginState;
            beginState.BeginState();
        }
        public void MakeTransition(IState nextState)
        {
            Debug.Log($"MakeTransition {nextState.GetType().Name}");
            ActiveState.EndState();
            ActiveState = nextState;
            nextState.BeginState();
        }
    }
}