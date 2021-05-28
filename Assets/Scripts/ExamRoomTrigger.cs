using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamRoomTrigger : MonoBehaviour
{

    private Animator Chaise;
    void Start()
    {
        Chaise = GameObject.Find("ChairLeather (1)").GetComponent<Animator>();
        Chaise.SetBool("tombe", false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Chaise.SetBool("tombe", true);
        }

    }
}
