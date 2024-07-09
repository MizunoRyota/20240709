using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;

    private TextMeshProUGUI scoreText; // 実際のTextMeshProUGUIコンポーネントを保持
    private int totalScore = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // シーンがロードされた時に呼び出されるイベントを登録
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
            Debug.LogError("スコアテキストがnullです");
        }
    }

    public int GetCurrentScore()
    {
        return totalScore;
    }

    public void Initialize()
    {
        // タグでスコアテキストオブジェクトを検索して取得
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }
        else
        {
            Debug.LogError("スコアテキストオブジェクトが見つかりません");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンがロードされた後に再初期化
        StartCoroutine(InitializeAfterFrame());
    }

    private IEnumerator InitializeAfterFrame()
    {
        // フレームが終わるのを待つ
        yield return null;
        Initialize();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // イベント登録を解除
    }
}
