using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform minXValue;
    public Transform maxXValue;

    public GameObject bulletPrefab;
    public Transform gunEndPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }
    void PlayerMovement()
    {
        float horizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 mevementVector = new Vector2(horizontalInputValue, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(mevementVector);
        if (transform.position.x > maxXValue.position.x)
        {
            transform.position = new Vector2(maxXValue.position.x, transform.position.y);
        }

        if (transform.position.x < minXValue.position.x)
        {
            transform.position = new Vector2(minXValue.position.x, transform.position.y);
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, gunEndPosition.position, Quaternion.identity);
    }
}
