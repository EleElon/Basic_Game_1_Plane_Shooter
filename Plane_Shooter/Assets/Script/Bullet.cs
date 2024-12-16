using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D m_rb;

    GameController m_gc;

    public float speed;

    public float timeToDestroy;

    // Start is called before the first frame update
    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update() {
        m_rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Enemy")) {

            m_gc.scoreIncrement();

            Destroy(gameObject);

            Destroy(col.gameObject);
        }
    }
}
