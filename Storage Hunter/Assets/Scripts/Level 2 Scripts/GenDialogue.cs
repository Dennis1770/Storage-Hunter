using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scripted by Aaron Lee
public class GenDialogue : MonoBehaviour
{
    [Header("Generator and Switches")]
    public GenSwitch1 genSwitch1;
    public GenSwitch2 genSwitch2;
    public GenSwitch3 genSwitch3;
    public GenSwitch4 genSwitch4;
    public GenSwitch5 genSwitch5;
    public GenSwitch6 genSwitch6;
    public Generator generator;
    bool lastOne = false;

    [Header("Generator Dialogue")]
    [SerializeField] private GameObject PowerOutUI;
    [SerializeField] private GameObject NeedAllUI;
    [SerializeField] private GameObject LastOneUI;
    [SerializeField] private GameObject ElevatorTimeUI;

    [Header("Objective Dialogue")]
    [SerializeField] private GameObject flipallSwitchesObjectiveUI;
    [SerializeField] private GameObject startGeneratorObjectiveUI;
    [SerializeField] private GameObject returnToElevatorObjectiveUI;

    void Start()
    {
        StartCoroutine(PowerOut());
        flipallSwitchesObjectiveUI.SetActive(true);

    }

    void Update()
    {
        // if all switches are on, run code below
        if (genSwitch1.Switch1On == true && 
            genSwitch2.Switch2On == true &&
            genSwitch3.Switch3On == true &&
            genSwitch4.Switch4On == true &&
            genSwitch5.Switch5On == true &&
            genSwitch6.Switch6On == true &&
            !lastOne)
            {
                StartCoroutine(LastOne());
                StartGeneratorObjective();
                lastOne = true;
            }
    }

    IEnumerator PowerOut()
    { 
        //Turning On/Off UI after a few seconds
        yield return new WaitForSeconds(2);
        PowerOutUI.SetActive(true);
        yield return new WaitForSeconds(3);
        PowerOutUI.SetActive(false);

    }

    public IEnumerator NeedAll()
    {
        //Turning On/Off UI after a few seconds
        NeedAllUI.SetActive(true);
        yield return new WaitForSeconds(3);
        NeedAllUI.SetActive(false);
        
    }
    IEnumerator LastOne()
    {
        //Turning On/Off UI after a few seconds
        LastOneUI.SetActive(true);
        yield return new WaitForSeconds(3);
        LastOneUI.SetActive(false);
        yield return new WaitForSeconds(1);
        ElevatorTimeUI.SetActive(true);
        yield return new WaitForSeconds(3);
        ElevatorTimeUI.SetActive(false);
        
    }

    private void StartGeneratorObjective()
    {
        //Change Objective after player completes previous one
        flipallSwitchesObjectiveUI.SetActive(false);
        startGeneratorObjectiveUI.SetActive(true);
    }

    public void ReturnToElevatorObjective()
    {
        //Change Objective after player completes previous one
        startGeneratorObjectiveUI.SetActive(false);
        returnToElevatorObjectiveUI.SetActive(true);
    }

}
