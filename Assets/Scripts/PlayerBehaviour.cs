using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    public enum State
    {
        None,
        InGame,
        Death
    }

    [SerializeField]
    private Rigidbody2D _Rigidbody2D;

    [SerializeField]
    private float _WalkSpeed;

    /// <summary>現在のステート</summary>
    private State _CurrentState = State.None;
    /// <summary>現在のステートを取得</summary>
    public State GetCurrentState => _CurrentState;

    private void Update()
    {
        ChengeState(State.InGame);
        StateUpdate();
    }

    /// <summary>
    /// ステート毎のアップデート
    /// </summary>
    private void StateUpdate()
    {
        switch (_CurrentState)
        {
            case State.None:
                break;
            case State.InGame:
                if (_Rigidbody2D)
                    Walk();
                break;
            case State.Death:
                break;
        }
    }

    /// <summary>
    /// ステートの変更をする
    /// </summary>
    /// <returns>ステートが変更できたか</returns>
    private void ChengeState(State next)
    {
        var prev = _CurrentState;

        switch (next)
        {
            case State.None:
                break;
            case State.InGame:
                break;
            case State.Death:
                break;
        }

        _CurrentState = next;
    }

    /// <summary>
    /// 歩く
    /// </summary>
    private void Walk()
    {
        var velo = _Rigidbody2D.velocity;
        velo.x = _WalkSpeed;
        _Rigidbody2D.velocity = velo;
    }
}
