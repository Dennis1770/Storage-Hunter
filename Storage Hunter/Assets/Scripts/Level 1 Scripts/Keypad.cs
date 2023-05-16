using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Scripted by Aaron Lee
public class Keypad : MonoBehaviour
{

    [SerializeField] private TMP_Text Ans;
    [SerializeField] private Animator OfficeDoor;

    private string Answer = "488265";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }


    public void Enter()
    {
        // If player enters the correct code, change text to ACCESS GRANTED and open door animation begins
        if (Ans.text == Answer)
        {
            Ans.text = "ACCESS GRANTED";
            OfficeDoor.SetBool("Open", true);


        }
        else
        {
            // if player enters the wrong code, change text to ACCESS DENIED and play ResetKeypad Coroutine
            Ans.text = "ACCESS DENIED";
            StartCoroutine(ResetKeypad());
        }
    }


    IEnumerator ResetKeypad()
    {
        // wait 1 second and keypad will reset to blank
        yield return new WaitForSeconds(1);
        Ans.text = "";
    }

}
