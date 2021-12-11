/// <summary>
/// �A�C�e��(�X�R�A�{�[��)�N���X
/// </summary>
public class ScoreBallBehaviour : ItemBase
{
    /// <summary>�X�R�A�}�l�[�W���[</summary>
    private ScoreManager _ScoreManager;

    private void Start()
    {
        _ScoreManager = FindObjectOfType<ScoreManager>();
    }

    /// <summary>
    /// �X�v���C�g�\���̃��Z�b�g
    /// </summary>
    public void ChengeSpriteState()
    {
        if (_Sprite) _Sprite.enabled = true;
    }

    protected override void OnHitPlayer()
    {
        // �X�v���C�g�̕\��������
        if (_Sprite) _Sprite.enabled = false;
        // �X�R�A�����Z����
        if (_ScoreManager) _ScoreManager.AddScore(_AddScore);
    }

    protected override void OnHitDestroyPoint()
    {
        ItemControl.Instance.OnDestroyedItem(this);
    }
}
