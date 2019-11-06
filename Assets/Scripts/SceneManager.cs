using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    void Start() 
    {
        PlayerPrefs.SetInt("LivesLeft", 3);
    }
    public void SceneSwitch()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
