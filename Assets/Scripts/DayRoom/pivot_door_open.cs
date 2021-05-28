using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivot_door_open : MonoBehaviour
{

    public GameObject Pivot, Porte;

    public bool ouvre = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ouvre)
        {
            Porte.transform.RotateAround(Pivot.transform.position, Vector3.up, 90);
        }
    }
}
