using UnityEngine;

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
    /// ç¿ïWÇÃçXêVÇÇ∑ÇÈ
    /// </summary>
    private void PositionUpdate()
    {
        if (!_Player) return;

        var afterPos = this.transform.position;
        afterPos.x = _Player.transform.position.x;

        this.transform.position = afterPos;
    }
}
