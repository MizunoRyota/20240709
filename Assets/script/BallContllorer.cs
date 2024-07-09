using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;

    //速さの最小値を指定する変数を追加
    public float minSpeed = 5f;
    //速さの最大値を指定
    public float maxSpeed = 10f;

    Rigidbody myrigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //Rigdbodにアクセスして変数に保持しておく
        myrigidbody = GetComponent<Rigidbody>();
        //右斜め45度に進む
        myrigidbody.velocity = new Vector3(speed, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //現在の速さを取得
        Vector3 velocity = myrigidbody.velocity;
        //速さの計算
        float clampedSpeed = Mathf.Clamp(velocity.magnitude, minSpeed, maxSpeed);
        //速度を変更
        myrigidbody.velocity = velocity.normalized * clampedSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //もしも、プレイヤーに当たったときに、跳ね返る方向を変える
        if (collision.gameObject.CompareTag("player"))
        {
            //プレイヤーの位置を取得
            Vector3 playerPos = collision.transform.position;

            //ボールの位置を取得
            Vector3 ballPos = collision.transform.position;

            //プレイヤーから見たボールの方向を計算
            Vector3 directio = (ballPos - playerPos).normalized;
            //現在の速さを取得
            float speed = myrigidbody.velocity.magnitude;

            //速度の変更
            myrigidbody.velocity += directio * speed;

        }
    }
}
