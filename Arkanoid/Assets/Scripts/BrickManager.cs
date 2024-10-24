using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{

    public GameObject greenBrickPrefab;
    public GameObject blueBrickPrefab;
    public GameObject redBrickPrefab;
    public List<GameObject> allBricks;
    private DataSaver dataSaver = new DataSaver();
    private int bricksAlive;

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
        bricksAlive = allBricks.Count;
        if(GameManager.instance.gameSaved)
        {
            Debug.Log("LoadBricks");
            LoadBricks();
        }
        ButtonController.instance.SaveGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(bricksAlive != 0)
        {
            for (int i = 0; i < allBricks.Count; i++)
            {
                if (allBricks[i].GetComponent<Brick>().brickLife == 0 && allBricks[i].GetComponent<Brick>().isDead == false)
                {
                    bricksAlive--;
                    allBricks[i].GetComponent<Brick>().isDead = true;
                }
            }
        } 
        else if (bricksAlive == 0)
        {
            if(GameManager.instance.isLevel1)
            {
                GameManager.instance.gameSaved = false;
                GameManager.instance.LoadLevel2();

            }
            else if (!GameManager.instance.isLevel1)
            {
                GameManager.instance.LoadLevel1();
            }
            
        }
        
    }
    public void SaveBricks()
    {
        
        for(int i = 0;i < allBricks.Count;i++)
        {
            Debug.Log(i);
            Debug.Log(allBricks[i].GetComponent<Brick>().brickLife);
            dataSaver.SaveBricksPrefs(allBricks[i].GetComponent<Brick>().brickLife, i);
        }
        
    }
    public void LoadBricks()
    {
        Debug.Log("Loading Bricks Info");
        for (int i = 0; i < allBricks.Count; i++)
        {
            allBricks[i].GetComponent<Brick>().brickLife = dataSaver.LoadBricksPrefs(i);
        }
    }
}
