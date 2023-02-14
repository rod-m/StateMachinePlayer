using GenericStateSystem;
using GenericStateSystem.ActionStates;
using UnityEngine;

public class PlayerStateDriven : BaseCharacter
{

    #region MonoBehaviour Callbacks
    public override void Start()
    {
 
        base.Start();
        
        defaultState = new MoveState(this, stateMachine);
        //stateMachine.InitState(defaultState);
        stateMachine.MakeTransition(defaultState);
    }
    #endregion MonoBehaviour Callbacks
   
}