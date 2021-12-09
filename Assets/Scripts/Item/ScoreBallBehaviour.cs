/// <summary>
/// アイテム(スコアボール)クラス
/// </summary>
public class ScoreBallBehaviour : ItemBase
{
    protected override void OnHit()
    {
        if (_ScoreManager)
        {
            _ScoreManager.AddScore(_AddScore);
        }
        Destroy(this.gameObject);
    }

    protected override void OnDestroy()
    {

    }
}
