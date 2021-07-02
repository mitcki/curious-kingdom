using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlaysetButton : MonoBehaviour
{
    void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        // Application.OpenURL("https://playper.com");
        ScanAudio.panel.SetActive(false);
        ScanAudio.playsetPanel.SetActive(true);
	}
}
