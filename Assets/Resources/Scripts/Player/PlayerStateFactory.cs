public class PlayerStateFactory : StateFactory
{

    PlayerStateMachine playerContext;
    public PlayerStateFactory(PlayerStateMachine currentContext) : base((StateMachine)currentContext)
    {
        playerContext = currentContext;
    }
    public override State Idle()
    {
        return new PlayerIdleState(playerContext, this);
    }
    public override State Walk()
    {
        return new PlayerWalkState(playerContext, this);
    }
    public State Run()
    {
        return new PlayerRunState(playerContext, this);
    }

    public State Jump()
    {
        return new PlayerJumpState(playerContext, this);
    }

    public override State Attack()
    {
        return new PlayerAttackState(playerContext, this);
    }

    public override State Hurt()
    {
        return new PlayerHurtState(playerContext, this);
    }

}
