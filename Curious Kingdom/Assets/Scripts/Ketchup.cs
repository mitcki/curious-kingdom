using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ketchup : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Found = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        // other.GetComponent<Rigidbody2D>().gravityScale = 0;
        if(other.name == "king_torch" && Found == false){
            // GameObject.Destroy(gameObject);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Play();

            Found = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // other.GetComponent<Rigidbody2D>().gravityScale = 1;
        
    }
}
