using UnityEngine;

public class PlayerAttackState : State
{
    private PlayerStateMachine playerContext;
    private PlayerStateFactory playerFactory;
    public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateFactory pFactory) : base(currentContext, pFactory)
    {
        playerContext = currentContext;
        playerFactory = pFactory;
    }
    public override void EnterState()
    {
        playerContext.Anim.SetBool("isAttacking", true);
        playerContext.AppliedMovementX = 0f;
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void ExitState()
    {
        playerContext.Anim.SetBool("isAttacking", false);
    }

    public override void CheckSwitchStates()
    {
        if (playerContext.IsHurt)
        {
            SwitchState(playerFactory.Hurt());
        }
        else if (!playerContext.AttackFinished)
        {
            return;
        }
        playerContext.AttackFinished = false; 
        if (playerContext.IsMovementPressed && playerContext.IsRunPressed)
        {
            SwitchState(playerFactory.Run());
        } else if (playerContext.IsMovementPressed)
        {   
            SwitchState(playerFactory.Walk());
        } else
        {
            SwitchState(playerFactory.Idle());
        }
    }
}
