    namespace GenericStateSystem
    {
        public interface IState
        {
            void BeginState();
            void UpdateState();
            void TransitionState();
            void EndState();
            
        }
    }