using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class amoscript : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;

    void Start()
    {
        speed = MouseDrag.insatce.AmmoSpeed;
        rb = GetComponent<Rigidbody2D>();
        // CountScore = 0;
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0f, speed, 0f);
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "DoubleFire")
        {
            Destroy(gameObject);
        }



    }



}
