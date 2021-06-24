using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameStatus : MonoBehaviour
{
     public TextMeshProUGUI resultDisplay;
    public TextMeshProUGUI neededPickles;
    public static int score;
    public static int wins = 0;
    public static int jar1;
    public static int jar2;
    public static int dropCount;
    public static int picklesNeededCount;
    public static int firstNumber;
    // Start is called before the first frame update
    void Start()
    {
        if(Music.player){
            Music.player.PlayMusic(4);
        }
        picklesNeededCount = Random.Range(3, 10);
        firstNumber = Random.Range(1, picklesNeededCount-1);
        if(firstNumber > 1 && picklesNeededCount-firstNumber == firstNumber){
            firstNumber -= 1;
        }
        resultDisplay = GameObject.Find("Canvas").transform.Find("resultDisplay").GetComponent<TextMeshProUGUI>();
        neededPickles = GameObject.Find("Canvas").transform.Find("neededPickles").GetComponent<TextMeshProUGUI>();

        // picklesNeededCount = Random.Range(3, 9);

        neededPickles.text = GameStatus.picklesNeededCount.ToString();

        // resultDisplay.text = "? + ? = " + GameStatus.picklesNeededCount.ToString();
        resultDisplay.text = " " ;

        StartCoroutine(placeFirstJar());

    }
    IEnumerator placeFirstJar()
    {
        if(PickleBasket.seenOnce == false){
            PickleBasket.seenOnce = true;

            yield return new WaitForSeconds(14);
        } else {
            yield return new WaitForSeconds(2);
        }
        
        GameObject.Find("VO").GetComponent<AudioSource>().Play();
        GameObject.Find("pickle-jar-"+firstNumber).GetComponent<DragAndDrop>().MoveToBasket();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
