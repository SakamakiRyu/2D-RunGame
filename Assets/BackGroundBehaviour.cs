using UnityEngine;

public class BackGroundBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _AddValue;

    private void OnBecameInvisible()
    {
        // var nextPos = Camera.main.worldToScreenPosition();
        var nextPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        // �E�[�ɗ���悤�ɕ␳����
        nextPosition.x = nextPosition.x + _AddValue;
        // y���W�͕ύX���Ȃ�
        nextPosition.y = this.transform.position.y;

        this.transform.position = nextPosition;
    }
}
