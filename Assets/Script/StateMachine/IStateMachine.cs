public interface IStateMachine
{
    /// <summary>�X�e�[�g�ɓ��������ɌĂ΂��/// </summary>
    public abstract void Enter();
    /// <summary>�X�e�[�g����o�����ɌĂ΂��/// </summary>
    public abstract void Exit();
    /// <summary>�X�e�[�g���ɌĂ΂��/// </summary>
    public abstract void Update();
}
