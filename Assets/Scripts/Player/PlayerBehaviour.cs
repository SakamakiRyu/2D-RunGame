using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    #region Defiene
    public enum State
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
    #endregion

    #region Property
    /// <summary>現在のステートを取得</summary>
    public State GetCurrentState => _CurrentState;
    /// <summary>現在の速度ベクトルを取得</summary>
    public Vector3 GetVelocity => _Rigidbody2D.velocity;
    #endregion

    #region Unity Function
    private void Awake()
    {
        GameManager.Instance.GameStart += OnGameStart;
    }

    private void Start()
    {
    }

    private void Update()
    {
        StateUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CheckPoint"))
        {
        }
    }
    #endregion

    #region Public Function
    #endregion

    #region Private Function
    /// <summary>
    /// ステートの変更をする
    /// </summary>
    /// <param name="next">変更先のステート</param>
    private void ChengeState(State next)
    {
        var prev = _CurrentState;

        // ステートの変更時に行いたい処理
        switch (next)
        {
            case State.None:
                break;
            case State.Run:
                break;
            case State.Jump:
                break;
        }

        _CurrentState = next;
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
            case State.Run:
                Jump();
                break;
            case State.Jump:
                break;
        }
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
    #endregion

    #region Callback Function
    /// <summary>
    /// ゲームが始まった時に呼ばれる
    /// </summary>
    private void OnGameStart()
    {
        ChengeState(State.Run);
    }
    #endregion
}
