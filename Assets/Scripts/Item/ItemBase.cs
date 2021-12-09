using UnityEngine;

/// <summary>
/// アイテムの抽象クラス
/// ※コライダーによる当たり判定を使うため、何らかのColliderの実装をする事。
/// 　そして、プロパティのIsTriggerにチェックを入れる事
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    protected int _AddScore;

    [SerializeField]
    protected ScoreManager _ScoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnHit();
        }
    }

    /// <summary>
    /// プレイヤーと接触した時に呼ばれる
    /// </summary>
    protected abstract void OnHit();

    protected abstract void OnDestroy();
}
