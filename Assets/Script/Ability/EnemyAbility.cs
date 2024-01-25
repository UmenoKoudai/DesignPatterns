public class EnemyAbility : IAbility
{
    public void Use(GameInfo info)
    {
        AudioManager.Instance.SEManager.SEPlay(AudioManager.SEState.Bomb);
        info.Player.GameEnd();
    }
}
