using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryGame : MonoBehaviour
{
    public void RetryGameFunc()
    {
        ButtonController.instance.StartGame();
    }
}
