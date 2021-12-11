using UnityEngine;

/// <summary>
/// アイテムの抽象クラス
/// ※コライダーによる当たり判定を使うため、何らかのColliderの実装をする事。
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    /// <summary>加算するスコア</summary>
    [SerializeField]
    protected int _AddScore;

    [SerializeField]
    protected SpriteRenderer _Sprite;

    protected virtual void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            OnHitDestroyPoint();
        }

        if (collision.CompareTag("Player"))
        {
            OnHitPlayer();
        }
    }

    /// <summary>
    /// プレイヤーと接触した時に呼ばれる
    /// </summary>
    protected abstract void OnHitPlayer();

    /// <summary>
    /// デストロイポイントに接触した時に呼ばれる
    /// </summary>
    protected abstract void OnHitDestroyPoint();
}
