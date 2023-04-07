using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Generator : MonoBehaviour
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

    public GenSwitch1 genSwitch1;
    public GenSwitch2 genSwitch2;
    public GenSwitch3 genSwitch3;
    public GenSwitch4 genSwitch4;
    public GenSwitch5 genSwitch5;
    public GenSwitch6 genSwitch6;


    public GameObject SwitchLight1;
    public GameObject SwitchLight2;
    public GameObject SwitchLight3;
    public GameObject SwitchLight4;
    public GameObject SwitchLight5;
    public GameObject SwitchLight6;

    public GameObject SwitchLightCheck;

    public Material NeonGreen;
    public Material NeonRed;
    public Material Silver;

    public bool SwitchLightsAllOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GeneratorSwitch()
    {
        if (genSwitch1.Switch1On == true)
        {
            Debug.Log("Generator Switch 1: ON");
            SwitchLight1.GetComponent<MeshRenderer>().material = NeonGreen;
        }

        if (genSwitch2.Switch2On == true)
        {
            Debug.Log("Generator Switch 2: ON");
            SwitchLight2.GetComponent<MeshRenderer>().material = NeonGreen;
        }

        if (genSwitch3.Switch3On == true)
        {
            Debug.Log("Generator Switch 3: ON");
            SwitchLight3.GetComponent<MeshRenderer>().material = NeonGreen;
        }

        if (genSwitch4.Switch4On == true)
        {
            Debug.Log("Generator Switch 4: ON");
            SwitchLight4.GetComponent<MeshRenderer>().material = NeonGreen;
        }

        if (genSwitch5.Switch5On == true)
        {
            Debug.Log("Generator Switch 5: ON");
            SwitchLight5.GetComponent<MeshRenderer>().material = NeonGreen;
        }

        if (genSwitch6.Switch6On == true)
        {
            Debug.Log("Generator Switch 6: ON");
            SwitchLight6.GetComponent<MeshRenderer>().material = NeonGreen;
        }
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

            if (Input.GetKeyDown(KeyCode.E) && hit.collider.gameObject.tag == "SwitchStarter") // Checking if player Presses E on Storage Room Handle
            {
                Debug.Log("Switch Starter is being pressed");

                if (genSwitch1.Switch1On == true && 
                    genSwitch2.Switch2On == true &&
                    genSwitch3.Switch3On == true &&
                    genSwitch4.Switch4On == true &&
                    genSwitch5.Switch5On == true &&
                    genSwitch6.Switch6On == true)
                    {
                        SwitchLightsAllOn = true;
                        SwitchLightCheck.GetComponent<MeshRenderer>().material = NeonGreen;
                    }

                if (SwitchLightsAllOn == false)
                    {
                        Debug.Log("SwitchLightsAllOn is false");
                        StartCoroutine(SwitchStarterErrorCoroutine());
                    }
            }

        }
    }

    IEnumerator SwitchStarterErrorCoroutine()
    {
        Debug.Log("Not all switches are on!");
        SwitchLightCheck.GetComponent<MeshRenderer>().material = NeonRed;
        yield return new WaitForSeconds(2f);
        SwitchLightCheck.GetComponent<MeshRenderer>().material = Silver;
    }
}
