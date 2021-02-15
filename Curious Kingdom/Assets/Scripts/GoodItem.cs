using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] veggies = new string[] {"avocado","broccoli", "lettuce", "carrot", "cucumber","garlic","green_pepper","tomato","yellow_pepper"};
    public static string randomVeggie = "";
    void Start()
    {
        if(randomVeggie.Length < 1){
            randomVeggie = veggies[Random.Range(0,veggies.Length)];
            Debug.Log("switching to " + randomVeggie);
            GameObject veggieLabel = GameObject.Find("veggie_label");
            SpriteRenderer spriteR = veggieLabel.GetComponent<SpriteRenderer>();
            spriteR.sprite = Resources.Load<Sprite>(randomVeggie);
            ItemCount.totalItems = 0;

        }
        Vector3 oldScale = gameObject.transform.localScale;
        Destroy(gameObject);
        GameObject newVeggie = Instantiate(Resources.Load("Prefabs/"+randomVeggie),transform.position,transform.rotation) as GameObject;
        newVeggie.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        ItemCount.totalItems ++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
