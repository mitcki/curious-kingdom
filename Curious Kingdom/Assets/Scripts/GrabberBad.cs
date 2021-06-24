using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberBad : MonoBehaviour
{
    public int count = 0;
    // Start is called before the first frame update
    public GameObject[] gos;
    void Start()
    {
        
        StartCoroutine(initVeggies());
    }
    IEnumerator initVeggies()
    {
        yield return new WaitForSeconds(0.25f);
        gos = GameObject.FindGameObjectsWithTag("BadItem");
        StartCoroutine(cueNextVeggie());

    }
    IEnumerator cueNextVeggie(){
        yield return new WaitForSeconds(0.25f);
        gos[count].transform.position = transform.position;
        gos[count].transform.position += new Vector3(0,-0.4f,0);
        gos[count].transform.SetParent(gameObject.transform);
        gos[count].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) || Input.touchCount == 1)
        {
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                gos[count].transform.position = transform.position;
                gos[count].transform.position += new Vector3(0,-0.4f,0);
                gos[count].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                gos[count].transform.SetParent(gameObject.transform.parent);


                count++;

                if(count < gos.Length){
                    StartCoroutine(cueNextVeggie());
                }
                // Debug.Log("Touching Grabber");
                // GameObject cabbage = Instantiate (Resources.Load ("Prefabs/cabbage") as GameObject);
                // GameObject cabbage = GameObject.Find("cabbage_"+count);
                // gos[count].transform.position = transform.position;
                // gos[count].transform.position += new Vector3(0,-0.4f,0);
                // gos[count].transform.localScale = new Vector3(0.6f,0.6f,0.6f);
            }

        }
        
    }
}
