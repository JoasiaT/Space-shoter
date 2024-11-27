using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 2f;
    public Transform playerTransform;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        rb.velocity = (playerTransform.position - transform.position).normalized * speed;
        //transform.Translate((playerTransform.position - transform.position).normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //playerTransform.Translate((playerTransform.position - transform.position).normalized * speed * Time.deltaTime);
        //transform.Translate((playerTransform.position - transform.position).normalized * speed * Time.deltaTime);
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.pleyerController.HittedByBullet();
             
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
