using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanAudio : MonoBehaviour
{
    public GameObject Permissions;

    // Start is called before the first frame update
    public static GameObject panel;
    public static GameObject playsetPanel;
    public static GameObject noCamPanel;
    public static GameObject instance;
    void Start()
    {
        ScanAudio.instance = gameObject;
        ScanAudio.panel = GameObject.Find("ScanPanel");
        ScanAudio.panel.SetActive(false);

        ScanAudio.playsetPanel = GameObject.Find("PlaysetPanel");
        ScanAudio.playsetPanel.SetActive(false);

        ScanAudio.noCamPanel = GameObject.Find("NoCamPanel");
        ScanAudio.noCamPanel.SetActive(false);

    }

    public void StartPermissionsLoad()
    {
        StartCoroutine(loadPermissions());
    }
    IEnumerator loadPermissions(){
        yield return new WaitForSeconds(0.5f);

        ScanAudio.panel.SetActive(false);

        yield return new WaitForSeconds(15f);

        ScanAudio audioRef = ScanAudio.instance.GetComponent<ScanAudio>();
        Instantiate(audioRef.Permissions);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
