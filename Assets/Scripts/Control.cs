using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Control : MonoBehaviour
{
    public string sceneName;
    private string thisScene;

    void OnCollisionEnter(Collision other)
    {
        if (thisScene == "In-Between")
        {
            SceneManager.LoadSceneAsync(sceneName);
            thisScene = sceneName;
        }
        else
        {
            SceneManager.LoadScene(sceneName);
            thisScene = sceneName;
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
