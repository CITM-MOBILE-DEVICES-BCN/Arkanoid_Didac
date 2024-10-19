using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] float speed = 10;
    private float timeToLaunch = 0;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (timeToLaunch > 2)
        {
           rigidBody.velocity = new Vector2(Random.Range(-1, 1) * speed, Random.Range(-1, 1) * speed);
        } 
        else
        {
            timeToLaunch += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
