using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //GameController�X�N���v�g���C���X�^���X��
    //�ǁiwall_bottom�j�ɂԂ�������
    private void OnCollisionEnter(Collision collision)
    {
        if (GameController.instance == null)
        {
            GameController.instance = FindObjectOfType<GameController>();
        }

        if (GameController.instance != null)
        {
            GameController.instance.EndGame();
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("�C���X�^���X���ł��Ă��܂���ł����B");
        }
    }


}
