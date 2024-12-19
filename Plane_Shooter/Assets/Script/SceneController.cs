using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public string previousScene;

    public void LoadNewScene(string sceneName) {
        previousScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);

        HideCurrentScene();
    }

    public void ReturnToPreScene() {
        HideCurrentScene();

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(previousScene));

        ShowPreviousScene();
    }

    void HideCurrentScene() {
        // Scene currentScene = SceneManager.GetActiveScene();
        Scene previous = SceneManager.GetSceneByName(previousScene);

        foreach (GameObject obj in previous.GetRootGameObjects()) {
            obj.SetActive(false);
        }
    }

    void ShowPreviousScene() {
        Scene previous = SceneManager.GetSceneByName(previousScene);
        foreach (GameObject obj in previous.GetRootGameObjects()) {
            obj.SetActive(true);
        }
    }

    // public static string previousScene;    

    // public void GoToSetting() {
    //     previousScene = SceneManager.GetActiveScene().name;
    //     SceneManager.LoadScene("Setting");
    // }

    // public void BackToPreviousScene() {
    //     if (!string.IsNullOrEmpty(previousScene)) {
    //         SceneManager.LoadScene(previousScene);

    //         if (AudioManager.instance != null) {
    //             AudioManager.instance.PlayRandomMusic();
    //         }
    //     }
    // }
}
