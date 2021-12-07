using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    #region Defiene
    public enum State
    {
        None,
        InGame,
        Death
    }

    public enum InGameState
    {
        None,
        Run,
        Jump
    }
    #endregion

    #region Serialize Field
    [SerializeField]
    private Rigidbody2D _Rigidbody2D;

    [SerializeField]
    private float _MoveSpeed;

    [SerializeField]
    private float _LineLength;

    [SerializeField]
    private float _JumpPower;
    #endregion

    #region Private Field
    /// <summary>現在のステート</summary>
    private State _CurrentState = State.None;
    /// <summary>現在のゲーム内のステート</summary>
    private InGameState _CurrentInGameState = InGameState.None;
    #endregion

    #region Property
    /// <summary>現在のステートを取得</summary>
    public State GetCurrentState => _CurrentState;
    /// <summary>現在のゲーム内ステートを取得</summary>
    public InGameState GetInGameState => _CurrentInGameState;
    #endregion

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
                Move();
                Jump();
                break;
            case State.Death:
                break;
        }
    }

    /// <summary>
    /// ステートの変更をする
    /// </summary>
    /// <param name="next">変更先のステート</param>
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
    /// 動く(オートラン)
    /// </summary>
    private void Move()
    {
        if (_Rigidbody2D == null) return;

        var velo = _Rigidbody2D.velocity;
        velo.x = _MoveSpeed;
        _Rigidbody2D.velocity = velo;
    }

    /// <summary>
    /// ジャンプする
    /// </summary>
    private void Jump()
    {
        if (!_Rigidbody2D) return;
        if (!IsGrounded()) return;

        if (Input.GetButtonDown("Jump"))
        {
            var velo = _Rigidbody2D.velocity;
            velo.y = _JumpPower;
            _Rigidbody2D.velocity = velo;
        }
    }

    /// <summary>
    /// 地面との接地判定
    /// </summary>
    /// <returns>接地しているか</returns>
    private bool IsGrounded()
    {
        // 接地判定をするレイヤーを指定
        var layer = LayerMask.GetMask("Ground");

        var hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down, _LineLength, layer);
        if (!hitInfo) return false;
        return true;
    }
}
