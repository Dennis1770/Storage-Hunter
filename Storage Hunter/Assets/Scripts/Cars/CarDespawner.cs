using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDespawner : MonoBehaviour
{
    //Michael
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
