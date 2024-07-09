using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneData.score = 0;
        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update

    //ÉQÅ[ÉÄèIóπ
    public void EndGame()
    {
        SceneData.score = ScoreScript.instance.GetCurrentScore();
        SceneManager.LoadScene("Result");
    }

    public void ReturnStart()
    {
        SceneManager.LoadScene("Start");
    }

}
