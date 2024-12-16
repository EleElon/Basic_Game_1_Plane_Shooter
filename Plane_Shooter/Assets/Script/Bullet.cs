using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D m_rb;

    GameController m_gc;

    public float speed;

    public float timeToDestroy;

    AudioSource aus;

    public AudioClip hitSound;

    public GameObject hitVFX;

    // Start is called before the first frame update
    void Start() {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindAnyObjectByType<GameController>();
        aus = FindAnyObjectByType<AudioSource>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update() {
        m_rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Enemy")) {

            m_gc.scoreIncrement();

            if (aus && hitSound) {
                aus.PlayOneShot(hitSound);
            }

            if (hitVFX) {
                GameObject vfxInstantiate = Instantiate(hitVFX, col.transform.position, Quaternion.identity);
                Destroy(vfxInstantiate, timeToDestroy);
            }
            Destroy(gameObject);

            Destroy(col.gameObject);
        }
    }
}
