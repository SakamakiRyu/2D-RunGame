/// <summary>
/// �j�{�[���N���X
/// </summary>
public class NeedleBallBehaviour : ItemBase
{
    protected override void OnHit()
    {
        GameManager.Instance.GameEnd?.Invoke();
    }

    protected override void OnDestroy()
    {

    }
}
