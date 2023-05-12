using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    Rigidbody2D rb;
    float ghostSpeed = 5f;
    Vector2 startPos;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(ghostSpeed * Time.deltaTime, 0f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
