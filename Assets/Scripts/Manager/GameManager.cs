using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �Q�[���̐i�s���Ǘ�����N���X
/// ���̃Q�[���ł́A�^�C�}�[���J�E���g�_�E���ł����g��Ȃ��ׁAGameManager���Ǘ����Ă���B
/// </summary>
public class GameManager : Singleton<GameManager>
{
    #region Define
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
    #endregion

    #region Serialize Field
    [SerializeField]
    private Text _TimerText;

    [SerializeField]
    private float _TimeToCountDown;

    /// <summary>�f�o�b�O�p�ŃV���A���C�Y���Ă���</summary>
    [SerializeField]
    private GameState _CurrentGameState = GameState.None;
    #endregion

    #region Private Field
    /// <summary>�^�C�}�[</summary>
    private float _Timer;
    /// <summary>�Q�[�������̃t���O</summary>
    private bool _IsInGame = false;
    #endregion

    #region Property
    /// <summary>���݂̃Q�[���X�e�[�g���擾</summary>
    public GameState GetCurrentGameState => _CurrentGameState;
    #endregion

    #region Event
    /// <summary>�Q�[�����X�^�[�g�������ɌĂ΂��</summary>
    public Action GameStart;
    /// <summary>�Q�[�����I���������ɌĂ΂��</summary>
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
        // �Q�[���X�e�[�g�����ݒ�(None)�������ꍇ�́ATitle�ɂ���B
        if (_CurrentGameState == GameState.None) ChengeGameState(GameState.Title);
    }

    private void Update()
    {
        UpdateState();
    }

    /// <summary>
    /// �X�e�[�g���ɖ��t���[���Ă΂�鏈��
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
    /// �Q�[���X�e�[�g�̕ύX������
    /// </summary>
    /// <param name="next">�ύX��</param>
    public void ChengeGameState(GameState next)
    {
        var prev = _CurrentGameState;

        // �X�e�[�g�̕ύX���ɂ��鏈��
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

        // �V�[���̃��[�h
        SceneManager.LoadSceneAsync((int)next);

        // �X�e�[�g�̍X�V
        _CurrentGameState = next;
    }

    /// <summary>
    /// �J�E���g���e�L�X�g�ɔ��f����
    /// </summary>
    private void ShowCountDown()
    {
        var iTime = (int)_Timer;

        // �^�C�}�[��0�̎���Text��Start�ƕ\�����āA����ȊO�͐���(�J�E���g)��\������
        _TimerText.text = iTime == 0 ? "Start !!" : iTime.ToString();
    }

    /// <summary>
    /// �e�L�X�g�̕\���ݒ��ύX����
    /// </summary>
    /// <param name="next">�\�����邩</param>
    private void ChengeTextSetting(bool nextSetting)
    {
        if (nextSetting == _TimerText.isActiveAndEnabled) return;

        if (_TimerText) _TimerText.enabled = nextSetting;
    }

    /// <summary>
    /// �Q�[�����I��(Player��Death���)�ɂȂ������ɌĂ΂��
    /// </summary>
    private void OnGameEnd()
    {
        ChengeGameState(GameState.Result);
    }

    /// <summary>
    /// ���Z�b�g������
    /// </summary>
    private void Reset()
    {
        _Timer = _TimeToCountDown + 1f;
        _IsInGame = false;
    }
}
