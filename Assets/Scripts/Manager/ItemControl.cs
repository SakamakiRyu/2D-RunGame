using UnityEngine;

/// <summary>
/// �A�C�e���̔z�u�𑀍삷��N���X
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
    /// �A�C�e�������ł������ɌĂ΂�鏈��
    /// </summary>
    public void OnDestroyedItem(ItemBase item)
    {
        SetItem(item);
    }

    /// <summary>
    /// �A�C�e����ݒ肷��
    /// </summary>
    private void SetItem(ItemBase item)
    {
        var go = item as ScoreBallBehaviour;
        if (go) go.ChengeSpriteState();

        var rand = Random.Range(0, _SpawnPoints.Length);
        item.transform.position = _SpawnPoints[rand].position;
    }
}
