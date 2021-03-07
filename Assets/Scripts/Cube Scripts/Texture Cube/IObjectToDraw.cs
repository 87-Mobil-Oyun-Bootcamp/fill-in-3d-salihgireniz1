using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectToDraw : IObject
{
    Color MyColor { get; set; }
    bool Changeable { get; set; }
}
