using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningRoomTrigger : MonoBehaviour
{
    private Animator Table;
    private Animator Chaise1;
    private Animator Chaise2;
    private Animator Chaise3;
    void Start()
    {
        Table = GameObject.Find("TableWhiteKitchen").GetComponent<Animator>();
        Chaise1 = GameObject.Find("ChairWhite (35)").GetComponent<Animator>();
        Chaise2 = GameObject.Find("ChairWhite (32)").GetComponent<Animator>();
        Chaise3 = GameObject.Find("ChairWhite (34)").GetComponent<Animator>();
        Table.SetBool("move", false);
        Chaise1.SetBool("tombe", false);
        Chaise2.SetBool("move", false);
        Chaise3.SetBool("move", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Table.SetBool("move", true);
            Chaise1.SetBool("tombe", true);
            Chaise2.SetBool("move", true);
            Chaise3.SetBool("move", true);
        }
        
    }
}
