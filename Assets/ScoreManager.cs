using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�R�A�̊Ǘ��N���X
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _ScoreText;

    /// <summary>�Q�[���X�R�A</summary>
    private int _Score = 0;

    private void Start()
    {
        Reset();
    }

    /// <summary>
    /// �X�R�A�����Z����
    /// </summary>
    /// <param name="score">���Z�X�R�A</param>
    public void AddScore(int score)
    {
        var after = _Score + score;
        _Score = after;

        ScoreTextUpdate();
    }

    /// <summary>
    /// �X�R�A�e�L�X�g�̍X�V
    /// </summary>
    private void ScoreTextUpdate()
    {
        if (!_ScoreText) return;
        _ScoreText.text = $"Score : {_Score}";
    }

    /// <summary>
    /// �X�R�A�ƃX�R�A�e�L�X�g�̃��Z�b�g������
    /// </summary>
    private void Reset()
    {
        _Score = 0;

        if (!_ScoreText) return;
        _ScoreText.text = $"Score : 0";
    }
}