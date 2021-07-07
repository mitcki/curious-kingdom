using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public string nextScene;
    // Start is called before the first frame update
    void Start () {
        Debug.Log("Skip Button");
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
        SceneManager.LoadScene(nextScene);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
