using GenericStateSystem;
using GenericStateSystem.ActionStates;
using UnityEngine;

namespace DefaultNamespace
{
    public class NPCController : BaseCharacter
    {
        #region MonoBehaviour Callbacks
        
        public override void Start()
        {
 
            base.Start();
        
            defaultState = new PatrolState(this, stateMachine);
            //stateMachine.InitState(defaultState);
            stateMachine.MakeTransition(defaultState);
        }
        #endregion MonoBehaviour Callbacks
    }
}