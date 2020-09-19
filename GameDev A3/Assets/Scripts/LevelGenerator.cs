using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    //1
    public GameObject outsideCorner;
    //2
    public GameObject outsideWall;
    //3
    public GameObject insideCorner;
    //4
    public GameObject insideWall;
    //5
    public GameObject standardPellet;
    //6
    public GameObject powerPellet;
    //7
    public GameObject tJunction;
    int[,] levelMap =
{
                    {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
                    {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
                    {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
                    {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
                    {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
                    {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
                    {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
                    {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
                    {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
                    {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
                    {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
                    {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
                    {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
                    {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
                    {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
                    ///////////////////////////////////////////////////////////
                    {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
                    {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},
                    {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
                    {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
                    {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
                    {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
                    {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
                    {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
                    {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
                    {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
                    {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
                    {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
                    {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
                    {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1}
};
    void Start()
    {
        Debug.Log(levelMap.GetLength(0));//return the row length
        Debug.Log(levelMap.GetLength(1));//return the col length

        for (int row=0; row < levelMap.GetLength(0); row++) {
            for (int col = 0; col < levelMap.GetLength(1); col++) {
                int value = levelMap[row,col];
                switch (value) {
                    case 0:
                        //empty
                        break;
    
                    case 1:
                        Instantiate(outsideCorner, new Vector3(row+2,col+5), Quaternion.identity, gameObject.transform);
                        break;
                    case 2:
                        Instantiate(outsideWall, new Vector3(row + 2, col + 5), Quaternion.identity, gameObject.transform);
                        break;
                    case 3:
                        Instantiate(insideCorner, new Vector3(row + 2, col + 5), Quaternion.identity, gameObject.transform);
                        break;
                    case 4:
                        Instantiate(insideWall, new Vector3(row + 2, col + 5), Quaternion.identity, gameObject.transform);
                        break;
                    case 5:
                        Instantiate(standardPellet, new Vector3(row + 2, col + 5), Quaternion.identity, gameObject.transform);
                        break;
                    case 6:
                        Instantiate(powerPellet, new Vector3(row + 2, col + 5), Quaternion.identity, gameObject.transform);
                        break;
                    case 7:
                        Instantiate(tJunction, new Vector3(row + 2, col + 5), Quaternion.identity, gameObject.transform);
                        break;
                }


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getAround(int x, int y) {
        int up;
        int down;
        int left;
        int right;
        //retutn Quaternion.Euler
    }
}
