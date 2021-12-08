using System.Collections;
using UnityEngine;

/// <summary>
/// Unity�̃V�[���J�ڎ��̉��o
/// </summary>
public class FadeSystem : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _FadeImage;

    private void Start()
    {
        if (_FadeImage)
        {
            _FadeImage.fillAmount = 0f;
        }
    }

    /// <summary>
    /// �t�F�[�h�A�E�g������
    /// </summary>
    /// <param name="time">�t�F�[�h�ɂ����鎞��</param>
    public void PlayFadeOut(float time)
    {
        if (!_FadeImage)
        {
            return;
        }
        StartCoroutine(DoFadeOut(time));
    }

    private IEnumerator DoFadeOut(float time)
    {
        while (_FadeImage.fillAmount < 1f)
        {
            _FadeImage.fillAmount += 1 / time * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    /// <summary>
    /// �t�F�[�h�C��������
    /// </summary>
    /// <param name="time">�t�F�[�h�ɂ����鎞��</param>
    public void PlayFadeIn(float time)
    {
        if (!_FadeImage)
        {
            return;
        }
        StartCoroutine(DoFadeIn(time));
    }

    private IEnumerator DoFadeIn(float time)
    {
        while (_FadeImage.fillAmount > 0f)
        {
            _FadeImage.fillAmount -= 1 / time * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
