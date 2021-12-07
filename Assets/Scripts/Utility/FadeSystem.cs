using System.Collections;
using UnityEngine;

public class FadeSystem : Singleton<FadeSystem>
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
            Log.Warning("Image ��ݒ肵�Ă�������");
            return;
        }
        StartCoroutine(DoFadeOut(time));
    }

    private IEnumerator DoFadeOut(float time)
    {
        Log.Info("Play FadeOut");
        while (_FadeImage.fillAmount < 1f)
        {
            _FadeImage.fillAmount += 1 / time * Time.deltaTime;
            yield return null;
        }
        Log.Info("End FadeOut");
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
            Log.Warning("Image ��ݒ肵�Ă�������");
            return;
        }
        StartCoroutine(DoFadeIn(time));
    }

    private IEnumerator DoFadeIn(float time)
    {
        Log.Info("Play FadeIn");
        while (_FadeImage.fillAmount > 0f)
        {
            _FadeImage.fillAmount -= 1 / time * Time.deltaTime;
            yield return null;
        }
        Log.Info("End FadeIn");
        yield return null;
    }
}
