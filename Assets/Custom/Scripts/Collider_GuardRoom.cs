using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_GuardRoom : MonoBehaviour
{
    private Animator chaise;
    private Animator rack;

    // Start is called before the first frame update
    void Start()
    {
        chaise = GameObject.Find("ChairOffice").GetComponent<Animator>();
        rack = GameObject.Find("SheetRack (5)/SheetRackCase_1").GetComponent<Animator>();
        AnimateSheetRack.trigger = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chaise.SetBool("tombe", true);
            rack.SetBool("tombe", true);
            AnimateSheetRack.trigger = true;
        }
            
    }
}
