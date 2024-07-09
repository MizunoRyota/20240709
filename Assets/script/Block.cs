using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void Start()
    {
        blockGenerator = FindObjectOfType<BlockGenerator>();
    }

    //�X�R�A
    public int score = 10;
    private BlockGenerator blockGenerator;
    //�����ƂԂ��������ɌĂ΂��
    private void OnCollisionEnter(Collision collision)
    {
        if (ScoreScript.instance != null)
        {
            ScoreScript.instance.ScoreManager(score);
        }
        else
        {
            Debug.LogError("ScoreScript�̃C���X�^���X������܂���B");
        }
        //�u���b�N���Ԃ��������тɐ��������J�E���g�����炵�Ă���
        blockGenerator.BlockDestoroyed();
        //�Q�[���I�u�W�F�N�g���폜����
        Destroy(gameObject);
    }
}
