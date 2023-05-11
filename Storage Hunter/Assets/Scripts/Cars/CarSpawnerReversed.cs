using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class CarSpawnerReversed : MonoBehaviour
{
    public GameObject[] vehicles;
    [SerializeField] private float timeSinceLastSpawn;
    [SerializeField] private float vehicleInterval;

    private void Awake()
    {
        vehicleInterval = 1;
        timeSinceLastSpawn = 6f;
    }

    public void InstantiateVehicle()
    {
        Debug.Log("Instantiate");
        Instantiate(vehicles[Random.Range(0, vehicles.Length)], this.transform.position, Quaternion.Euler(0f, 180f, 0f)); //Spawn the car facing the other direction
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= vehicleInterval)
        {
            timeSinceLastSpawn = 0;
            vehicleInterval = Random.Range(5, 20f);
            InstantiateVehicle();
            //reset the timer
        }
    }
}
