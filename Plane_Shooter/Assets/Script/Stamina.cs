using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
    public Slider staminaSlider;

    public Slider easeStaminaSlider;

    public float maxStamina = 100f;

    public float stamina;

    public float lerpSpeed = 0.03f;

    public float restoreStamina;

    public float m_restoreStamina;

    bool isWaiting = false;

    public bool canDash = true;

    private void Start() {
        stamina = maxStamina;
    }

    private void Update() {
        if (staminaSlider.value != stamina) {
            staminaSlider.value = stamina;
        }

        if (staminaSlider.value != easeStaminaSlider.value) {
            easeStaminaSlider.value = Mathf.Lerp(easeStaminaSlider.value, stamina, lerpSpeed);
        }

        StaminaIncre();
    }

    public void StaminaDescre() {
        stamina--;
        if (stamina <= 0) {
            canDash = false;
            StartCoroutine(WaitForStaminaRecovery());
        }
    }

    public void StaminaIncre() {
        if (stamina < maxStamina) {
            m_restoreStamina -= Time.deltaTime;

            if (m_restoreStamina <= 0) {
                stamina += Time.deltaTime * 2f;
                stamina = Mathf.Min(stamina, maxStamina);
                m_restoreStamina = restoreStamina;
            }
        }
    }

    private IEnumerator WaitForStaminaRecovery() {
        isWaiting = true;

        StaminaIncre();

        yield return new WaitForSeconds(3f);
        isWaiting = false;
        canDash = true;
    }
}
