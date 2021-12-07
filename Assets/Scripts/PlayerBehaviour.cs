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

    [SerializeField]
    private float _LineLength;

    /// <summary>���݂̃X�e�[�g</summary>
    private State _CurrentState = State.None;
    /// <summary>���݂̃X�e�[�g���擾</summary>
    public State GetCurrentState => _CurrentState;

    private void Update()
    {
        ChengeState(State.InGame);
        StateUpdate();
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
                if (_Rigidbody2D)
                    Walk();
                break;
            case State.Death:
                break;
        }
    }

    /// <summary>
    /// �X�e�[�g�̕ύX������
    /// </summary>
    /// <param name="next">�ύX��</param>
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
    /// ����
    /// </summary>
    private void Walk()
    {
        var velo = _Rigidbody2D.velocity;
        velo.x = _WalkSpeed;
        _Rigidbody2D.velocity = velo;
    }

    /// <summary>
    /// �n�ʂƂ̐ڒn����
    /// </summary>
    /// <returns>�ڒn���Ă��邩</returns>
    private bool IsGrounded()
    {
        // �ڒn��������郌�C���[���w��
        var layer = Layer.LAYER_GROUND_INDEX;

        var hitInfo = Physics.Raycast(this.transform.position, Vector2.down, _LineLength, layer);
        if (!hitInfo) return false;
        return true;
    }
}
