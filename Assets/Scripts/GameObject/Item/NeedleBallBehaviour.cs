/// <summary>
/// 針ボールクラス
/// </summary>
public class NeedleBallBehaviour : ItemBase
{
    protected override void OnHitPlayer()
    {
        GameManager.Instance.GameEnd?.Invoke();
    }

    protected override void OnHitDestroyPoint()
    {
        ItemControl.Instance.OnDestroyedItem(this);
    }
}
