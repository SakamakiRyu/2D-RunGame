using UnityEngine;

/// <summary>
/// �A�C�e���̒��ۃN���X
/// ���R���C�_�[�ɂ�铖���蔻����g�����߁A���炩��Collider�̎��������鎖�B
/// �@�����āA�v���p�e�B��IsTrigger�Ƀ`�F�b�N�����鎖
/// </summary>
public abstract class ItemBase : MonoBehaviour
{
    [SerializeField]
    protected int _AddScore;

    [SerializeField]
    protected ScoreManager _ScoreManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnHit();
        }
    }

    /// <summary>
    /// �v���C���[�ƐڐG�������ɌĂ΂��
    /// </summary>
    protected abstract void OnHit();

    protected abstract void OnDestroy();
}
