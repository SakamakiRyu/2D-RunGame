using System.Collections;
using UnityEngine;

/// <summary>
/// Unityのシーン遷移時の演出
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
    /// フェードアウトをする
    /// </summary>
    /// <param name="time">フェードにかける時間</param>
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
    /// フェードインをする
    /// </summary>
    /// <param name="time">フェードにかける時間</param>
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
