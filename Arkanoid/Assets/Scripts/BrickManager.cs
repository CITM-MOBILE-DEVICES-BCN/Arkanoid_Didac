using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{

    public GameObject greenBrickPrefab;
    public GameObject blueBrickPrefab;
    public GameObject redBrickPrefab;
    public List<GameObject> allBricks;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.isLevel1)
        {

            for (int i = 0; i < 9; i++)
            {
                var blueBrick = Instantiate(blueBrickPrefab);
                blueBrick.transform.SetParent(this.transform, false);

                allBricks.Add(blueBrick);
            }
            for (int i = 0; i < 9; i++)
            {
                var greenBrick = Instantiate(greenBrickPrefab);
                greenBrick.transform.SetParent(this.transform, false);
                allBricks.Add(greenBrick);
            }
        }
        else if (!GameManager.instance.isLevel1)
        {
            for (int i = 0; i < 9; i++)
            {
                var redBrick = Instantiate(redBrickPrefab);
                redBrick.transform.SetParent(this.transform, false);
                allBricks.Add(redBrick);
            }
            for (int i = 0; i < 9; i++)
            {
                var blueBrick = Instantiate(blueBrickPrefab);
                blueBrick.transform.SetParent(this.transform, false);
                allBricks.Add(blueBrick);
            }
            for (int i = 0; i < 9; i++)
            {
                var greenBrick = Instantiate(greenBrickPrefab);
                greenBrick.transform.SetParent(this.transform, false);
                allBricks.Add(greenBrick);
            }
            
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(allBricks.Count != 0)
        {
            for (int i = 0; i < allBricks.Count; i++)
            {
                if (allBricks[i].GetComponent<Brick>().brickLife == 0)
                {
                    allBricks.RemoveAt(i);
                }
            }
        } 
        else if (allBricks.Count == 0)
        {
            if(GameManager.instance.isLevel1)
            {
                GameManager.instance.LoadLevel2();
            }
            else if (!GameManager.instance.isLevel1)
            {
                GameManager.instance.LoadLevel1();
            }
            
        }
        
    }
}
