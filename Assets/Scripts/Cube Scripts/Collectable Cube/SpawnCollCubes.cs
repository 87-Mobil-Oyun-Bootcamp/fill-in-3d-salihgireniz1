using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollCubes : MonoBehaviour, ISpawnObjects
{
    [SerializeField]
    private Transform holderObject;

    public Transform HolderObject => holderObject;

    public List<GameObject> spawnedObjects;

    public int Counter;
    public int counter { get => Counter; set => Counter = value; }

    public void SpawnObject(LevelInfo levelInfo)
    {
        spawnedObjects = new List<GameObject>();
        float xOffSet = levelInfo.baseObj.transform.localScale.x;
        float zOffSet = levelInfo.baseObj.transform.localScale.z;
        float yOffSet = levelInfo.baseObj.transform.localScale.y;
        int width = levelInfo.sprite.width;
        int height = levelInfo.sprite.height;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Color color = levelInfo.sprite.GetPixel(i, j);
                if (color.a == 0)
                    continue;
                counter++;
                Vector3 cubePos = Vector3.zero;
                GameObject currentCube = Instantiate(levelInfo.collObj, cubePos, Quaternion.identity) as GameObject;

                spawnedObjects.Add(currentCube);
            }
        }
        RepositionObjectsInOrder(xOffSet, yOffSet, zOffSet);
    }
    public void RepositionObjectsInOrder(float xOffset, float yOffSet, float zOffset)
    {
        float x = 0;
        float y = 1;
        float z = 0;


        foreach(GameObject go in spawnedObjects)
        {

            if (x != 0 && x % 8 == 0)
            {
                x = 0;
                z++;
            }

            if (z != 0 && z % 8 == 0)
            {
                z = 0;
                y++;
            }

            Vector3 targetPos = new Vector3(x * xOffset, y * yOffSet - yOffSet*.5f, z * zOffset -15f);

            go.transform.position = targetPos;

            go.GetComponent<Renderer>().material.color = Color.yellow;
            go.transform.SetParent(HolderObject);

            x++;
        }

    }
}
