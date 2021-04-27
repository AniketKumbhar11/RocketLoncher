using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class enemyscript : MonoBehaviour
{
   private Rigidbody2D rb;
   private float Movement;

    [SerializeField] private TMP_Text CountText;
    [SerializeField] private SpriteRenderer Sprite;
    public int Helth;
   
   private float Size;
    private bool IsSuppy;


    private void Start()
    {
        
        Size = Random.Range(0.5f, 2f);
        Sprite.transform.localScale =new  Vector3(Size, Size, 0f);
        Sprite.color = new Color((Random.Range(0f, 1f)), (Random.Range(0f, 1f)), (Random.Range(0f,1f)), 1f); 

        rb = GetComponent<Rigidbody2D>();
        Movement = -0.45f;

        Helth=SwpanEnemy.EnemyHelth;
        CountText.text = Helth.ToString();
        if (Helth>=20)
        {
            IsSuppy = true;
        }

    }

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 0f, 1f));
        CountText.text = Helth.ToString();
        rb.velocity = new Vector2(Movement, 0f);
        Destroy(gameObject, 15f);

        if (SwpanEnemy.PauseBool)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Border")
        {
            if (Movement > 0)
               Movement = -1f;
            else
                Movement = 1f;        
        }

        if (collision.gameObject.tag == "Ammo")
        {
            if (Helth > 0)
            {
                Helth--;
                SwpanEnemy.Score++;

                Destroy(collision.gameObject);
            }
            else
            {
                  GameObject partical=Instantiate(SwpanEnemy.ObjSwpanEnemy.PraticalSystem, collision.gameObject.transform);
                  Destroy(partical,5f);
                   Destroy(this.gameObject);
                if (IsSuppy)
                {
                    GameObject sup = Instantiate(SwpanEnemy.ObjSwpanEnemy.SupplerPrefab,collision.gameObject.transform.position,Quaternion.identity, SwpanEnemy.ObjSwpanEnemy.SupplyCollcetor.transform);
                }
            }
        }
    }
}
