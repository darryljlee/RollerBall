using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour //class is responsible to help the camera follow the player around the stage 
{
    public GameObject player; //declare a public Gameobject variable so that the camera know which GameObject to track 
    private Vector3 _offset; //declare a private vector which will determine the a fixed distance between the player and the camera

   
    void Start() // This Start function will be called before the first frame update
    {
        _offset = transform.position - player.transform.position; //On start, calculate the _offset vector (the fixed distance) between the camera and the player
    }

    void Update()// This Update function will be called once per frame
    {
        transform.position = player.transform.position + _offset; //change the position of the camera to match the player's transformed position, whilst maintaining a constant _offset vector from the player.
    }
}
