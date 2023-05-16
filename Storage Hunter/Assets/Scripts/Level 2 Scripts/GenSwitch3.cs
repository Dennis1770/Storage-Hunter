using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scripted by Aaron Lee
public class GenSwitch3 : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    [Min(1)]
    private float hitRange = 5;

    private RaycastHit hit;

    public playerMovement playerMovement;
    public sight Sight;

    private Animator GenSwitchAnim;

    public bool Switch3On = false;

    public Material NeonYellow;
    public GameObject Lightning3;

    public Generator generator;
    void Start()
    {
        GenSwitchAnim = GetComponent<Animator>();
    }


    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
        }

        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.tag == "Switch3") // Checking if player Presses E on Storage Room Handle
            {
                Switch3On = true;
                // turn Lightning mesh NeonYellow material
                Debug.Log("Switch3 is On");
                GenSwitchAnim.SetTrigger("SwitchedOn");
                Lightning3.GetComponent<MeshRenderer>().material = NeonYellow;
                GenSwitchAnim.SetTrigger("SwitchedOff");

                generator.GeneratorSwitch();
            }

        }

    }
}