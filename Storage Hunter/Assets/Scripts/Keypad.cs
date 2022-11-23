using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour
{

    [SerializeField] private TMP_Text Ans;
    [SerializeField] private Animator OfficeDoor;


    private string Answer = "123456";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }


    public void Enter()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "ACCESS GRANTED";
            OfficeDoor.SetBool("Open", true);

        }
        else
        {
            Ans.text = "ACCESS DENIED";
        }
    }


    //IEnumerator CloseKeypadUI()
   // {

   //}

}
