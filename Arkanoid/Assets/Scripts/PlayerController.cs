using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Slider sliderDis;
    public bool isAutomatic = false;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAutomatic)
        {
            transform.position = new Vector3(ball.transform.position.x, transform.position.y, transform.position.z);
        }
        else if (!isAutomatic)
        {
            transform.position = new Vector3(Mathf.Lerp(233.55f, 859.67f, sliderDis.value), transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            isAutomatic = !isAutomatic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PowerUp")
        {
            UIController.instance.scoreMultiplier++;
            collision.gameObject.SetActive(false);
        }
    }
}
