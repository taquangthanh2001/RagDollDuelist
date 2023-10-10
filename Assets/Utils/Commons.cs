using Enemy;
using Player;

public static class Commons
{
    public static void SetSatus(bool isActive)
    {
        HpPlayer.Instance.SetStatusActiveHpBar(isActive);
        HpEnemy.Instance.SetStatusActiveHpBar(isActive);
    }
}