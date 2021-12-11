using UnityEngine;

public class BackGroundBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _AddValue;

    private void OnBecameInvisible()
    {
        // var nextPos = Camera.main.worldToScreenPosition();
        var nextPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        // 右端に来るように補正する
        nextPosition.x = nextPosition.x + _AddValue;
        // y座標は変更しない
        nextPosition.y = this.transform.position.y;

        this.transform.position = nextPosition;
    }
}
