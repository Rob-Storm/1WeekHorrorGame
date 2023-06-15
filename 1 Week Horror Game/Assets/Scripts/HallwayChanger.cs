using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayChanger : MonoBehaviour
{
    public GameObject[] element;

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
