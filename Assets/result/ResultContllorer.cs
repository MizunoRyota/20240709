using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResultContllorer : MonoBehaviour
{

    public GameObject scoreText;
    public GameObject resultText;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText.GetComponent<TextMeshProUGUI>().text = "SCORE:" + SceneData.score;
        if (SceneData.totalBlocks == 0)
        {
            this.resultText.GetComponent<TextMeshProUGUI>().text = "GAME CLEAR";
        }
        else
        {
            this.resultText.GetComponent<TextMeshProUGUI>().text = "GAME OVER";
        }
    }

    public void OnRetruenBottomPressed()
    {
        GameController.instance.ReturnStart();
    }
}
