using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidePanelManager : MonoBehaviour {
    public GameObject guideScrollView;

    public Button backToMenuButton;

    public List<Text> guideTextlist;

    // Start is called before the first frame update
    void Start() {
        guideScrollView.SetActive(false);
    }

    public void ShowGuidePanel(bool state) {
        if (guideScrollView) {
            guideScrollView.SetActive(state);
        }
    }

    public void HideGuidePanel(bool state) {
        if (guideScrollView) {
            guideScrollView.SetActive(state);
        }
    }
}
