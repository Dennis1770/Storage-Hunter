using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class fakeMonster : MonoBehaviour
{
    private float timer;
    void Start()
    {
        timer = 0.0f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);

        if (timer >= 2.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
