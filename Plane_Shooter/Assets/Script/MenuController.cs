using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    UIManager m_ui;

    public GuidePanelManager m_guide;

    public Button playButton;

    public Button guideButton;

    public Button exitButton;

    private void Start() {
        m_ui = FindAnyObjectByType<UIManager>();
        m_guide = FindAnyObjectByType<GuidePanelManager>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            m_guide.HideGuidePanel(true);
            m_guide.ShowGuidePanel(false);

            SetUIEnable();
        }
    }

    public void newGame() {
        SceneManager.LoadScene("GamePlay");
        m_ui.StartGame();
    }

    public void Guide() {
        m_guide.ShowGuidePanel(true);
        m_guide.HideGuidePanel(true);

        SetUIDisable();
    }

    public void exit() {
        Application.Quit();
    }

    public void BackToMenu() {
        m_guide.HideGuidePanel(true);
        m_guide.ShowGuidePanel(false);

        SetUIEnable();
    }

    public void SetUIDisable() {
        if (playButton) {
            playButton.gameObject.SetActive(false);
        }
        if (guideButton) {
            guideButton.gameObject.SetActive(false);
        }
        if (exitButton) {
            exitButton.gameObject.SetActive(false);
        }
    }

    public void SetUIEnable() {
        if (playButton) {
            playButton.gameObject.SetActive(true);
        }
        if (guideButton) {
            guideButton.gameObject.SetActive(true);
        }
        if (exitButton) {
            exitButton.gameObject.SetActive(true);
        }
    }
}
