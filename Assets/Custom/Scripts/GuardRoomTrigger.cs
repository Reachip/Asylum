using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;

public class GuardRoomTrigger : MonoBehaviour
{
    private Animator Anim;

    void Start()
    {
        Anim = GameObject.Find("ChairOffice").GetComponent<Animator>();
        Anim.SetBool("tombe", false);
    }

    void OnTriggerEnter()
    {
        Anim.SetBool("tombe", true);
    }

}
