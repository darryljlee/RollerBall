using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour //this script is applied onto the pickup object prefabs so that they can idly rotate on the stage
{
        
    void Update() // This Update function is called once per frame and is responsible for constantly rotating the pickup objects
    {
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime); //use the transform.Rotate function to specify at which degree the object should rotate at
    }
}
