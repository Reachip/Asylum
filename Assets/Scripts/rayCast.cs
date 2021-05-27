using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rayCast : MonoBehaviour
{

    private Text UiText;

    private List<GameObject> keys = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        UiText = GameObject.Find("ActionsText").GetComponent<Text>();

    }



    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider != null)
            {
                Debug.Log(hit.transform.gameObject.ToString());
                if (hit.collider.gameObject.name == "KettleSphereCollider")
                {
                    UiText.text = "Appuyez sur E pour prendre " + hit.transform.parent.gameObject.name;
                    if (Input.GetKeyDown(KeyCode.E)){
                        UiText.text = "Vous avez pris la clé";
                        keys.Add(hit.transform.parent.gameObject);
                        hit.transform.parent.gameObject.SetActive(false);
                        Debug.Log(keys.Count);
                    }
                }else if(hit.collider.gameObject.name == "DoorTriggerBox")
                {
                    UiText.text = "Appuyez sur E pour ouvrir " + hit.transform.parent.gameObject.name;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        
                        foreach (GameObject key in keys)
                        {
                            if(key.name.Substring(5) == hit.transform.parent.gameObject.name.Substring(5))
                            {
                                Debug.Log("Il as la bonne clé");
                                foreach(Animator obj in hit.transform.parent.GetComponentsInChildren<Animator>())
                                {
                                    obj.SetBool("ouvre", true);
                                }
                            }
                        }
                    }
                }
                else
                {
                    UiText.text = "";
                }
            }
        }
        
    }




}
