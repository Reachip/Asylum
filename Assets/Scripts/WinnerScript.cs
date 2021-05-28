using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bite");
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
