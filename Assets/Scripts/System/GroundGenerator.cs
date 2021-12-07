using UnityEngine;

/// <summary>
/// ínñ Çê∂ê¨Ç∑ÇÈÉNÉâÉX
/// </summary>
public class GroundGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _GroundPrefabs;

    [SerializeField]
    private PlayerBehaviour _Player;

    private void Awake()
    {
    }

    private void OnCreateGround()
    {
        var rnd = Random.Range(0, _GroundPrefabs.Length - 1);

        var go = Instantiate(_GroundPrefabs[rnd]);
        go.transform.position = new Vector3(_Player.transform.position.x + 20, -3.5f, 0);
    }
}
