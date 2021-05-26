using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeaCups : MonoBehaviour
{

    private Animator teaPot;
    // Start is called before the first frame update
    void Start()
    {
        teaPot = GameObject.Find("Kettle (2)").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teaPot.SetBool("TriggerBoxTeaCupsCollide", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teaPot.SetBool("TriggerBoxTeaCupsCollide", false);
        }
    }
}
