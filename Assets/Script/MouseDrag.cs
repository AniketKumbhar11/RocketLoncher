using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Rigidbody2D rb;
    private float XPos;
    private float YPos;
    public  float AmmoSpeed;
    public float AmmoFireTime;

    [SerializeField] private float SingleAmmoSpeed = 15f;
    [SerializeField] private float SingleAmmoFireTime = 0.3f;

    [SerializeField] private float DouubleAmmoSpeed = 20f;
    [SerializeField] private float DoubleAmmoFireTime = 0.1f;

    public static MouseDrag insatce;

    [SerializeField] private GameObject leftgunpoint;
    [SerializeField] private GameObject Rightgunpoint;
    [SerializeField] private GameObject Middlegunpoint;
    [SerializeField] private GameObject Ammo;
    [SerializeField] private GameObject DoubleFireObj;





    private bool SingleFire;
    private bool DoubleFire;
    private bool ExtraShip;

    GameObject instantiateobj;
    void Start()
    {
        SwpanEnemy. PauseBool = false;
        insatce = this;

        SingleFire = true;
        rb = GetComponent<Rigidbody2D>();
        Invoke("GunFire", AmmoFireTime);

    }

    // Update is called once per frame
    void Update()
    {
        InputTouch();
        IncreaseAmoSpeed();
        if (SwpanEnemy.PauseBool)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }

    }

    private void IncreaseAmoSpeed()
    {
        if (SwpanEnemy.Score>50)
        {
            SingleAmmoSpeed = 17f;
            SingleAmmoFireTime = 0.2f;
            DouubleAmmoSpeed = 12f;
            DoubleAmmoFireTime = 0.1f;
            SwpanEnemy.InstantiateTime = 1;

        }
    }

    private void GunFire()
    {
        if (SingleFire)
        {
            AmmoSpeed = SingleAmmoSpeed;
            AmmoFireTime = SingleAmmoFireTime;

            instantiateobj = Instantiate(Ammo, Middlegunpoint.transform.position, Quaternion.identity, gameObject.transform);
            instantiateobj.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector3(0, 0, AmmoSpeed));
            Invoke("GunFire", AmmoFireTime);

        }
        else if (DoubleFire&&!SingleFire)
        {
            AmmoSpeed = DouubleAmmoSpeed;
            AmmoFireTime = DoubleAmmoFireTime;
            instantiateobj = Instantiate(Ammo, leftgunpoint.transform.position, Quaternion.identity, gameObject.transform);
            instantiateobj = Instantiate(Ammo, Rightgunpoint.transform.position, Quaternion.identity, gameObject.transform);
            instantiateobj.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector3(0, 0, AmmoSpeed));
            Invoke("GunFire", AmmoFireTime);
        }else
        {

        }

     



    }

    private void InputTouch()
    {
        if (Input.touchCount>0)
        {
            Touch Touch = Input.GetTouch(0);
            Vector2 TouchPos = Camera.main.ScreenToWorldPoint(Touch.position);
        
            switch (Touch.phase)
            {
                case TouchPhase.Began:
                    XPos = TouchPos.x - transform.position.x;
                    YPos = TouchPos.y - transform.position.y;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(TouchPos.x-XPos,TouchPos.y-YPos));                
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="DoubleFire")
        {
            SingleFire = false;
            DoubleFire = true;

            Destroy(collision.gameObject);
        
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
            SwpanEnemy.ObjSwpanEnemy.GameOver();
        }


    }
}
