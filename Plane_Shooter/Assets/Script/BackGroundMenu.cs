using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMenu : MonoBehaviour {
    public float moveSpeed;

    public float timeToDestroy;

    float timeToDestroyReset;

    Rigidbody2D m_rb;

    GameController m_gc;

    UIManager m_ui;

    MenuController m_menu;

    // Start is called before the first frame update
    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
        m_ui = FindAnyObjectByType<UIManager>();
        m_menu = FindAnyObjectByType<MenuController>();
    }

    // Update is called once per frame
    void Update() {

        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0) {
            Destroy(gameObject);
            timeToDestroy = timeToDestroyReset;
        }

        m_rb.velocity = Vector2.down * moveSpeed;
    }
}
