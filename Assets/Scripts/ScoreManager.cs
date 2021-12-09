using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコアの管理クラス
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text _ScoreText;

    /// <summary>ゲームスコア</summary>
    private int _Score = 0;

    private void Start()
    {
        Reset();
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="score">加算スコア</param>
    public void AddScore(int score)
    {
        // ゲーム中じゃ無ければスコアを加算しない
        if (GameManager.Instance.GetCurrentGameState != GameManager.GameState.InGame) return;

        var after = _Score + score;
        _Score = after;

        ScoreTextUpdate();
    }

    /// <summary>
    /// スコアテキストの更新
    /// </summary>
    private void ScoreTextUpdate()
    {
        if (!_ScoreText) return;
        _ScoreText.text = $"Score : {_Score}";
    }

    /// <summary>
    /// スコアとスコアテキストのリセットをする
    /// </summary>
    private void Reset()
    {
        _Score = 0;

        if (!_ScoreText) return;
        _ScoreText.text = $"Score : 0";
    }
}