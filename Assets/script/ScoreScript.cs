using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    private TextMeshProUGUI scoreText; // ���ۂ�TextMeshProUGUI�R���|�[�l���g��ێ�
    private int totalScore = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // �V�[�������[�h���ꂽ���ɌĂяo�����C�x���g��o�^
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Initialize();
    }

    public void ScoreManager(int score)
    {
        totalScore += score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore.ToString();
        }
        else
        {
            Debug.LogError("�X�R�A�e�L�X�g��null�ł�");
        }
    }

    public int GetCurrentScore()
    {
        return totalScore;
    }

    public void Initialize()
    {
        // �^�O�ŃX�R�A�e�L�X�g�I�u�W�F�N�g���������Ď擾
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }
        else
        {
            Debug.LogError("�X�R�A�e�L�X�g�I�u�W�F�N�g��������܂���");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �V�[�������[�h���ꂽ��ɍď�����
        StartCoroutine(InitializeAfterFrame());
    }

    private IEnumerator InitializeAfterFrame()
    {
        // �t���[�����I���̂�҂�
        yield return null;
        Initialize();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // �C�x���g�o�^������
    }
}
