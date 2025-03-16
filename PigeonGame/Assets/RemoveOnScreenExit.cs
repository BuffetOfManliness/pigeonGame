using UnityEngine;

public class RemoveOnScreenExit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the object is outside the camera's view
        if (!IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject); // Destroy this GameObject
        }
    }

    private bool IsVisibleFrom(Camera camera)
    {
        // Get the object's position in screen space
        Vector3 screenPoint = camera.WorldToViewportPoint(transform.position);
        // Check if the object is outside the screen bounds
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}