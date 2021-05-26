
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBeamVideoProjClignotement : MonoBehaviour
{
    // Start is called before the first frame update
    Light lightBeam;
    System.Random rnd = new System.Random();

    void Start()
    {
        lightBeam = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        lightBeam.intensity = rnd.Next(1,9);
    }
}
