using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    Text startText;
    // Start is called before the first frame update
    void Start()
    {
        startText = GameObject.Find("StartText").GetComponent<Text>();
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
    }


    IEnumerator waiter()
    {
        startText.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(11);
        startText.transform.gameObject.SetActive(false);
    }


}
