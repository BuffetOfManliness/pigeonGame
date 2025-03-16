using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array of prefabs to instantiate
    private GameObject currentPrefab;
    public float timer = 3f;

    void Start()
    {
        // Set the current prefab to the first one in the array (or any specific one you want)
        if (objectPrefabs.Length > 0)
        {
            currentPrefab = objectPrefabs[0]; // You can change the index to select a different prefab
        }
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            if (currentPrefab != null)
            {
                Instantiate(currentPrefab, transform.position, Quaternion.identity); // Use the parent's position
            }
            yield return new WaitForSeconds(timer);
        }
    }
}