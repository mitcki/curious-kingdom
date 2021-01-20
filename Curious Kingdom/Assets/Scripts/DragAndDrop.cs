using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    bool touchingBasket;
    Vector3 startPosition;
    float speed = 10;
    public int pickleCount = 0;
    public TextMeshProUGUI resultDisplay;
    public TextMeshProUGUI neededPickles;
    // int picklesNeededCount;
    void Start()
    {
        canMove = false;
        dragging = false;
        startPosition = transform.position; 
        resultDisplay = GameObject.Find("Canvas").transform.Find("resultDisplay").GetComponent<TextMeshProUGUI>();
        neededPickles = GameObject.Find("Canvas").transform.Find("neededPickles").GetComponent<TextMeshProUGUI>();

        // picklesNeededCount = Random.Range(3, 9);

        neededPickles.text = GameStatus.picklesNeededCount.ToString();

        resultDisplay.text = "? + ? = " + GameStatus.picklesNeededCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(GameStatus.dropCount < 2){
            if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
            {
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
                {
                    canMove = true;
                    gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
                }
                else
                {
                    canMove = false;
                }
                if (canMove)
                {
                    dragging = true;
                }
            

            }
        }
        if(touchingBasket){
                dragging = false;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                Vector3 newLoc;
                if(GameStatus.dropCount == 1){
                    newLoc = GameObject.Find("basket-front").transform.position;
                } else {
                    newLoc = GameObject.Find("basket-front").transform.position;
                }
                this.transform.position = Vector3.Lerp(this.transform.position,  newLoc, Time.deltaTime * speed);

        } else if (dragging)
        {
            this.transform.position = mousePos;
        } else {
            if(this.transform.position != this.startPosition){
                this.transform.position = Vector3.Lerp(this.transform.position, this.startPosition, Time.deltaTime * speed);
            }
        }
        if (Input.GetMouseButtonUp(0) && Input.touchCount <= 0 )
        {
            canMove = false;
            dragging = false;

        }

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "basket-front"){
            touchingBasket = true;
            GameStatus.score += this.pickleCount;

            if(GameStatus.dropCount < 1){
                GameStatus.dropCount += 1;
                GameStatus.jar1 = this.pickleCount;
                resultDisplay.text = GameStatus.jar1 + " + ? = " + GameStatus.picklesNeededCount.ToString();
            } else {
                GameStatus.dropCount += 1;
                GameStatus.jar2 = this.pickleCount;
                resultDisplay.text = GameStatus.jar1 + " + " + GameStatus.jar2 + " = " + GameStatus.score;
                StartCoroutine(checkResults());
            }

        }
    }
    IEnumerator checkResults(){
        if(GameStatus.score == GameStatus.picklesNeededCount){
            yield return new WaitForSeconds(3);
            resultDisplay.text = "Correct!";
            yield return new WaitForSeconds(3);
            pickleCount = 0;
            GameStatus.score = 0;
            GameStatus.dropCount = 0;
            SceneManager.LoadScene("PickleGame");
        } else {
            yield return new WaitForSeconds(2);
            resultDisplay.text = "Try Again!";
            yield return new WaitForSeconds(3);
            pickleCount = 0;
            GameStatus.score = 0;
            GameStatus.dropCount = 0;
            SceneManager.LoadScene("PickleGame");
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        touchingBasket = false;
    }
}

