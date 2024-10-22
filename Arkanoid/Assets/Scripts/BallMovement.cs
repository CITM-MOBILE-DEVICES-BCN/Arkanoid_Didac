using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] float speed = 300;
    private Rigidbody2D rigidBody;
    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Invoke("LaunchBall", 2);
    }

    public void LaunchBall()
    {
        //transform.position = new Vector3(0, -163, transform.position.z);
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = 1;
        rigidBody.AddForce(velocity * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidBody.velocity *= 1.025f;

        if(collision.collider.CompareTag("Death"))
        {

        }
    }
}
