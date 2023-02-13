using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public string sceneName = "TestArea";

    void OnCollisionEnter(Collision other)
    {
        SceneManager.LoadScene(sceneName);
    }
}
