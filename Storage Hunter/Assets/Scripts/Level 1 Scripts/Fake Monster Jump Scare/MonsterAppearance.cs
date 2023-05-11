using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class MonsterAppearance : MonoBehaviour
{
    [Tooltip("This 'fake' monster will walk around to scare the player")][SerializeField] private GameObject fakeMonster;
    [SerializeField] private Transform spawnLocation;
    [Tooltip("Use this to change the direction the fake monster is facing when it spawns")][SerializeField] private float rotation;

    private bool isSpawned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isSpawned == false)
        {
            isSpawned = true;
            Instantiate(fakeMonster, spawnLocation.transform.position, Quaternion.Euler(0.0f, rotation, 0.0f));
        }
    }
}
