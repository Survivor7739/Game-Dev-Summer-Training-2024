using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // 1. Detect collision
    // 2. Identify objects colliding with this
    // 3. Destroy this if the collidiing object is the player
    // 4. Every frame, update the rotation of this to attract the player

    public int pointValue = 1; // A var to store how many points this pickup is worth

    // This funciton is called whenever this collider collides with another marked as a trigger (This object can be the trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // If the collider this pickup just hit has the tag "Player"
        {
            Destroy(this.gameObject); // Destroy this pickup
            GameManager.Instance.totalPickups -= 1; // Tell the GameManager to subtract from the total # of pickups
            GameManager.Instance.UpdateScore(pointValue); // Tell the GameManager to update the score by 1
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        // Time.delta will make something frame independent
    }

}
