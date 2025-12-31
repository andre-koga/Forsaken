public abstract class StateFactory
{
    protected StateMachine context;

    public StateFactory(StateMachine currentContext)
    {
        context = currentContext;
    }

    public abstract State Idle();
    public abstract State Walk();
    public abstract State Attack();
    public abstract State Hurt();

}
