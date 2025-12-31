using UnityEngine;

public class PlayerRunState : State
{
    private PlayerStateMachine playerContext;
    private PlayerStateFactory playerFactory;
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory pFactory) : base(currentContext, pFactory)
    {
        playerContext = currentContext;
        playerFactory = pFactory;
    }
    public override void EnterState()
    {
        playerContext.Anim.SetBool("isRunning", true);
        playerContext.AppliedMovementX = playerContext.CurrentMovementInput.x * playerContext.RunSpeed;
        
    }
    public override void UpdateState()
    {
        playerContext.AppliedMovementX = playerContext.CurrentMovementInput.x * playerContext.RunSpeed;
        
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        playerContext.Anim.SetBool("isRunning", false);
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
        }  else if (!playerContext.IsMovementPressed)
        {
            SwitchState(playerFactory.Idle());
        } else if (playerContext.IsMovementPressed && !playerContext.IsRunPressed)
        {   
            SwitchState(playerFactory.Walk());
        }
    }
}
