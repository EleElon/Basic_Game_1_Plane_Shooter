using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject enemy, background;

    public float spawnTime;

    public float spawnBGTime;

    float m_spawnTime;

    float m_spawnBGTime;

    int m_score;

    bool m_isGameOver;

    UIManager m_ui;

    int HP = 3;

    public Player u;

    // public AudioManager aum;

    private void Awake() {
        // aum = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start() {
        m_spawnTime = 0;
        m_ui = FindAnyObjectByType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);

        string HPString = string.Empty;
        for (int i = 0; i < HP; i++) {
            HPString += "❤";
        }

        m_ui.SetHealthText(HPString);
    }

    // Update is called once per frame
    void Update() {
        if (!m_isGameOver) {
            m_spawnTime -= Time.deltaTime;
            m_spawnBGTime -= Time.deltaTime;

            if (m_spawnTime < 0) {
                enemySpawn();

                m_spawnTime = spawnTime;
            }

            if (m_spawnBGTime < 0) {
                BGSpawn();

                m_spawnBGTime = spawnBGTime;
            }
        }
        else {
            m_spawnTime = 0;
            m_ui.ShowGameOverPannel(true);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (m_ui.IsSettingPanelActive()) {
                m_ui.ShowSettingPanel(false);
                m_ui.ShowGamePausePanel(true);
            }
            else if (!m_ui.IsGamePaused()) {
                m_ui.Pause();
            }
            else {
                m_ui.Resume();
            }
        }

        if (HP == 0) {
            m_isGameOver = true;

            if (u) {
                Destroy(u.gameObject);
            }
            else {
                return;
            }
        }
    }

    public void setting() {
        m_ui.ShowGamePausePanel(false);
        m_ui.ShowSettingPanel(true);
    }

    public void CloseSettingPanel() {
        m_ui.ShowSettingPanel(false);
        m_ui.ShowGamePausePanel(true);
    }

    public void backToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Again() {
        SceneManager.LoadScene("GamePlay");
        m_ui.Resume();
    }

    public void BGSpawn() {
        if (m_ui.IsGamePause() || m_isGameOver) {
            return;
        }

        Vector2 spawnBG = new Vector2(0, 28);
        if (background) {
            Instantiate(background, spawnBG, Quaternion.identity);
        }
    }
    public void enemySpawn() {
        if (m_ui.IsGamePause() || m_isGameOver)
            return;

        float randXPosi = Random.Range(-7f, 7f);
        Vector2 spawnPosi = new Vector2(randXPosi, 5.8f);

        if (enemy) {
            Instantiate(enemy, spawnPosi, Quaternion.identity);
        }
    }
    public void setScore(int value) {
        m_score = value;
    }

    public int getScore() {
        return m_score;
    }

    public void scoreIncrement() {
        if (m_isGameOver || m_ui.IsGamePause())
            return;
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public void HPDecrease() {
        HP--;
        string HPString = string.Empty;
        for (int i = 0; i < HP; i++) {
            HPString += "❤";
        }

        m_ui.SetHealthText(HPString);
    }

    public void setGameOver(bool state) {
        m_isGameOver = state;
    }

    public bool isGameOver() {
        return m_isGameOver;
    }
}
