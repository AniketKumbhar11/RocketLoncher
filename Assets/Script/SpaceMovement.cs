using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float Movement;


    private void Start()
    {
       
        rb = GetComponent<Rigidbody2D>(); //InvokeRepeating("SetRandomPos", 0, 5);
        Movement = -0.5f;
    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 0f, 1f));
       
        rb.velocity = new Vector2(Movement,0f);
        Destroy(gameObject, 20f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Border")
        {
            if (Movement>0)
            {
                Debug.Log("AAAAA");
                Movement = -1f;
            }else
            {
                Debug.Log("BBBB");
                Movement = 1f;
            }
        }
    }
}
