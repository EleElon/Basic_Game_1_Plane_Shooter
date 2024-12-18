using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {
    public float moveSpeed;

    public float timeToDestroy;

    float timeToDestroyReset;

    bool isPaused = false;

    Rigidbody2D m_rb;

    GameController m_gc;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
        m_ui = FindAnyObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update() {
        if (m_gc.isGameOver() || m_ui.IsGamePausePanelActive()) {
            m_rb.velocity = Vector2.zero;
            return;
        }

        if (m_ui.IsGamePausePanelActive() || m_gc.isGameOver()) {
            isPaused = true;
        }
        else {
            isPaused = false;
        }

        if (!isPaused) {
            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy <= 0) {
                Destroy(gameObject);
                timeToDestroy = timeToDestroyReset;
            }
        }

        m_rb.velocity = Vector2.down * moveSpeed;
    }
}
