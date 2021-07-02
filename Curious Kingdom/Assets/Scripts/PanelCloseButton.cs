using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCloseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        // Application.OpenURL("https://playper.com");
        ScanAudio.panel.SetActive(false);
        ScanAudio.playsetPanel.SetActive(false);
        ScanAudio.noCamPanel.SetActive(false);
	}
}
