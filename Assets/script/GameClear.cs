using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        //Transformコンポーネントを保持しておく
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //子ども（生成したもの）がなくなったら
        if (myTransform.childCount == 0)
        {
            Time.timeScale = 0f;
        }
    }
}
