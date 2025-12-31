using UnityEngine;

public class PlayerJumpState : State
{
    private PlayerStateMachine playerContext;
    private PlayerStateFactory playerFactory;
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory pFactory) : base(currentContext, pFactory)
    {
        playerContext = currentContext;
        playerFactory = pFactory;
    }
    public override void EnterState()
    {
        playerContext.Anim.SetBool("isJumping", true);
        playerContext.Grounded = false;
        playerContext.AppliedMovementX = playerContext.CurrentMovementInput.x * playerContext.MoveSpeed / 3f;
    }
    public override void UpdateState()
    {
        playerContext.AppliedMovementX = playerContext.CurrentMovementInput.x * playerContext.MoveSpeed;
        playerContext.AppliedMovementY = 0f ;
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        playerContext.Anim.SetBool("isJumping", false);
        playerContext.Grounded = true;
    }

    public override void CheckSwitchStates()
    {
        if (playerContext.IsHurt)
        {
            SwitchState(playerFactory.Hurt());
        } else if (playerContext.Grounded && !playerContext.IsMovementPressed )
        {
            SwitchState(playerFactory.Idle());
        } else if (playerContext.Grounded && !playerContext.IsRunPressed)
        {
            SwitchState(playerFactory.Walk());
        } else if (playerContext.Grounded && playerContext.IsRunPressed)
        {
            SwitchState(playerFactory.Run());
        }
    }
}
