using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        // Start a Coroutine so it can run across multiple frames
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // This starts loading the scene in the background
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("main");

        // Wait until the scene fully finishes loading
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void QuitGame()
    {
        Debug.Log("quit pressed");
        Application.Quit();
    }

}