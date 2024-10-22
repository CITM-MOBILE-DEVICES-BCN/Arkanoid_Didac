using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Slider sliderDis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        transform.position = new Vector3(Mathf.Lerp(233.55f, 859.67f, sliderDis.value), transform.position.y, transform.position.z);
    }
}
