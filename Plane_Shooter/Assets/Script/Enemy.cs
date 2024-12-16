using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // Start is called before the first frame update
    public float moveSpeed;
    public Rigidbody2D m_rb;

    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        m_rb.velocity = Vector2.down * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("DeathZone")) {
            Debug.Log("Not False");
        }
    }
}
