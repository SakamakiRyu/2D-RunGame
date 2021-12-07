using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
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

    [SerializeField]
    private float _TimeToCountDown;

    /// <summary>現在のゲームステート</summary>
    [SerializeField]
    private GameState _CurrentGameState = GameState.None;

    /// <summary>タイマー</summary>
    private float _Timer;

    /// <summary>現在のゲームステートを取得</summary>
    public GameState GetCurrentGameState => _CurrentGameState;

    /// <summary>ゲームがスタートした時に呼ばれる</summary>
    public Action GameStart;
    /// <summary>ゲームが終了した時に呼ばれる</summary>
    public Action GameEnd;

    public override void Awake()
    {
        base.Awake();
        GameEnd += OnGameEnd;
    }

    private void Start()
    {
        ChengeGameState(GameState.Title);
    }

    private void Update()
    {
        StateUpdate();
    }

    /// <summary>
    /// ステート毎に毎フレーム呼ばれる処理
    /// </summary>
    private void StateUpdate()
    {
        switch (_CurrentGameState)
        {
            case GameState.None:
                break;

            case GameState.Title:
                if (Input.anyKeyDown)
                    ChengeGameState(GameState.InGame);
                break;

            case GameState.InGame:
                break;

            case GameState.Result:
                if (Input.anyKeyDown)
                    ChengeGameState(GameState.Title);
                break;
        }
    }

    /// <summary>
    /// ゲームステートの変更
    /// </summary>
    /// <param name="next">変更先</param>
    public void ChengeGameState(GameState next)
    {
        var prev = _CurrentGameState;

        // ステートの変更時にする処理
        switch (next)
        {
            case GameState.None:
                break;

            case GameState.Title:
                _Timer = _TimeToCountDown;
                break;

            case GameState.InGame:
                break;

            case GameState.Result:
                break;
        }

        // シーンのロード
        SceneManager.LoadSceneAsync((int)next);
        // ステートの更新
        _CurrentGameState = next;
    }

    private void OnGameEnd()
    {
        ChengeGameState(GameState.Result);
    }
}
