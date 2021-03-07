using UnityEngine;

public class DrawTextureWithCubes : MonoBehaviour, ISpawnObjects
{
    [SerializeField]
    private Transform holderObject;
    public Transform HolderObject => holderObject;

    public int Counter;
    public int counter { get => Counter; set => Counter = value; }
    public void SpawnObject(LevelInfo levelInfo)
    {
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
                Vector3 cubePos = new Vector3(
                    i * xOffSet - xOffSet * .5f * width,
                    yOffSet * .5f,
                    j * zOffSet);
                GameObject currentCube = Instantiate(levelInfo.baseObj, cubePos, Quaternion.identity) as GameObject;
                currentCube.name = "Cube " + i + "/" + j;
                currentCube.GetComponent<IObjectToDraw>().MyColor = color;
                currentCube.GetComponent<Renderer>().material.color = Color.gray;
                currentCube.transform.SetParent(HolderObject);
            }
        }
    }
}
