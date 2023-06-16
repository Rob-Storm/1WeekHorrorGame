using UnityEngine;

public class RandomSpawns : MonoBehaviour
{
    [Tooltip("An array of transforms that the Object To Spawn    will choose from to teleport to")]
    public Transform[] spawnpoints;

    [Tooltip("The object you want to spawn (MAKE SURE IT IS IN THE SCENE!)")]
    public GameObject objectToSpawn;
    void Start()
    {
        objectToSpawn.transform.position = spawnpoints[Random.Range(0, spawnpoints.Length)].position;
    }
}
