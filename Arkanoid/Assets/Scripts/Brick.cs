using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{

    private BoxCollider2D boxCollider2D;
    private Image image;
    public int brickLife = 1;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        image = GetComponent<Image>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        brickLife--;
        if(brickLife == 0)
        {
            boxCollider2D.enabled = false;
            image.enabled = false;
            UIController.instance.AddPoints();
        }
        
    }
}
