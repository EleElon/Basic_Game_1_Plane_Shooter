using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    UIManager m_ui;

    private void Start() {
        m_ui = FindAnyObjectByType<UIManager>();
    }

    public void newGame() {
        SceneManager.LoadScene("GamePlay");
        m_ui.StartGame();
    }

    public void setting() {
        SceneManager.LoadScene("Setting");
    }

    public void exit() {
        Application.Quit();
    }
}
