using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenDialogue : MonoBehaviour
{

    public GenSwitch1 genSwitch1;
    public GenSwitch2 genSwitch2;
    public GenSwitch3 genSwitch3;
    public GenSwitch4 genSwitch4;
    public GenSwitch5 genSwitch5;
    public GenSwitch6 genSwitch6;

    public Generator generator;

    [SerializeField]
    private GameObject PowerOutUI;

    [SerializeField]
    private GameObject NeedAllUI;

        [SerializeField]
    private GameObject LastOneUI;

        [SerializeField]
    private GameObject ElevatorTimeUI;
    // Start is called before the first frame update

    bool lastOne = false;
    void Start()
    {
        StartCoroutine(PowerOut());
    }

    // Update is called once per frame
    void Update()
    {

        if (genSwitch1.Switch1On == true && 
            genSwitch2.Switch2On == true &&
            genSwitch3.Switch3On == true &&
            genSwitch4.Switch4On == true &&
            genSwitch5.Switch5On == true &&
            genSwitch6.Switch6On == true &&
            !lastOne)
            {

                StartCoroutine(LastOne());
                lastOne = true;
            }
    }

    IEnumerator PowerOut()
    {
        yield return new WaitForSeconds(2);
        PowerOutUI.SetActive(true);
        yield return new WaitForSeconds(3);
        PowerOutUI.SetActive(false);

    }

    public IEnumerator NeedAll()
    {
        NeedAllUI.SetActive(true);
        yield return new WaitForSeconds(3);
        NeedAllUI.SetActive(false);
        
    }
    IEnumerator LastOne()
    {
        LastOneUI.SetActive(true);
        yield return new WaitForSeconds(3);
        LastOneUI.SetActive(false);
        yield return new WaitForSeconds(1);
        ElevatorTimeUI.SetActive(true);
        yield return new WaitForSeconds(3);
        ElevatorTimeUI.SetActive(false);
        
    }
}
