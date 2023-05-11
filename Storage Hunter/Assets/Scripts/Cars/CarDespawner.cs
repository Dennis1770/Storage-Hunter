using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class CarDespawner : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
