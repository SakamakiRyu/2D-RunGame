using UnityEngine;

/// <summary>
/// アイテムの配置を操作するクラス
/// </summary>
public class ItemControl : MonoBehaviour
{
    public static ItemControl Instance = null;

    [SerializeField]
    private Transform[] _SpawnPoints;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// アイテムが消滅した時に呼ばれる処理
    /// </summary>
    public void OnDestroyedItem(ItemBase item)
    {
        SetItem(item);
    }

    /// <summary>
    /// アイテムを設定する
    /// </summary>
    private void SetItem(ItemBase item)
    {
        var go = item as ScoreBallBehaviour;
        if (go) go.ChengeSpriteState();

        var rand = Random.Range(0, _SpawnPoints.Length);
        item.transform.position = _SpawnPoints[rand].position;
    }
}
