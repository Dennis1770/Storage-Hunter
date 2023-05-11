using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class GrassBarrier : MonoBehaviour
{
    [SerializeField][Tooltip("The speed the player will move at if they walk through this obstacle")] private float grassSpeed = 3f;
    [SerializeField][Tooltip("The amount of speed added to the player while moving through this obstacle")] private float grassSprint = 2f;

    private playerMovement movement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movement = FindObjectOfType<playerMovement>();
            movement.speed = grassSpeed;
            movement.sprint = grassSprint;
        }
        else return;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movement = FindObjectOfType<playerMovement>();
            movement.speed = movement.resetSpeed;
            movement.sprint = movement.resetSprint;
        }
        else return;
    }
}
