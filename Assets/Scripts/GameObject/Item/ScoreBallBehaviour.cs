/// <summary>
/// アイテム(スコアボール)クラス
/// </summary>
public class ScoreBallBehaviour : ItemBase
{
    /// <summary>スコアマネージャー</summary>
    private ScoreManager _ScoreManager;

    private void Start()
    {
        _ScoreManager = FindObjectOfType<ScoreManager>();
    }

    /// <summary>
    /// スプライト表示のリセット
    /// </summary>
    public void ChengeSpriteState()
    {
        if (_Sprite) _Sprite.enabled = true;
    }

    protected override void OnHitPlayer()
    {
        // スプライトの表示を消す
        if (_Sprite) _Sprite.enabled = false;
        // スコアを加算する
        if (_ScoreManager) _ScoreManager.AddScore(_AddScore);
    }

    protected override void OnHitDestroyPoint()
    {
        ItemControl.Instance.OnDestroyedItem(this);
    }
}
