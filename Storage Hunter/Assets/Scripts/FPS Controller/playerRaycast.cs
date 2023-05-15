using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{

    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    private RaycastHit hit;


    public static bool pickableObject1Retrieved;
    public static bool pickableObject2Retrieved;

    [Header("Pickable Objects")]
    [SerializeField]
    private GameObject pickableObject1;
    [SerializeField]
    private GameObject pickableObject2;

    [Header("Pickup Audio Clip")]
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        if (pickableObject1Retrieved == true)
        {
            Destroy(pickableObject1);
        }

        if (pickableObject2Retrieved == true)
        {
            Destroy(pickableObject2);
        }

    }
    private void Update()
    {
        //Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {


            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);


        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);



            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.name == "PickableObject1")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    Debug.Log("SetActive false PickableObject1");
                    Destroy(hit.transform.gameObject);


                    // setting bool to true after picking up object
                    pickableObject1Retrieved = true;


                    // when destroyed set UI to false
                    pickUpUI.SetActive(false);
                }

                if (hit.transform.name == "PickableObject2")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    Debug.Log("SetActive false PickableObject2");
                    Destroy(hit.transform.gameObject);


                    // setting bool to true after picking up object
                    pickableObject2Retrieved = true;


                    // when destroyed set UI to false
                    pickUpUI.SetActive(false);
                }

                if (hit.transform.name == "PickableObject3")
                {
                    // Play pickup sfx
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Playing pickup sfx");

                    Debug.Log("SetActive false PickableObject2");
                    Destroy(hit.transform.gameObject);


                    // setting bool to true after picking up object
                    pickableObject2Retrieved = true;


                    // when destroyed set UI to false
                    pickUpUI.SetActive(false);
                }

            }
        }




    }
}
