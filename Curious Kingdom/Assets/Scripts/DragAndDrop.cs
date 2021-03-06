﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using FTRuntime;
using FTRuntime.Yields;

public class DragAndDrop : MonoBehaviour
{
    bool canMove;
    bool dragging;
    bool returned = true;
    public bool touchingBasket;
    bool placed;
    Vector3 startPosition;
    Vector3 lerpStartPosition;
    float arrivalDistance, wait;
    float speed = 10;
    float lerpTime = 0.25f;
    float currentLerpTime;
    public int pickleCount = 0;
    public TextMeshProUGUI resultDisplay;
    public TextMeshProUGUI neededPickles;
    // int picklesNeededCount;
    void Start()
    {
        canMove = false;
        dragging = false;
        placed = false;
        startPosition = transform.position; 
        resultDisplay = GameObject.Find("Canvas").transform.Find("resultDisplay").GetComponent<TextMeshProUGUI>();
        // neededPickles = GameObject.Find("Canvas").transform.Find("neededPickles").GetComponent<TextMeshProUGUI>();

        
        
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
                    returned = false;
                    Debug.Log("pickup");
                    SFX.player.PlaySound(0);
                }
            

            }
        }
        if(touchingBasket){
                
            MoveToBasket();
        } else if (dragging)
        {
            this.transform.position = mousePos;
        } else {
            if(this.transform.position != this.startPosition){
                // this.transform.position = Vector3.Lerp(this.transform.position, this.startPosition, Time.deltaTime * speed);
                this.transform.position = Vector3.Lerp(this.transform.position, this.startPosition, 0.5f);
                returned = false;

            }
            if(this.transform.position == this.startPosition && returned == false){
                returned = true;
                SFX.player.PlaySound(2);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;

        }
        if (Input.touchSupported && Input.touchCount <= 0)
        {
            canMove = false;
            dragging = false;
        }
    }
    public void MoveToBasket (){
        dragging = false;
        if(placed == false){
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            SFX.player.PlaySound(1);
            Vector3 newLoc;
            if(GameStatus.dropCount < 2){
                newLoc = GameObject.Find("basket-front").transform.position;
                newLoc.y += 0.5f;
                newLoc.x -= 0.5f;
            } else {
                newLoc = GameObject.Find("basket-front").transform.position;
                newLoc.y += 0.5f;
                newLoc.x += 0.5f;
            }
            // this.transform.position = Vector3.Lerp(this.transform.position,  newLoc, Time.deltaTime * speed);
            lerpStartPosition = this.transform.position;
            currentLerpTime = 0;
                StartCoroutine( GoTo(newLoc) );
            placed = true;
        }
    }
    IEnumerator GoTo( Vector3 dest )
    {
        // Check the sqMag to spare a Sqrt
        while( (dest - transform.position).sqrMagnitude > arrivalDistance )
        {
            // transform.position = Vector3.Lerp(transform.position, dest, Time.deltaTime * speed);
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime) {
                currentLerpTime = lerpTime;
            }
    
            //lerp!
            // float perc = currentLerpTime / lerpTime;
            float t = currentLerpTime / lerpTime;
            t = t*t * (3f - 2f*t);
            transform.position = Vector3.Lerp(lerpStartPosition, dest, t);
            yield return null;
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
            GameObject castleAnimation = GameObject.Find("CASTLE-ICON_SEQ11.fla.CASTLE_ICON_SEQ11");
            castleAnimation.GetComponent<SwfClipController>().GotoAndPlay(617);
            castleAnimation.GetComponent<AudioSource>().clip = castleAnimation.GetComponent<AudioSources>().AudioFiles[1];
            castleAnimation.GetComponent<AudioSource>().Play();
            StartCoroutine(StopCastleAnimation(4.0f));
            yield return new WaitForSeconds(3);
            resultDisplay.text = "Correct!";
            SFX.player.PlaySound(3);
            yield return new WaitForSeconds(3);
            pickleCount = 0;
            GameStatus.score = 0;
            GameStatus.dropCount = 0;
            GameStatus.wins += 1;
            if(GameStatus.wins == 3){
                SceneManager.LoadScene("Intro3");
            } else {
                SceneManager.LoadScene("PickleGame");
            }
        } else {
            
            GameObject castleAnimation = GameObject.Find("CASTLE-ICON_SEQ11.fla.CASTLE_ICON_SEQ11");
            castleAnimation.GetComponent<SwfClipController>().GotoAndPlay(445);
            castleAnimation.GetComponent<AudioSource>().clip = castleAnimation.GetComponent<AudioSources>().AudioFiles[0];
            castleAnimation.GetComponent<AudioSource>().Play();
            StartCoroutine(StopCastleAnimation(6.0f));
            yield return new WaitForSeconds(2);
            resultDisplay.text = "Try Again!";
            yield return new WaitForSeconds(3);
            // pickleCount = 0;
            GameStatus.score -= this.pickleCount;
            GameStatus.dropCount = 1;
            // SceneManager.LoadScene("PickleGame");
            if(this.transform.position != this.startPosition){
                touchingBasket = false;
                // this.transform.position = Vector3.Lerp(this.transform.position, this.startPosition, Time.deltaTime * speed);
                resultDisplay.text = GameStatus.jar1 + " + ? = " + GameStatus.picklesNeededCount.ToString();
                
            }
        }
    }
    IEnumerator StopCastleAnimation(float seconds){
            yield return new WaitForSeconds(seconds);
            GameObject castleAnimation = GameObject.Find("CASTLE-ICON_SEQ11.fla.CASTLE_ICON_SEQ11");
            castleAnimation.GetComponent<SwfClipController>().Stop(false);
    }
    private void OnCollisionExit2D(Collision2D other) {
        // touchingBasket = false;
    }
}

