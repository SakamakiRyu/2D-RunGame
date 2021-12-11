using UnityEngine;

/// <summary>
/// �A�C�e���̒��ۃN���X
/// ���R���C�_�[�ɂ�铖���蔻����g�����߁A���炩��Collider�̎��������鎖�B
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    /// <summary>���Z����X�R�A</summary>
    [SerializeField]
    protected int _AddScore;

    [SerializeField]
    protected SpriteRenderer _Sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            OnHitDestroyPoint();
        }

        if (collision.CompareTag("Player"))
        {
            OnHitPlayer();
        }
    }

    /// <summary>
    /// �v���C���[�ƐڐG�������ɌĂ΂��
    /// </summary>
    protected abstract void OnHitPlayer();

    /// <summary>
    /// �f�X�g���C�|�C���g�ɐڐG�������ɌĂ΂��
    /// </summary>
    protected abstract void OnHitDestroyPoint();
}
