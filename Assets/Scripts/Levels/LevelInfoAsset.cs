using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfoAsset", menuName = "Level/Level Info Asset")]
public class LevelInfoAsset : ScriptableObject
{
    [Space]
    public List<LevelInfo> levelInfos = new List<LevelInfo>();
}

[System.Serializable]
public struct LevelInfo
{
    public Texture2D sprite;
    public float size;
    public GameObject baseObj;
    public GameObject collObj;
}