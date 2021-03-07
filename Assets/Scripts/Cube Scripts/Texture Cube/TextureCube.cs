using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureCube : MonoBehaviour, IObjectToDraw
{
    private Color myColor;
    private bool changeable = true;
    public bool Changeable { get => changeable; set => changeable = value; }
    public Color MyColor { get => myColor; set => myColor = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CollectableCube>() && changeable == true)
        {
            changeable = false;
            other.GetComponent<BoxCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Renderer>().material.color = MyColor; 
            
            var blockController = other.GetComponent<BlockController>();

            if (blockController)
            {
                blockController.BlockState = BlockState.Collected;
            }
            other.GetComponent<MeshRenderer>().enabled = false;
            //Destroy(other.gameObject);
        }
    }
}
