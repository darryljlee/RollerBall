using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //import statement to assist in restarting the game

public class ControlBall : MonoBehaviour
{
    public float speed; //create a public variable for the ball speed that can be adjusted in the Unity editor
    private Rigidbody _player; //declare a rigidbody for the ball so that it colliders can be applied
    private int _counter; //declare a private integer variable that keeps track of how many points the player has received
    public Text counterText; //create a public variable counterText of type Text which can be modified in the Unity editor
    public GameObject gameOverObject; //declare a new GameObject variable called gameOverObject, which is referenced when the player collects all the pickups
    
    void Start() // This Start() function is called before the first frame update
    {
     _player = GetComponent<Rigidbody>();
     _counter = 0; //instantiated _counter to 0 when the game starts
     UpdateCounterText(); //function call to UpdateCounterText() 
     gameOverObject.SetActive(false); //Instantiate the gameOverObject to false when the game starts. When the player collects all the pickups, this GameObject will be set to true, and text will appear on screen
    }

  
    void Update()  // This Update() function is called once per frame
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); //declare a float variable that is connected to the "Horizontal" input in the Input Manager
        float verticalMovement = Input.GetAxis("Vertical"); //declare a float variable that is connected to the "Vertical" input in the Input Manager
        _player.AddForce(new Vector3(horizontalMovement, 0, verticalMovement) * speed * Time.deltaTime); // apply a physics force onto the Rigidbody _ player depending on the direction of user input
    }

    void UpdateCounterText()
    {
        counterText.text = "Score: " + _counter.ToString(); //display the counterText on the screen and append the private counter variable as a string 

        if(_counter >= 21) //if condition to check if the score is 21 (all pickup objects are collected)
        {
            gameOverObject.SetActive(true); //display "You Win" text on the screen
            StartCoroutine(Restart()); //make the function call to restart the scene
        }
    }

    //on trigger if player comes in contact with pickup items, but does not cause on trigger

    private void OnTriggerEnter(Collider other) //function to trigger if the player has come in contact with a pickup item
    {
        if (other.gameObject.CompareTag("Pickup1")) //if player collides with a game object with tag "Pickup1"
        {
            other.gameObject.SetActive(false); //set the pickup object to false and destroy the game object
            _counter++; //increment the counter variable by 1
            UpdateCounterText(); //call the UpdateCounterText() function to update the changes on the UI
        }
        else if (other.gameObject.CompareTag("Pickup2")) //if player collides with a game object with tag "Pickup2"
        {
            other.gameObject.SetActive(false); //set pickup2 (the pink cube) to false and destroy the game object
            _counter = _counter+2; //increment the score variable by 2 
            UpdateCounterText(); //call the UpdateCounterText() function to update the changes on the UI
        }
        else if (other.gameObject.CompareTag("Pickup3")) //if the player collides into a gameobject with the tag Pickup3 (the gold capsule)
        {
            other.gameObject.SetActive(false); //set the gold capsule to false
            _counter=_counter+3; //increment the score variable by 3
            UpdateCounterText(); //call the UpdateCounterText() function to update the changes on the UI
        }

    }

    IEnumerator Restart() //responsible for restarting the scene when all the objects are picked up
    {
        yield return new WaitForSeconds(5); //wait for 5 seconds after player has received the last pickup object
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart the scene with pickups in place

    }
  
     
    
  
}
