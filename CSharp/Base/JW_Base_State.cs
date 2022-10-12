public class JW_Base_IState
{
    public virtual string StateName { get; }
    public virtual void Entry() { }
    public virtual void Next() { }
    public virtual void Exit() { }
}

public abstract class JW_Base_State : JW_Base_IState
{
    public override string StateName { get { return this.GetType().Name; } }
    public override void Entry() { }
    public override void Next() { }
    public override void Exit() { }
}