namespace GenericStateSystem
{
    public interface IState
    {
        void BeginState();
        void TransitionState();
        void UpdateState();
        void EndState();
        
    }
}