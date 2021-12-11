using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ゲームの進行を管理するクラス
/// このゲームでは、タイマーをカウントダウンでしか使わない為、GameManagerが管理している。
/// </summary>
public class GameManager : Singleton<GameManager>
{
    #region Define
    /// <summary>ゲームのステート</summary>
    public enum GameState
    {
        None = -1,
        /// <summary>タイトル</summary>
        Title,
        /// <summary>ゲーム中</summary>
        InGame,
        /// <summary>ゲームリザルト</summary>
        Result
    }
    #endregion

    #region Serialize Field
    [SerializeField]
    private Text _TimerText;

    [SerializeField]
    private float _TimeToCountDown;

    /// <summary>デバッグ用でシリアライズしている</summary>
    [SerializeField]
    private GameState _CurrentGameState = GameState.None;
    #endregion

    #region Private Field
    /// <summary>タイマー</summary>
    private float _Timer;
    /// <summary>ゲーム中かのフラグ</summary>
    private bool _IsInGame = false;
    #endregion

    #region Property
    /// <summary>現在のゲームステートを取得</summary>
    public GameState GetCurrentGameState => _CurrentGameState;
    #endregion

    #region Event
    /// <summary>ゲームがスタートした時に呼ばれる</summary>
    public Action GameStart;
    /// <summary>ゲームが終了した時に呼ばれる</summary>
    public Action GameEnd;
    #endregion

    public override void Awake()
    {
        base.Awake();
        GameEnd += OnGameEnd;
    }

    private void Start()
    {
        ShowCountDown();
        // ゲームステートが未設定(None)だった場合は、Titleにする。
        if (_CurrentGameState == GameState.None) ChengeGameState(GameState.Title);
    }

    private void Update()
    {
        UpdateState();
    }

    /// <summary>
    /// ステート毎に毎フレーム呼ばれる処理
    /// </summary>
    private void UpdateState()
    {
        switch (_CurrentGameState)
        {
            case GameState.None:
                {
                    break;
                }
            case GameState.Title:
                {
                    if (Input.anyKeyDown)
                        ChengeGameState(GameState.InGame);
                    break;
                }
            case GameState.InGame:
                {
                    if (_Timer > 0)
                    {
                        ShowCountDown();
                        _Timer -= Time.deltaTime;
                    }
                    if (_Timer <= 0 && !_IsInGame)
                    {
                        ChengeTextSetting(false);
                        _IsInGame = true;
                        GameStart?.Invoke();
                    }
                    break;
                }
            case GameState.Result:
                {
                    if (Input.anyKeyDown)
                        ChengeGameState(GameState.Title);
                    break;
                }
        }
    }

    /// <summary>
    /// ゲームステートの変更をする
    /// </summary>
    /// <param name="next">変更先</param>
    public void ChengeGameState(GameState next)
    {
        var prev = _CurrentGameState;

        // ステートの変更時にする処理
        switch (next)
        {
            case GameState.None:
                {
                    break;
                }
            case GameState.Title:
                {
                    ChengeTextSetting(false);
                    Reset();
                    break;
                }
            case GameState.InGame:
                {
                    ChengeTextSetting(true);
                    break;
                }
            case GameState.Result:
                {
                    ChengeTextSetting(false);
                    break;
                }
        }

        // シーンのロード
        SceneManager.LoadSceneAsync((int)next);

        // ステートの更新
        _CurrentGameState = next;
    }

    /// <summary>
    /// カウントをテキストに反映する
    /// </summary>
    private void ShowCountDown()
    {
        var iTime = (int)_Timer;

        // タイマーが0の時はTextにStartと表示して、それ以外は数字(カウント)を表示する
        _TimerText.text = iTime == 0 ? "Start !!" : iTime.ToString();
    }

    /// <summary>
    /// テキストの表示設定を変更する
    /// </summary>
    /// <param name="next">表示するか</param>
    private void ChengeTextSetting(bool nextSetting)
    {
        if (nextSetting == _TimerText.isActiveAndEnabled) return;

        if (_TimerText) _TimerText.enabled = nextSetting;
    }

    /// <summary>
    /// ゲームが終了(PlayerがDeath状態)になった時に呼ばれる
    /// </summary>
    private void OnGameEnd()
    {
        ChengeGameState(GameState.Result);
    }

    /// <summary>
    /// リセットをする
    /// </summary>
    private void Reset()
    {
        _Timer = _TimeToCountDown + 1f;
        _IsInGame = false;
    }
}
