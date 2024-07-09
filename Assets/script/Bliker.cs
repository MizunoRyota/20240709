using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bliker : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject titleText;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        this.titleText.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
