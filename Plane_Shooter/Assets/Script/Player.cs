using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 moveSpeed = Vector3.zero;

    public float maxSpeed;

    public float giaToc;

    public float giaTocGiam;

    public GameObject bullet;

    public GameController m_gc;

    public Transform shootingPoint;

    public AudioSource aus;

    public AudioClip shootingSound;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start() {
        m_gc = FindAnyObjectByType<GameController>();
        m_ui = FindAnyObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update() {
        if (m_ui.IsGamePause() || m_gc.isGameOver())
            return;

        float x_Posi = Input.GetAxisRaw("Horizontal");
        float y_Posi = Input.GetAxisRaw("Vertical");
        Vector3 vt3 = new Vector3(x_Posi, y_Posi, 0).normalized;

        if ((transform.position.x <= -7.75 && x_Posi < 0) || (transform.position.x >= 6.5 && x_Posi > 0) || (transform.position.y >= -3.5 && y_Posi > 0) || (transform.position.y <= -6.71 && y_Posi < 0)) {
            moveSpeed = Vector3.zero;
            // return;
        }
        else {
            if (vt3.magnitude > 0) {
                moveSpeed = Vector3.MoveTowards(moveSpeed, vt3 * maxSpeed, giaToc * Time.deltaTime);
            }
            else {
                moveSpeed = Vector3.MoveTowards(moveSpeed, Vector3.zero, giaTocGiam * Time.deltaTime);
            }
        }

        // transform.position += Vector3.right * moveSpeed * x_Posi * Time.deltaTime;
        // transform.position += Vector3.up * moveSpeed * y_Posi * Time.deltaTime;
        transform.Translate(moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    public void Shoot() {
        if (bullet && shootingPoint) {
            if (aus & shootingPoint) {
                aus.PlayOneShot(shootingSound);
            }
            Instantiate(bullet, shootingPoint.position, quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Enemy")) {
            m_gc.setGameOver(true);

            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            m_gc.setGameOver(true);

            Destroy(other.gameObject);
        }
    }
}
