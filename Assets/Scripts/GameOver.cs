using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        StartCoroutine(LoadAsync(1));
        
    }

    public void Quitter()
    {
        Application.Quit();
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = operation.progress;
            progressText.text = operation.progress * 100f + "%";
            yield return null;
        }

    }
}
