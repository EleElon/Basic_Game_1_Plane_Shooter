using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    private Vector3 moveSpeed = Vector3.zero;

    public float maxSpeed;

    public float dashSpeed;

    public float giaToc;

    public float giaTocGiam;

    public float phanh;

    public GameObject bullet;

    public GameController m_gc;

    public Transform shootingPoint;

    public AudioManager aum;

    UIManager m_ui;

    Stamina m_stm;

    int bulletsRemaining = 10;

    public float timeToGetBullet;

    float m_timeToGetBullet;

    // Start is called before the first frame update
    void Start() {
        m_gc = FindAnyObjectByType<GameController>();
        m_ui = FindAnyObjectByType<UIManager>();
        m_stm = FindAnyObjectByType<Stamina>();

        string bulletsString = string.Empty;
        for (int i = 0; i < 10; i++) {
            bulletsString += "|=>";
        }

        m_ui.setBulletsText(bulletsString);
    }

    // Update is called once per frame
    void Update() {
        if (m_ui.IsGamePausePanelActive() || m_gc.isGameOver())
            return;

        if (Input.GetKey(KeyCode.LeftShift) && m_stm.canDash && m_stm.stamina > 0) {
            Dash();
            m_stm.StaminaDescre();
        }
        else if (Input.GetKey(KeyCode.Space)) {
            MoveStop();
        }
        else {
            Move();
        }

        if (bulletsRemaining < 10) {
            m_timeToGetBullet -= Time.deltaTime;

            if (m_timeToGetBullet <= 0) {
                bulletsRemaining++;
                m_timeToGetBullet = timeToGetBullet;
            }
        }

        string bulletsString = string.Empty;
        for (int i = 0; i < bulletsRemaining; i++) {
            bulletsString += "|=>";
        }

        m_ui.setBulletsText(bulletsString);

        // transform.position += Vector3.right * moveSpeed * x_Posi * Time.deltaTime;
        // transform.position += Vector3.up * moveSpeed * y_Posi * Time.deltaTime;
        transform.Translate(moveSpeed * Time.deltaTime);
        if (m_ui.IsGamePausePanelActive() || m_gc.isGameOver() || !m_ui.IsSettingPanelActive()) {

            if (Input.GetMouseButtonDown(0)) {
                Shoot();
            }
        }
        else {
            return;
        }
    }

    public void Dash() {
        float x_Posi = Input.GetAxisRaw("Horizontal");
        float y_Posi = Input.GetAxisRaw("Vertical");
        Vector3 vt3 = new Vector3(x_Posi, y_Posi, 0).normalized;

        if ((transform.position.x <= -7.75 && x_Posi < 0) || (transform.position.x >= 6.5 && x_Posi > 0) || (transform.position.y >= -3.5 && y_Posi > 0) || (transform.position.y <= -6.71 && y_Posi < 0)) {
            moveSpeed = Vector3.zero;
            // return;
        }
        else {
            if (vt3.magnitude > 0) {
                moveSpeed = vt3 * dashSpeed;
            }
            else {
                // dashSpeed += Vector3.MoveTowards(dashSpeed, Vector3.zero, giaTocGiam * Time.deltaTime);
            }
        }
    }

    public void MoveStop() {
        moveSpeed = Vector3.MoveTowards(moveSpeed, Vector3.zero, phanh * Time.deltaTime);
    }

    public void Move() {
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
    }

    public void Shoot() {
        if (bulletsRemaining == 0) {
            return;
        }

        if (bullet && shootingPoint) {
            if (aum & shootingPoint) {
                aum.playSFX(aum.shootingSound);
            }
            Instantiate(bullet, shootingPoint.position, quaternion.identity);
        }

        bulletsRemaining--;

        string bulletsString = string.Empty;
        for (int i = 0; i < bulletsRemaining; i++) {
            bulletsString += "|=>";
        }

        m_ui.setBulletsText(bulletsString);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Enemy")) {
            // m_gc.setGameOver(true);
            m_gc.HPDecrease();

            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            // m_gc.setGameOver(true);
            if (aum && aum.loseSound) {
                aum.playSFX(aum.loseSound);
            }

            m_gc.HPDecrease();

            Destroy(other.gameObject);
        }
    }
}
