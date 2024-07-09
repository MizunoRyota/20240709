using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class BlockGenerator : MonoBehaviour
{
    //GameObject
    public GameObject blockPrefab;      //ブロックのプレファブ
    //ブロックの座標・大きさ
    float span = 0.3f;      //ブロックの間隔
    int row = 4;            //ブロックの列
    int col = 7;            //ブロックの行
    int blockScaleX = 2;    //ブロックの幅
    int blockScaleY = 1;    //ブロックの高さ
    int totalBlocks;
    // Start is called before the first frame update
    void Start()
    {
        //ブロックの座標
        int px = -7, py = 5;         //ブロックのX座標とY座標
        int scoreDefalt = 0;
        totalBlocks = row* col;
        //ブロックの表示
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                //ゲームオブジェクトとして生成
                GameObject go = Instantiate(blockPrefab);
                go.transform.position = new Vector3(px + (j * (span + blockScaleX)), py + (i * (span + blockScaleY)), 0);
            }
        }

        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(scoreDefalt);
        }
        else
        {
            Debug.LogError("ScoreScriptのインスタンスがありません。");
        }

    }

    public void BlockDestoroyed()
    {
        totalBlocks--;
        SceneData.totalBlocks = totalBlocks;
        if (totalBlocks <= 0)
        {
            SceneManager.LoadScene("Result");
        }
    }

}
