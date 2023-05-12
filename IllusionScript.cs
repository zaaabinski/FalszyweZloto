using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class IllusionScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Color temp = gameObject.GetComponent<SpriteRenderer>().color;
        if(temp.a >= 0.7)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        }
        if(temp.a <=0.7)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
