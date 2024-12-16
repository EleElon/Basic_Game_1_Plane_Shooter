using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject enemy;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isGameOver;

    // Start is called before the first frame update
    void Start() {
        m_spawnTime = 0;
    }

    // Update is called once per frame
    void Update() {

        if (!m_isGameOver) {
            m_spawnTime -= Time.deltaTime;

            if (m_spawnTime < 0) {
                enemySpawn();

                m_spawnTime = spawnTime;
            }
        }
        return;
    }

    public void enemySpawn() {
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
        m_score++;
    }

    public void setGameOver(bool state) {
        m_isGameOver = state;
    }

    public bool isGameOver() {
        return m_isGameOver;
    }
}
