using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI levelDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("here");
        levelDisplay = GetComponent<TextMeshProUGUI>();
        levelDisplay.text = "Level: " + ItemCount.gameLevel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
