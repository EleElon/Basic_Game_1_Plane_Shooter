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

    public Text nameGameTittle1;

    public Text nameGameTittle2;

    public static bool shouldResetAnim = false;

    public GameObject BG;

    public float spawnBGTime;

    float m_spawnBGTime;

    private void Start() {
        m_ui = FindAnyObjectByType<UIManager>();
        m_guide = FindAnyObjectByType<GuidePanelManager>();
    }

    private void Update() {

        m_spawnBGTime -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Escape)) {
            m_guide.HideGuidePanel(true);
            m_guide.ShowGuidePanel(false);

            SetUIEnable();
        }

        if (m_spawnBGTime < 0) {
            BGMenuSpawn();

            m_spawnBGTime = spawnBGTime;
        }
    }

    public void BGMenuSpawn() {

        Vector2 spawnBG = new Vector2(0, 28);
        if (BG) {
            Instantiate(BG, spawnBG, Quaternion.identity);
        }
    }

    public void newGame() {
        SceneManager.LoadScene("GamePlay");

        m_ui.StartGame();

        SetUIDisable();
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
        if (nameGameTittle1) {
            nameGameTittle1.gameObject.SetActive(false);
        }
        if (nameGameTittle2) {
            nameGameTittle2.gameObject.SetActive(false);
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
        if (nameGameTittle1) {
            nameGameTittle1.gameObject.SetActive(true);
        }
        if (nameGameTittle2) {
            nameGameTittle2.gameObject.SetActive(true);
        }
    }
}
