using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStatus : MonoBehaviour
{
    public static int score;
    public static int jar1;
    public static int jar2;
    public static int dropCount;
    public static int picklesNeededCount;
    // Start is called before the first frame update
    void Start()
    {
        picklesNeededCount = Random.Range(3, 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
