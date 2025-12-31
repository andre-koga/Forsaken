public abstract class State 
{  protected StateMachine context;
   protected StateFactory factory;

   public State(StateMachine currentContext, StateFactory sFactory)
   {
      context = currentContext;
      factory = sFactory;
   }
   public abstract void EnterState();
   public abstract void UpdateState();
   public abstract void ExitState();
   public abstract void CheckSwitchStates();

   void UpdateStates(){}
   public void SwitchState(State newState)
   {
      ExitState();
      newState.EnterState();
      context.CurrentState = newState;
   }

}
