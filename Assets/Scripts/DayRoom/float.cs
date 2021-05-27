using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teaPouring : MonoBehaviour
{
    private Animator pot;

    public float degreesPerSecond = 1.0f;
    public float amplitude = 0.01f;
    public float frequency = 0.1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    bool goToCup = false;
    // Start is called before the first frame update
    void Start()
    {
        pot = GameObject.Find("Kettle (2)").GetComponent<Animator>();
        transform.position += new Vector3(0, (float)0.1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        posOffset = transform.position;
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
