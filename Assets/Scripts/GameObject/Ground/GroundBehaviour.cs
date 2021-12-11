using UnityEngine;

/// <summary>
/// 地面の制御クラス
/// </summary>
public class GroundBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerBehaviour _Player;

    private void Start()
    {
        if (!_Player)
        {
            _Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        }
    }

    private void Update()
    {
        PositionUpdate();
    }

    /// <summary>
    /// 座標の更新をする
    /// </summary>
    private void PositionUpdate()
    {
        if (!_Player) return;

        var afterPos = this.transform.position;
        afterPos.x = _Player.transform.position.x + 4.0f;

        this.transform.position = afterPos;
    }
}
