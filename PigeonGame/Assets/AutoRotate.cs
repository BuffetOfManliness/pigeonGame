using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation in degrees per second
    private Rigidbody2D rb; // Rigidbody2D reference

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the child object named "Bat" and get its Rigidbody2D component
        Transform batTransform = transform.Find("Bat");
        if (batTransform != null)
        {
            rb = batTransform.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component from the child
            Debug.Log("Rigidbody2D found and assigned."); // Log confirmation
        }
        else
        {
            Debug.LogError("Bat child object not found!"); // Log error if not found
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            // Set the angular velocity to achieve constant rotation
            rb.angularVelocity = rotationSpeed; // Set angular velocity in degrees per second
            Debug.Log("Setting angular velocity: " + rotationSpeed); // Log the angular velocity being set
        }
        else
        {
            Debug.LogError("Rigidbody2D is not assigned!"); // Log error if Rigidbody2D is not assigned
        }
    }
}
