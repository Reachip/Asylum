using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public float seconds = 1;
    public float timer;
    Vector3 startpos;
    Vector3 target;
    Vector3 diff;
    public float percent;

    private void Start()
    {
        startpos = transform.position;
        target = transform.position;
        target += new Vector3(0, 2, 0);

        diff = target - startpos;

    }

    void Update()
    {
        if(timer <= seconds)
        {
            timer += Time.deltaTime;
            percent = timer / seconds;
            transform.position = startpos + diff * percent;
        }
    }
}
