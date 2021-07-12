using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireObject;
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "GoodItem")
        {
            Debug.Log("GoodItem");
            if(gameObject.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezeAll)
            {
                GameObject fire = Instantiate(fireObject,gameObject.transform.position,Quaternion.identity) as GameObject;
                fire.transform.localScale = new Vector3(0.075f,0.075f,0.075f);
                TowerKing towerKing = GameObject.Find("TowerKing").GetComponent<TowerKing>();
                towerKing.Replay();
                ItemCount.badItemCount++;
                
                GameObject.Destroy(other.gameObject);
                GameObject.Destroy(gameObject);


            }
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
