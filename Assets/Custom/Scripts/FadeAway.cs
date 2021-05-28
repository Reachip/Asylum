using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public int timer = 120;
    public int time = 0;
    public Color color;
    public Animator cube;
    // Start is called before the first frame update
    void Start()
    {        
        cube = GameObject.Find("Cubenoir").GetComponent<Animator>();
        time = 58;
        color = cube.GetComponent<MeshRenderer>().material.color = new Color (0, 0 , 0, 1);
    }

    IEnumerator wait()
    {   
        while(time <= timer)
        {
            yield return new WaitForSeconds((float)0.05);
            color.a -= (float)0.05;
            if(color.a <= 0)
            {
                color.a = 0;
            }
            cube.GetComponent<MeshRenderer>().material.color = color;
            time += 1;
        }
        DestroyImmediate(cube.transform.gameObject);        
    }

}
