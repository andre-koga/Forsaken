using UnityEngine;

public class PlayerIdleState : State
{
    private PlayerStateMachine playerContext;
    private PlayerStateFactory playerFactory;
    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory pFactory) : base(currentContext, pFactory)
    {
        playerContext = currentContext;
        playerFactory = pFactory;
    }
    public override void EnterState()
    {
        playerContext.Anim.SetBool("isIdle", true);
        playerContext.AppliedMovementX = 0f;
        playerContext.AppliedMovementY = 0f;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        playerContext.Anim.SetBool("isIdle", false);
    }

    public override void CheckSwitchStates()
    {
        if (playerContext.IsHurt)
        {
            SwitchState(playerFactory.Hurt());
        }
        else if (playerContext.IsHitPressed)
        {
            SwitchState(playerFactory.Attack());
        } else if (playerContext.Grounded && playerContext.IsJumpPressed)
        {
            SwitchState(playerFactory.Jump());
        } else if (playerContext.IsMovementPressed && playerContext.IsRunPressed)
        {
            SwitchState(playerFactory.Run());
        } else if (playerContext.IsMovementPressed)
        {   
            SwitchState(playerFactory.Walk());
        } 
    }
}
