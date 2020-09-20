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
        //checkAround(2, 2, 3);

        for (int row=0; row < levelMap.GetLength(0); row++) {
            for (int col = 0; col < levelMap.GetLength(1); col++) {
                int value = levelMap[row,col];
                //Debug.Log(levelMap[row, col]);
                switch (value) {
                    case 0:
                        //empty
                        break;
    
                    case 1:
                        //Instantiate(outsideCorner, new Vector3(col+5, row + 2), Quaternion.identity, gameObject.transform);
                        Instantiate(outsideCorner, new Vector3(col, -row+14), checkAround(row, col, 1), gameObject.transform);
                        break;
                    case 2:
                        //Instantiate(outsideWall, new Vector3(col + 5, row + 2), Quaternion.identity, gameObject.transform);
                        Instantiate(outsideWall, new Vector3(col, -row+14), checkAround(row, col, 2), gameObject.transform);
                        break;
                    case 3:
                        Instantiate(insideCorner, new Vector3(col, -row+14), checkAround(row, col, 3), gameObject.transform);
                        break;
                    case 4:
                        Instantiate(insideWall, new Vector3(col, -row+14), checkAround(row, col, 4), gameObject.transform);
                        break;
                    case 5:
                        Instantiate(standardPellet, new Vector3(col, -row+14), Quaternion.identity, gameObject.transform);
                        break;
                    case 6:
                        Instantiate(powerPellet, new Vector3(col, -row+14), Quaternion.identity, gameObject.transform);
                        break;
                    case 7:
                        Instantiate(tJunction, new Vector3(col, -row+14), checkAround(row, col, 7), gameObject.transform);
                        break;
                }


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Quaternion checkAround(int x, int y, int val) {
        int up;
        int down;
        int left;
        int right;
        //set where is up
        if (x == 0)
        {
            up = 0;
        }
        else {
            up = levelMap[x - 1, y];
        }
        //set where is down
        if (x == levelMap.GetLength(0) - 1)
        {
            down = 0;
        }
        else {
            down = levelMap[x + 1, y];
        }
        //set where is left
        if (y == 0)
        {
            left = 0;
        }
        else {
            left = levelMap[x, y - 1];
        }
        //set where is right
        if (y == levelMap.GetLength(1) - 1)
        {
            right = 0;
        }
        else {
            right = levelMap[x, y + 1];
        }

        ////////////////////
        if (x == 0) {
            if (val == 1 && left == 2 && right == 0)
            {
                return Quaternion.Euler(0, 0, 270);
            }
            else if (val == 2) {
                if (left == 0 || left == 5 || left == 6 || right == 0 || right == 5 || right == 6) {
                    return Quaternion.identity;
                }
                else
                    return Quaternion.Euler(0, 0, 90);
            }
        }
        ///////////////////////
        else if (x == levelMap.GetLength(0) - 1) {
            if (val == 1)
            {
                if (left == 0 && right == 2)
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                else if (left == 2 && right == 0)
                {
                    return Quaternion.Euler(0, 0, 180);
                }
            }
            else if (val == 2) {
                return Quaternion.Euler(0, 0, 90);
            }
            else if (val == 7) {
                return Quaternion.Euler(0, 0, 180);
            }
        }
        /////////////////////
        else if (y == 0) {
            if (val == 1)
            {
                if (up == 2 || up == 7)
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                else if (down == 2 || down == 7) {
                    return Quaternion.identity;
                }
            }
            else if (val == 2) {
                if (up == 0 || up == 5 || up == 6 || down == 0 || down == 5 || down == 6)
                {
                    return Quaternion.Euler(0, 0, 90);
                }
            }
            else if (val == 7)
                return Quaternion.Euler(0, 0, 270);
        }
        ///////////////
        else if (y == levelMap.GetLength(1) - 1) {
            if (val == 1)
            {
                if (up == 2 || up == 1 || up == 3 || up == 4 || up == 7)
                {
                    return Quaternion.Euler(0, 0, 180);
                }
                else if (down == 2 || down == 1 || down == 3 || down == 4 || down == 7)
                {
                    return Quaternion.Euler(0, 0, 270);
                }
            }
            else if (val == 2)
            {
                if (up == 0 || up == 5 || up == 6 || down == 0 || down == 5 || down == 6)
                    return Quaternion.Euler(0, 0, 90);
            }
            else if (val == 7)
            {
                return Quaternion.Euler(0, 0, 270);
            }
        }
        else
        {
            if (val == 1 || val == 3)
            {

                if ((up != 5 || up != 6 || up != 0) && (right != 5 || right != 6 || right != 0) && (left == 5 || left == 6 || left == 0) && (down == 5 || down == 6 || down == 0))
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                else if ((up != 5 || up != 6 || up != 0) && (left != 5 || left != 6 || left != 0) && (down == 5 || down == 6 || down == 0) && (right == 5 || right == 6 || right == 0))
                {
                    return Quaternion.Euler(0, 0, 180);
                }
                else if ((down != 5 || down != 6 || down != 0) && (left != 5 || left != 6 || left != 0) && (up == 5 || up == 6 || up == 0) && (right == 5 || right == 6 || right == 0))
                {
                    return Quaternion.Euler(0, 0, 270);
                }
                else if ((down != 5 || down != 6 || down != 0) && (right != 5 || right != 6 || right != 0) && (up == 5 || up == 6 || up == 0) && (left == 5 || left == 6 || left == 0))
                {
                    return Quaternion.identity;
                }
                else if (up == 4 && right == 4 && left == 4 && down == 3)
                {
                    if (levelMap[x, y - 2] == 0 || levelMap[x, y - 2] == 5 || levelMap[x, y - 2] == 6)
                        return Quaternion.Euler(0, 0, 90);
                    else
                        return Quaternion.Euler(0, 0, 180);
                    //return Quaternion.Euler(0, 0, 180);
                }
                else if (up == 3 && right == 4 && left == 4 && down == 4)
                {
                    if (levelMap[x, y + 2] == 0 || levelMap[x, y + 2] == 5 || levelMap[x, y + 2] == 6)
                        return Quaternion.Euler(0, 0, 270);
                    else
                        return Quaternion.identity;
                }
                else if (up == 4 && right == 3 && left == 4 && down == 4)
                {
                    if (levelMap[x + 2, y] == 0 || levelMap[x + 2, y] == 5 || levelMap[x + 2, y] == 6)
                        return Quaternion.Euler(0, 0, 180);
                    return Quaternion.Euler(0, 0, 270);
                }
                else if (up == 4 && right == 4 && left == 3 && down == 4)
                {
                    if (levelMap[x - 2, y] == 0 || levelMap[x - 2, y] == 5 || levelMap[x - 2, y] == 6)
                        return Quaternion.identity;
                    else
                        return Quaternion.Euler(0, 0, 90);
                }
            }
            //////////////////
            else if (val == 2 || val == 4) {
                if ((up == 5 && down == 0) || (up == 0 && down == 5))
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                else if ((right != 0 && right != 0) && (up == 0 || down == 0))
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                else if (left != 6 && left != 5 && left != 0 && right != 6 && right != 5 && right != 0)
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                else if (up == 0 && down == 0 && (left == 0 || right == 0)) {
                    return Quaternion.Euler(0, 0, 90);
                }
            }
            ///////////////////
            else if (val==7) {
                if (up != 6 && up != 5 && right != 6 && right != 5 && down != 6 && down != 5)
                {
                    return Quaternion.Euler(0, 0, 90);
                }
                else if (right != 6 && right != 5 && right != 6 && right != 5 && up != 6 && up != 5)
                {
                    return Quaternion.Euler(0, 0, 180);
                }
                else if (up != 6 && up != 5 && down != 6 && down != 5 && left != 6 && left != 5)
                {
                    return Quaternion.Euler(0, 0, 270);
                }
                else {
                    return Quaternion.identity;
                }
            }

        }




        //Debug.Log(up);
        //Debug.Log(left);
        //Debug.Log(down);
        //Debug.Log(right);
        return Quaternion.identity;
    }
}
