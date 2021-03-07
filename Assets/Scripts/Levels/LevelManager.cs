using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager Instance => instance;

    public System.Action LevelCompleted;

    [Space]
    [SerializeField]
    LevelInfoAsset levelInfoAsset;


    private static LevelManager instance;

    int currentLevelIndex = 0;

    DrawTextureWithCubes blockSpawner = new DrawTextureWithCubes();
    SpawnCollCubes collSpawner = new SpawnCollCubes();

    List<BlockController> createdBlocks = new List<BlockController>();
    List<BlockController> collectedBlocks = new List<BlockController>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        blockSpawner = GetComponent<DrawTextureWithCubes>();
        collSpawner = GetComponent<SpawnCollCubes>();
    }

    public bool HandleCreateNextLevel()
    {
        if(createdBlocks.Count > 0)
        {
            for (int i = 0; i < createdBlocks.Count; i++)
            {
                Destroy(createdBlocks[i]);
                Destroy(collectedBlocks[i]);
            }
        }

        ++currentLevelIndex;

        if (levelInfoAsset.levelInfos.Count >= currentLevelIndex)
        {
            CreateNextLevel();
            return true;
        }

        return false;
    }

    void CreateNextLevel()
    {
        blockSpawner.SpawnObject(levelInfoAsset.levelInfos[currentLevelIndex - 1]);
        collSpawner.SpawnObject(levelInfoAsset.levelInfos[currentLevelIndex - 1]);
    }

    public void OnBlockCreated(BlockController blockController)
    {
        createdBlocks.Add(blockController);
        Debug.Log("Collected Block Count " + collectedBlocks.Count);
    }

    public void OnBlockCollected(BlockController blockController)
    {
        collectedBlocks.Add(blockController);
        Debug.Log($"{collectedBlocks.Count} / {createdBlocks.Count} <- Collected Block Count");

        if (collectedBlocks.Count == createdBlocks.Count)
        {
            LevelCompleted?.Invoke();
        }
    }
}
