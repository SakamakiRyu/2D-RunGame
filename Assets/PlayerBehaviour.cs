using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _Rigidbody2D;

    [SerializeField]
    private float _WalkSpeed;

    private void Update()
    {
        if (_Rigidbody2D)
        {
            Walk();
        }
    }

    /// <summary>
    /// •à‚­
    /// </summary>
    private void Walk()
    {
        var velo = _Rigidbody2D.velocity;
        velo.x = _WalkSpeed;
        _Rigidbody2D.velocity = velo;
    }
}
