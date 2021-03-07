using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnObjects
{
    Transform HolderObject { get;}

    int counter { get; set; }

    /// <summary>
    /// Draws a texture according to its pixels by using the specified object.
    /// </summary>
    /// <param name="texture">The texture to print on game screen as pixels by using an object</param>
    /// <param name="objectPrefab">The object to draw a texture to the screen. 
    /// It can be a cube, a triangle, a sphere etc.</param>
    void SpawnObject(LevelInfo levelInfo);
}
