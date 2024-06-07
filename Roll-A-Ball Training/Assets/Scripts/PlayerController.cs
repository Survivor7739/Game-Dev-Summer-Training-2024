using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // How to make a C# -----> Accesor datatype varName 
    // PascalCase naming scripts, functions, and data types
    // camelCase naming variables

    public CharacterController controller; // A var to hold the player's char controller component
    public Animator animController; // A var to hold the player's animator controller component
    public float moveSpeed = 5f; // Var to control how fast the player moves
    
    public float rotateSpeed = 5f; // The speed in which the player rotates when moving


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Assign the controller var to the player's char controller component
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gather input from the player
        float horizontalInput = Input.GetAxis("Horizontal"); // A var to store Left & Right input from player
        float verticalInput = Input.GetAxis("Vertical"); // A var to store Forward & Back input from player

        // Calculate the direction the player should based on our collected input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        // Move the player based on the input
        controller.Move(movement * moveSpeed * Time.deltaTime);

        // Vector.3 = (0, 0, 0) --> Player is NOT moving
        if (movement != Vector3.zero)  // If the player is moving...
        {
            animController.SetBool("IsMoving", true); // Tell the anim controller to transition to the run animation
            
            //Rotate the player in the direction they are moving over time
            Quaternion targetRotation = Quaternion.LookRotation(movement); // Storing the rotation needed at this given time

            // Rotate the player based on its current rotation values and the target Rotation value
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        } 
        else // The player is no longer moving
        {
            // Tell the anim controller to transition back to the idle animation
            animController.SetBool("IsMoving", false);
        }

    }
}
