using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{

    void Start()
    {
    }

    void OnTriggerEnter(Collider collid)
    {
        if (collid.name == "Player")
            Debug.Log("Got it!");
            Destroy(gameObject);

    }
}
