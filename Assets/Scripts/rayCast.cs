using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rayCast : MonoBehaviour
{

    private Text UiText;
    private Text ItemTakenText;

    private List<GameObject> keys = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        UiText = GameObject.Find("ActionsText").GetComponent<Text>();
        ItemTakenText = GameObject.Find("LastItemText").GetComponent<Text>();
        ItemTakenText.text = "";
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
                
                if (hit.collider.gameObject.name == "KettleSphereCollider" && hit.distance < 1.8)
                {
                    UiText.text = "Appuyez sur E pour prendre " + hit.transform.parent.gameObject.name.Substring(0,4) + " " + hit.transform.parent.gameObject.name.Substring(5);
                    if (Input.GetKeyDown(KeyCode.E)){
                        ItemTakenText.text = "Vous avez pris la clé " + hit.transform.parent.gameObject.name.Substring(5);
                        keys.Add(hit.transform.parent.gameObject);
                        hit.transform.parent.gameObject.SetActive(false);
                        
                    }
                }else if(hit.collider.gameObject.name == "DoorTriggerBox" && hit.distance < 1.8)
                {
                    
                    UiText.text = "Appuyez sur E pour ouvrir la porte " + hit.transform.parent.gameObject.name.Substring(5);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        
                        foreach (GameObject key in keys)
                        {
                            if(key.name.Substring(5) == hit.transform.parent.gameObject.name.Substring(5))
                            {
                                
                                foreach(Animator obj in hit.transform.parent.GetComponentsInChildren<Animator>())
                                {
                                    obj.SetBool("ouvre", true);
                                }

                                Destroy(hit.transform.gameObject);
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
