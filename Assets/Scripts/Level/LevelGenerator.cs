using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int[,] levelMap = {
        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 7 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,1 },
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4, 4 ,5 ,3 ,4 ,4 ,4 ,3 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4, 4 ,5 ,4 ,0 ,0 ,0 ,4 ,5 ,4 ,0 ,0 ,4 ,6 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 3 ,5 ,3 ,4 ,4 ,4 ,3 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 4 ,4 ,4 ,3 ,5 ,3 ,3 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 3 ,4 ,4 ,3 ,5 ,4 ,4 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4 ,5 ,5 ,5 ,5 ,4 ,4 ,5 ,5 ,5 ,5 ,5 ,5 ,2 },
        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4, 4 ,0 ,3 ,4 ,4 ,3 ,4 ,5 ,1 ,2 ,2 ,2 ,2 ,1 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3, 3 ,0 ,3 ,4 ,4 ,3 ,4 ,5 ,2 ,0 ,0 ,0 ,0 ,0 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0, 0 ,0 ,0 ,0 ,0 ,4 ,4 ,5 ,2 ,0 ,0 ,0 ,0 ,0 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0, 0 ,4 ,4 ,3 ,0 ,4 ,4 ,5 ,2 ,0 ,0 ,0 ,0 ,0 },
        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0, 0 ,0 ,0 ,4 ,0 ,3 ,3 ,5 ,1 ,2 ,2 ,2 ,2 ,2 },
        { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0, 0 ,0 ,0 ,4 ,0 ,0 ,0 ,5 ,0 ,0 ,0 ,0 ,0 ,0 },
        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0, 0 ,0 ,0 ,4 ,0 ,3 ,3 ,5 ,1 ,2 ,2 ,2 ,2 ,2 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0, 0 ,4 ,4 ,3 ,0 ,4 ,4 ,5 ,2 ,0 ,0 ,0 ,0 ,0 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0, 0 ,0 ,0 ,0 ,0 ,4 ,4 ,5 ,2 ,0 ,0 ,0 ,0 ,0 },
        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3, 3 ,0 ,3 ,4 ,4 ,3 ,4 ,5 ,2 ,0 ,0 ,0 ,0 ,0 },
        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4, 4 ,0 ,3 ,4 ,4 ,3 ,4 ,5 ,1 ,2 ,2 ,2 ,2 ,1 },
        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4, 4 ,5 ,5 ,5 ,5 ,4 ,4 ,5 ,5 ,5 ,5 ,5 ,5 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3, 3 ,4 ,4 ,3 ,5 ,4 ,4 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4, 4 ,4 ,4 ,3 ,5 ,3 ,3 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3, 3 ,5 ,3 ,4 ,4 ,4 ,3 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4, 4 ,5 ,4 ,0 ,0 ,0 ,4 ,5 ,4 ,0 ,0 ,4 ,6 ,2 },
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4, 4 ,5 ,3 ,4 ,4 ,4 ,3 ,5 ,3 ,4 ,4 ,3 ,5 ,2 },
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,5 ,2 },
        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7, 7 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,2 ,1 }
    };

    public GameObject[] tileList;
    public GameObject[,] tiles;

    void Start()
    {
        //Array of Gameobjects rather than just the tilemap
        tiles = new GameObject[levelMap.GetLength(0), levelMap.GetLength(1)];
        GameObject tile;

        string map = "";

        //Generation Pass
        for (int x = 0; x < levelMap.GetLength(0); x++) {
            for (int y = 0; y < levelMap.GetLength(1); y++) {
                switch (levelMap[x, y]) {
                    case 0:
                        break;
                    case 1:
                        //Outside Corner
                        tile = (GameObject)Instantiate(tileList[1], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x, y] = tile;
                        break;
                    case 2:
                        //Outside Wall
                        tile = (GameObject)Instantiate(tileList[0], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x, y] = tile;
                        break;
                    case 3:
                        //Inside Corner
                        tile = (GameObject)Instantiate(tileList[3], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x, y] = tile;
                        //InstantiateCorner(x, y, 3);
                        break;
                    case 4:
                        //Inside Wall
                        tile = (GameObject)Instantiate(tileList[2], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x,y] = tile;
                        //InstantiateWall(x, y, 4);
                        break;
                    case 5:
                        //pellet
                        tile = (GameObject)Instantiate(tileList[5], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x, y] = tile;
                        break;
                    case 6:
                        //Power Pellet
                        tile = (GameObject)Instantiate(tileList[6], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x, y] = tile;
                        break;
                    case 7:
                        //T Junction
                        tile = (GameObject)Instantiate(tileList[4], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x, y] = tile;
                        break;
                }
                map += "{" + levelMap[x, y] + "}, ";
            }
            map += "\n";
        }
        
        //Rotation Pass
        for (int x = 0; x < levelMap.GetLength(0); x++) {
                for(int y = 0; y < levelMap.GetLength(1); y++) {
                    switch (levelMap[x, y]){
                        case 0:
                            break;
                        case 1:
                            //Outside Corner
                            RotateOuterCorner(x, y);
                            //Instantiate(tileList[1], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                            break;
                        case 2:
                            RotateOuterWall(x, y);
                            //InstantiateWall(x, y, 2);
                            //Instantiate(tileList[0], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                            //Outside Wall
                            break;
                        case 3:
                            RotateInnerCorner(x, y);
                            //Instantiate(tileList[3], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                            //Inside Corner
                            break;
                        case 4:
                            RotateInnerWall(x, y);
                            //Instantiate(tileList[2], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                            //InstantiateWall(x, y, 4);
                            //Inside Wall
                            break;
                        case 7:
                            //Instantiate(tileList[2], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                            //T Junction
                            break;
                    }
                }
            }
        //Debug.Log(map);
        //InstantiateCorner(2, 2, 1);
        
    }

    void RotateOuterCorner(int xPos, int yPos) {

        int[,] cornerMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    cornerMap[x, y] = levelMap[xPos + xCount, yPos + yCount];
                }
                catch{
                    cornerMap[x, y] = 0;
                }
                array += "{" + cornerMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;
        }

        Vector3 pos = new Vector3(yPos, -xPos, 0);

        //Bottom and Right
        if (cornerMap[2, 1] == 2 && cornerMap[1, 2] == 2 && cornerMap[1, 0] != 2 && cornerMap[0, 1] != 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //Bottom and Left
        if (cornerMap[2, 1] == 2 && cornerMap[1, 0] == 2 && cornerMap[1, 2] != 2 && cornerMap[0, 1] != 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            //Instantiate(tileList[1], pos, Quaternion.Euler(0f, 0f, -90f));
        }

        //Top and Right
        if (cornerMap[0, 1] == 2 && cornerMap[1, 2] == 2 && cornerMap[1, 0] != 2 && cornerMap[2, 1] != 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            //Instantiate(tileList[1], pos, Quaternion.Euler(0f, 0f, 90f));
        }
        //Top and Left
        if (cornerMap[0, 1] == 2 && cornerMap[1, 0] == 2 && cornerMap[1, 2] != 2 && cornerMap[2, 1] != 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            //Instantiate(tileList[1], pos, Quaternion.Euler(0f, 0f, 180f));
        }
    }

    void RotateInnerCorner(int xPos, int yPos) {
        int[,] cornerMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    cornerMap[x, y] = levelMap[xPos + xCount, yPos + yCount];
                }
                catch {
                    cornerMap[x, y] = 0;
                }
                array += "{" + cornerMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;

        }

        //Corner Above
        if(cornerMap[0,1] == 3 && cornerMap[2,1] != 3) {
            //Wall is Left
            if(cornerMap[1,0] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            }

            //Wall is Right
            if (cornerMap[1, 2] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }

        //Corner Below
        if (cornerMap[2, 1] == 3 && cornerMap[0, 1] != 3) {
            //Wall is Left
            if (cornerMap[1, 0] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            }

            //Wall is Right
            if (cornerMap[1, 2] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }

        //Corner Right
        if (cornerMap[1, 2] == 3 && cornerMap[1, 0] != 3) {
            //Wall is Above
            if (cornerMap[0, 1] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }

            //Wall is Below
            if (cornerMap[2, 1] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }

        //Corner Left
        if (cornerMap[1, 0] == 3 && cornerMap[1, 2] != 3) {
            //Wall is Above
            if (cornerMap[0, 1] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            }

            //Wall is Below
            if (cornerMap[2, 1] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            }
        }
        
        //Bottom and Right
        if (cornerMap[2, 1] == 4 && cornerMap[1, 2] == 4 && cornerMap[1, 0] != 4 && cornerMap[0, 1] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //Bottom and Left
        if (cornerMap[2, 1] == 4 && cornerMap[1, 0] == 4) {
            if(cornerMap[1,2] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            }

        }

        //Top and Right
        if (cornerMap[0, 1] == 4 && cornerMap[1, 2] == 4 ) {
            if(cornerMap[1,0] == 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }

        }
        //Top and Left
        if (cornerMap[0, 1] == 4 && cornerMap[1, 0] == 4 && cornerMap[1, 2] != 4 && cornerMap[2, 1] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        
    }

    void RotateOuterWall(int xPos, int yPos) {
        int[,] wallMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    wallMap[x, y] = levelMap[xPos + xCount, yPos + yCount];
                }
                catch{
                    wallMap[x, y] = 0;
                }
                array += "{" + wallMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;
        }
        /*
        00 01 02
        10 11 12
        20 21 22
        */

        //Probably only works for Outer Walls
        //Wall on Top
        if(wallMap[0,1] == 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //Wall on Bottom
        if (wallMap[2, 1] == 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //Wall on Left
        if (wallMap[1, 0] == 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        //Wall on Right
        if (wallMap[1, 2] == 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

    }

    void RotateInnerWall(int xPos, int yPos) {
        int[,] wallMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    wallMap[x, y] = levelMap[xPos + xCount, yPos + yCount];
                }
                catch{
                    wallMap[x, y] = 0;
                }
                array += "{" + wallMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;
        }

        /*
        00 01 02
        10 11 12
        20 21 22
        */
        //Maybe any time there is a pellet
        //Corner Left or Right
        if (wallMap[1, 0] == 3 || wallMap[1, 2] == 3) {
            //Nothing Below
            if (wallMap[2, 1] != 2) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }

            //Nothing Above
            if (wallMap[0, 1] != 2) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            }
        }
        

        //USING PELLETS FOR CHECK
        //Pellet Left
        if (wallMap[1,0] == 5 || wallMap[1,0] == 6) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //Pellet Right
        if (wallMap[1, 2] == 5 || wallMap[1, 2] == 6) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        //Pellet Top
        if (wallMap[0, 1] == 5 || wallMap[0, 1] == 6) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 990f);
        }

        //Pellet Bellow
        if (wallMap[2, 1] == 5 || wallMap[2, 1] == 6) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        //NO PELLETS AVAIALBLE FOR CHECK
        //Wall Left nothing Front
        if (wallMap[1, 0] == 4 && wallMap[1, 2] == 0) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        //Wall Right nothing Front
        if (wallMap[1, 2] == 4 && wallMap[1, 0] == 0) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //Wall Above nothing below
        if (wallMap[0, 1] == 4 && wallMap[2, 1] == 0) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        //Wall belowing nothing above
        if (wallMap[2, 1] == 4 && wallMap[0, 1] == 0) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        //wall left nothing right above or below
        if (wallMap[1, 0] == 4 && wallMap[1, 2] == 0 && wallMap[0,1] == 0 && wallMap[2,1] ==0) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        //wall right nothing left
        if (wallMap[1, 2] == 4 && wallMap[1, 0] == 0 && wallMap[0, 1] == 0 && wallMap[2, 1] == 0) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
