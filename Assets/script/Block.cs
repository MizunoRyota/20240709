using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void Start()
    {
        blockGenerator = FindObjectOfType<BlockGenerator>();
    }

    //スコア
    public int score = 10;
    private BlockGenerator blockGenerator;
    //何かとぶつかった時に呼ばれる
    private void OnCollisionEnter(Collision collision)
    {
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("ScoreScriptのインスタンスがありません。");
        }
        //ブロックがぶつかったたびに生成したカウントを減らしていく
        blockGenerator.BlockDestoroyed();
        //ゲームオブジェクトを削除する
        Destroy(gameObject);
    }
}
