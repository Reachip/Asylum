using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private Animator anim;
    AudioSource sound;

    private float soundRange = 6;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {     
        var dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist <= soundRange && sound.isPlaying == false)
        {
            sound.Play();
        }

        enemy.SetDestination(player.position);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           StartCoroutine(CollisionAction());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("colid", false);
        }
    }

    IEnumerator CollisionAction()
    {
        anim.SetBool("colid", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        File.Delete("P:\\save.asylum.txt");
    }
}
