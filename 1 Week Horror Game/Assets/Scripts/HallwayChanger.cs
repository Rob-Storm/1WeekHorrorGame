using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayChanger : MonoBehaviour
{
    [Tooltip("The objects you want to have a chance of spawning (AFFECTS ALL OF THEM)")]
    public GameObject[] element;

    [Tooltip("The fraction chance the object stays (i.e 1/2 would be a %50 chance it remains or 1/3 would be a %33 chance)")]
    public int chance;

    void Start()
    {
        int randomNumber = Random.Range(0, chance);

        if (randomNumber == 0)
        {
            foreach (GameObject obj in element)
            {
                Destroy(obj);
            }
            Debug.Log($"{gameObject.name} is Open");
        }

        else Debug.Log($"{gameObject.name} is Closed");
    }
}
