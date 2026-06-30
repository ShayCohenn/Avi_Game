using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settingsMenu;

    public void PlayGame()
    {
        // Start a Coroutine so it can run across multiple frames
        StartCoroutine(LoadSceneAsync());
    }

    public void OpenSettings()
    {
        _mainMenu.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        _mainMenu.SetActive(true);
        _settingsMenu.SetActive(false);
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