using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool faceRight = true;
    public GameObject bullet;
    GameObject bulletClone;
    public Transform leftspawn;
    public float speed;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        Fire();
    }
    void FlipPlayer()
    {
        if(Input.GetKeyDown(KeyCode.A) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }
    void Fire()
    {
        if(Input.GetMouseButtonDown(0)&& faceRight)
        {
            bulletClone = Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(bulletClone,1.5f);
        }
        else if(Input.GetMouseButtonDown(0) && !faceRight)
        {
            bulletClone = Instantiate(bullet, transform.position,leftspawn.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
            Destroy(bulletClone, 1.5f);
        }
    }
}
