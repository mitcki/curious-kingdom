using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowWorm : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] worms;
    void Start()
    {
        int randWorm = Random.Range(0, worms.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = worms[randWorm];
    }

    public void Glow()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
