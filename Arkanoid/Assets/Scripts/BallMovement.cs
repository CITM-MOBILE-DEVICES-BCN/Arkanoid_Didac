using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] float speed = 300;
    private Rigidbody2D rigidBody;
    private Vector2 velocity;
    private Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        Invoke("LaunchBall", 2);
    }

    public void LaunchBall()
    {
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;
        rigidBody.AddForce(velocity * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rigidBody.velocity.magnitude < 1000)
        {
            rigidBody.velocity *= 1.025f;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            transform.position = initialPosition;
            rigidBody.velocity = new Vector3(0, 0, 0);
            UIController.instance.LoseLife();
            Invoke("LaunchBall", 1);
        }
    }
}
