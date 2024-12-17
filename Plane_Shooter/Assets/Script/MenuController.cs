using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void newGame() {
        SceneManager.LoadScene("GamePlay");
    }

    public void setting() {
        SceneManager.LoadScene("Setting");
    }

    public void exit() {
        Application.Quit();
    }
}
