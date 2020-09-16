using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    int[,] levelMap = { 
        { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7 }, 
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4 }, 
        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3 }, 
        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 
        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4 }, 
        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3 }, 
        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4 }, 
        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0 }, 
        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0 }, 
        { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0 },
    };

    public GameObject[] tileList;
    public GameObject[,] tiles;
    //TODO
    // MAYBE REWRITE THOSE SO IT DOES THE GENERATION PASS AND THEN WE DO A ROTATION PASS THAT WAY ITS CLEANER AND THE GENERATION DOESNT BUG OUT

    // Start is called before the first frame update
    void Start()
    {
        //Array of Gameobjects rather than just the tilemap
        tiles = new GameObject[14, 14];
        GameObject tile;

        string map = "";

        //Generation Pass
        for (int x = 0; x < 14; x++) {
            for (int y = 0; y < 14; y++) {
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
                        break;
                    case 6:
                        //Power Pellet
                        break;
                    case 7:
                        //T Junction
                        tile = (GameObject)Instantiate(tileList[2], new Vector3(y, -x, 0), Quaternion.identity, this.transform);
                        tile.name = levelMap[x, y].ToString();
                        tiles[x, y] = tile;
                        break;
                }
                map += "{" + levelMap[x, y] + "}, ";
            }
            map += "\n";
        }
        
        //Rotation Pass
        for (int x = 0; x < 14; x++) {
                for(int y = 0; y < 14; y++) {
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
                        case 5:
                            //pellet
                            break;
                        case 6:
                            //Power Pellet
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
                catch (Exception e) {
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
                catch (Exception e) {
                    cornerMap[x, y] = 0;
                }
                array += "{" + cornerMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;
        }

        int counterPart = 0;
        int tileType = 0;
        //Vector3 pos = new Vector3(yPos, -xPos, 0);

        //Bottom and Right
        if (cornerMap[2, 1] == 4 && cornerMap[1, 2] == 4 && cornerMap[1, 0] != 4 && cornerMap[0, 1] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            //Instantiate(tileList[3], pos, Quaternion.Euler(0f, 0f, 0f));
        }

        //Bottom and Left
        if (cornerMap[2, 1] == 4 && cornerMap[1, 0] == 4 && cornerMap[1, 2] != 4 && cornerMap[0, 1] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            //Instantiate(tileList[3], pos, Quaternion.Euler(0f, 0f, -90f));
        }

        //Top and Right
        if (cornerMap[0, 1] == 4 && cornerMap[1, 2] == 4 && cornerMap[1, 0] != 4 && cornerMap[2, 1] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            //Instantiate(tileList[3], pos, Quaternion.Euler(0f, 0f, 90f));
        }
        //Top and Left
        if (cornerMap[0, 1] == 4 && cornerMap[1, 0] == 4 && cornerMap[1, 2] != 4 && cornerMap[2, 1] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            //Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 180f));
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
                catch (Exception e) {
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
                catch (Exception e) {
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
        //Wall on Top
        if (wallMap[0, 1] == 2) {
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
        /*
        //Sides Are Walls
        if (wallMap[1, 0] == 4 && wallMap[1, 2] == 4 && wallMap[2, 1] != 4 && wallMap[0, 1] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        //Top and Bottom Are Walls
        if (wallMap[0, 1] == 4 && wallMap[2, 1] == 4 && wallMap[1, 0] != 4 && wallMap[1, 2] != 4) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //Side Corners
        if (wallMap[1, 0] == 3 || wallMap[1, 2] == 3) {
            if (wallMap[0, 1] != 4 && wallMap[2, 1] != 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }


        //Top Corners
        if (wallMap[0, 1] == 3 || wallMap[2, 1] == 3) {
            if (wallMap[1, 0] != 4 && wallMap[1, 2] != 4) {
                tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }

        //Left Side is wall and Top and bottom are wall, front is not
        if (wallMap[1, 0] == 4 && wallMap[0, 1] == 4 && wallMap[2, 1] == 4 && wallMap[1, 2] != 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }


        //Right side is wall and top and bottom are wall, front is not
        if (wallMap[1, 2] == 4 && wallMap[0, 1] == 4 && wallMap[2, 1] == 4 && wallMap[1, 0] != 2) {
            tiles[xPos, yPos].transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        */
        /*
        //Top and Right
        if (wallMap[0, 1] == counterPart && wallMap[1, 2] == counterPart && wallMap[1, 0] != counterPart && wallMap[2, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 90f));
        }
        //Top and Left
        if (wallMap[0, 1] == counterPart && wallMap[1, 0] == counterPart && wallMap[1, 2] != counterPart && wallMap[2, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 180f));
        }*/
    }

    //OLD
    void InstantiateOuterCorner(int xPos, int yPos) {
        int[,] cornerMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    cornerMap[x, y] = levelMap[xPos + xCount, yPos + yCount];
                }
                catch (Exception e) {
                    cornerMap[x, y] = 0;
                }
                array += "{" + cornerMap[x, y] + "}, ";
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

        Vector3 pos = new Vector3(yPos, -xPos, 0);

        //Bottom and Right
        if (cornerMap[2, 1] == 2 && cornerMap[1, 2] == 2 && cornerMap[1, 0] != 2 && cornerMap[0, 1] != 2) {
            Instantiate(tileList[1], pos, Quaternion.Euler(0f, 0f, 0f));
        }

        //Bottom and Left
        if (cornerMap[2, 1] == 2 && cornerMap[1, 0] == 2 && cornerMap[1, 2] != 2 && cornerMap[0, 1] != 2) {
            Instantiate(tileList[1], pos, Quaternion.Euler(0f, 0f, -90f));
        }

        //Top and Right
        if (cornerMap[0, 1] == 2 && cornerMap[1, 2] == 2 && cornerMap[1, 0] != 2 && cornerMap[2, 1] != 2) {
            Instantiate(tileList[1], pos, Quaternion.Euler(0f, 0f, 90f));
        }
        //Top and Left
        if (cornerMap[0, 1] == 2 && cornerMap[1, 0] == 2 && cornerMap[1, 2] != 2 && cornerMap[2, 1] != 2) {
            Instantiate(tileList[1], pos, Quaternion.Euler(0f, 0f, 180f));
        }
    }

    void InstantiateCorner(int xPos, int yPos, int type) {
        int[,] cornerMap = new int[3,3];
        int xCount = -1;
        int yCount = -1;

        string array = "";
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    cornerMap[x, y] = levelMap[xPos + xCount, yPos + yCount];
                } catch (Exception e) {
                    cornerMap[x, y] = 0;
                }
                array += "{" + cornerMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;
        }
        



        Debug.Log(array);


        int counterPart = 0;
        int tileType = 0;
        Vector3 pos = new Vector3(yPos, -xPos, 0);

        switch (type){
            case 1:
                counterPart = 2;
                tileType = 1;
                break;
            case 3:
                counterPart = 4;
                tileType = 3;
                break;
        }

        /*
        00 01 02
        10 11 12
        20 21 22
        */
        //Bottom and Right
        if (cornerMap[2, 1] == counterPart && cornerMap[1, 2] == counterPart && cornerMap[1,0] != counterPart && cornerMap[0, 1] != counterPart){
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 0f));
        }

        //Bottom and Left
        if (cornerMap[2, 1] == counterPart && cornerMap[1, 0] == counterPart && cornerMap[1, 2] != counterPart && cornerMap[0, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, -90f));
        }

        //Top and Right
        if (cornerMap[0, 1] == counterPart && cornerMap[1, 2] == counterPart && cornerMap[1, 0] != counterPart && cornerMap[2, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 90f));
        }
        //Top and Left
        if (cornerMap[0, 1] == counterPart && cornerMap[1, 0] == counterPart && cornerMap[1, 2] != counterPart && cornerMap[2, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 180f));
        }
    }

    void InstantiateWall(int xPos, int yPos, int type) {
        int[,] wallMap = new int[3, 3];
        int xCount = -1;
        int yCount = -1;

        string array = "";
        for (int x = 0; x < 3; x++) {

            for (int y = 0; y < 3; y++) {

                try {
                    wallMap[x, y] = levelMap[xPos + xCount, yPos + yCount];
                }
                catch (Exception e) {
                    wallMap[x, y] = 0;
                }
                array += "{" + wallMap[x, y] + "}, ";
                yCount++;
            }
            yCount = -1;
            array += "\n";
            xCount++;
        }

        int counterPart = 0;
        int tileType = 0;
        var cornerType = 0;
        Vector3 pos = new Vector3(yPos, -xPos, 0);

        switch (type) {
            case 2:
                counterPart = 2;
                tileType = 0;
                cornerType = 1;
                break;
            case 4:
                counterPart = 4;
                tileType = 2;
                cornerType = 3;
                break;
        }

        /*
        00 01 02
        10 11 12
        20 21 22
        */
        //Sides Are Walls
        if (wallMap[1, 0] == counterPart && wallMap[1, 2] == counterPart && wallMap[2, 1] != counterPart && wallMap[0, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 90f));
        }

        //Top and Bottom Are Walls
        if (wallMap[0, 1] == counterPart && wallMap[2, 1] == counterPart && wallMap[1, 0] != counterPart && wallMap[1, 2] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 0));
        }

        //Side Corners
        if(wallMap[1,0] == cornerType || wallMap[1,2] == cornerType) {
            if(wallMap[0,1] != counterPart && wallMap[2,1] != counterPart) {
                Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 90f));
            }
        }


        //Top Corners
        if (wallMap[0, 1] == cornerType || wallMap[2, 1] == cornerType) {
            if (wallMap[1, 0] != counterPart && wallMap[1, 2] != counterPart) {
                Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 0f));
            }
        }

        //Left Side is wall and Top and bottom are wall, front is not
        if(wallMap[1,0] == counterPart && wallMap[0,1] == counterPart && wallMap[2,1] == counterPart && wallMap[1,2] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 0f));
        }


        //Right side is wall and top and bottom are wall, front is not
        if (wallMap[1, 2] == counterPart && wallMap[0, 1] == counterPart && wallMap[2, 1] == counterPart && wallMap[1, 0] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 0f));
        }
        /*
        //Top and Right
        if (wallMap[0, 1] == counterPart && wallMap[1, 2] == counterPart && wallMap[1, 0] != counterPart && wallMap[2, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 90f));
        }
        //Top and Left
        if (wallMap[0, 1] == counterPart && wallMap[1, 0] == counterPart && wallMap[1, 2] != counterPart && wallMap[2, 1] != counterPart) {
            Instantiate(tileList[tileType], pos, Quaternion.Euler(0f, 0f, 180f));
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
