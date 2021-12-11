using UnityEngine;

/// <summary>
/// Player�N���X
/// </summary>
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
    /// <summary>���݂̃X�e�[�g</summary>
    private State _CurrentState = State.None;
    #endregion

    #region Property
    /// <summary>���݂̃X�e�[�g���擾</summary>
    public State GetCurrentState => _CurrentState;
    /// <summary>���݂̑��x�x�N�g�����擾</summary>
    public Vector3 GetVelocity => _Rigidbody2D.velocity;
    #endregion

    #region Unity Function
    private void Awake()
    {
        var gm = GameObject.FindObjectOfType<GameManager>();
        if (gm)
        {
            GameManager.Instance.GameStart += OnGameStart;
            GameManager.Instance.GameEnd += OnGameEnd;
        }
        else
        {
            ChengeState(State.InGame);
        }
    }

    private void Update()
    {
        StateUpdate();
    }
    #endregion

    #region Public Function
    #endregion

    #region Private Function
    /// <summary>
    /// �X�e�[�g�̕ύX������
    /// </summary>
    /// <param name="next">�ύX��̃X�e�[�g</param>
    private void ChengeState(State next)
    {
        var prev = _CurrentState;

        // �X�e�[�g�̕ύX���ɍs����������
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
    /// �X�e�[�g���̃A�b�v�f�[�g
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
    /// ����
    /// </summary>
    private void Move()
    {
        if (!_Rigidbody2D) return;

        var velo = _Rigidbody2D.velocity;
        velo.x = _MoveSpeed;
        _Rigidbody2D.velocity = velo;
    }

    /// <summary>
    /// �W�����v����
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
    /// �n�ʂƂ̐ڒn����
    /// </summary>
    /// <returns>�ڒn���Ă��邩</returns>
    private bool IsGrounded()
    {
        // �ڒn��������郌�C���[���w��
        var layer = LayerMask.GetMask("Ground");

        var hitInfo = Physics2D.Raycast(this.transform.position, Vector2.down, _LineLength, layer);
        if (!hitInfo) return false;
        return true;
    }
    #endregion

    #region Callback Function
    /// <summary>
    /// �Q�[�����n�܂������ɌĂ΂��
    /// </summary>
    private void OnGameStart()
    {
        ChengeState(State.InGame);
    }

    /// <summary>
    /// �Q�[�����I������(Player������)���ɌĂ΂��
    /// </summary>
    private void OnGameEnd()
    {
        ChengeState(State.Death);
    }
    #endregion
}
