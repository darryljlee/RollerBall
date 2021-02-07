using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePickup : MonoBehaviour
{
    public GameObject blueCylinderPickup; //declare a public GameObject for the blue cylinder pickup object
    public GameObject pinkCubePickup; //declare a public GameObject for the pink cube pickup object
    public GameObject goldCapsulePickup; //declare a public GameObject for the gold capsule pickup object

    // Start is called before the first frame update
    void Start()
    {
              
        for (int i = 0; i < 3; i++) //declare a for loop that will iterate three times, where local variable "i" will increment by one each iteration
        {
         Instantiate(blueCylinderPickup, new Vector3(-19.0f, 1.70f, -11.0f + 11*i), Quaternion.identity); //Instantiate a new blue cylinder pickup into the game. For each for loop iteration, place a new cylinder on a different z-coordinate
         Instantiate(blueCylinderPickup, new Vector3(21.0f, 1.70f, -9.0f + 11 * i), Quaternion.identity); //Instantiate another row of blue cylinders on a different x-coordinate.
         Instantiate(pinkCubePickup, new Vector3(-14.0f +13*i, 1.70f, -11.0f), Quaternion.identity); //Instantiate a new pink cube pickup into the game. For each for loop iteration, instantiate a new cube on a different x-coordinate
         Instantiate(goldCapsulePickup, new Vector3(-17.0f + 13*i, 1.70f, 11.5f), Quaternion.identity); //Instantiate a new gold capsule pickup into the game. For each for loop iteration, instantiate a new capsule on a different x-coordinate
        }
     }
}
