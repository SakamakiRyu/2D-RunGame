using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    /// <summary>�Q�[���̃X�e�[�g</summary>
    public enum GameState
    {
        None = -1,
        /// <summary>�^�C�g��</summary>
        Title,
        /// <summary>�Q�[����</summary>
        InGame,
        /// <summary>�Q�[�����U���g</summary>
        Result
    }

    [SerializeField]
    private float _TimeToCountDown;

    /// <summary>���݂̃Q�[���X�e�[�g</summary>
    [SerializeField]
    private GameState _CurrentGameState = GameState.None;

    /// <summary>�^�C�}�[</summary>
    private float _Timer;

    /// <summary>���݂̃Q�[���X�e�[�g���擾</summary>
    public GameState GetCurrentGameState => _CurrentGameState;

    /// <summary>�Q�[�����X�^�[�g�������ɌĂ΂��</summary>
    public Action GameStart;
    /// <summary>�Q�[�����I���������ɌĂ΂��</summary>
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
    /// �X�e�[�g���ɖ��t���[���Ă΂�鏈��
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
    /// �Q�[���X�e�[�g�̕ύX
    /// </summary>
    /// <param name="next">�ύX��</param>
    public void ChengeGameState(GameState next)
    {
        var prev = _CurrentGameState;

        // �X�e�[�g�̕ύX���ɂ��鏈��
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

        // �V�[���̃��[�h
        SceneManager.LoadSceneAsync((int)next);
        // �X�e�[�g�̍X�V
        _CurrentGameState = next;
    }

    private void OnGameEnd()
    {
        ChengeGameState(GameState.Result);
    }
}
