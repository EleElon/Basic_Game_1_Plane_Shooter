using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuAnimationController : MonoBehaviour {

    [SerializeField] private CanvasGroup canvasGroup; // Gắn CanvasGroup của button hoặc UI cần reset

    void Start()
    {
        if (MenuController.shouldResetAnim)
        {
            ResetCanvasGroup();
        }
    }

    private void ResetCanvasGroup()
    {
        canvasGroup.alpha = 1f;               // Reset độ mờ về giá trị mặc định
        canvasGroup.interactable = true;     // Cho phép tương tác
        canvasGroup.blocksRaycasts = true;   // Cho phép nhận sự kiện chuột
    }
}
