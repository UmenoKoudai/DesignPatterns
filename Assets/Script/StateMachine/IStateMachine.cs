public interface IStateMachine
{
    /// <summary>ステートに入った時に呼ばれる/// </summary>
    public abstract void Enter();
    /// <summary>ステートから出た時に呼ばれる/// </summary>
    public abstract void Exit();
    /// <summary>ステート中に呼ばれる/// </summary>
    public abstract void Update();
}
