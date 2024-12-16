using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed;

    public GameController m_gc;

    public Rigidbody2D m_rb;

    UIManager m_ui;

    public AudioManager aum;

    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
        m_ui = FindAnyObjectByType<UIManager>();
        aum = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update() {
        if (m_gc.isGameOver() || m_ui.IsGamePause()) {
            m_rb.velocity = Vector2.zero;
            return;
        }
        m_rb.velocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("DeathZone")) {
            // m_gc.setGameOver(true);
            m_gc.HPDecrease();

            if (aum && aum.deathSound) {
                aum.playSFX(aum.deathSound);
            }

            Destroy(gameObject);
        }
    }
}
