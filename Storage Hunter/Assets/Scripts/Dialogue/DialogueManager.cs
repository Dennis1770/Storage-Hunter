using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")] [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;

    private static DialogueManager instance;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    public GameObject[] activatableObject;

    //private int selectedObject;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There should only be one Dialogue Manager in the scene");
        }

        instance = this;
    }

    private void Start()
    {

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        //if there aren't any choices available, continue story when the player left clicks
        if(currentStory.currentChoices.Count <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ContinueStory();
            }
        }
/*
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }
*/
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        if(Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None; // unlock the cursor
            Cursor.visible = true; // show the cursor to make it easier for the player to select dialogue
        }

        currentStory = new Story(inkJSON.text);
        currentStory.BindExternalFunction("activateObject", (int selectedObject) => ActivateObject(selectedObject));
        currentStory.BindExternalFunction("deactivateObject", (int selectedObject) => DeactivateObject(selectedObject));
        /*
        Story.BindExternalFunction("ActivateObject")=>
        {
            ActivateObject();
            return null;
        }
        */
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = ""; // reset dialogue text

/*
        //lock the cursor at the end of the story
        if (Cursor.lockState != CursorLockMode.Locked)
        {
        Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = false; // hide the cursor again
*/
    }
    
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue(); //set text for the current dialogue line
            DisplayChoices(); //display choices for this dialogue line
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("There are currently " + currentChoices.Count + " choices. The UI can only support " + choices.Length + " choices");
        }

        int index = 0;
        //enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        //hide any remaining choices the UI can't support
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //StartCoroutine(SelectFirstChoice());
    }

/*
    private IEnumerator SelectFirstChoice()
    {
        //Event system requires we clear it first, then wait for atleast one frame before we set the current selected object
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
*/

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

/*
    private void SetGameObjectActive(bool isActive)
    {
        activatableObject[selectedObject].SetActive(isActive);
    }
*/

    private void ActivateObject(int index)
    {
        //selectedObject = index;
        //SetGameObjectActive(true);

        activatableObject[index].SetActive(true);
    }

    private void DeactivateObject(int index)
    {
        //selectedObject = index;
        //SetGameObjectActive(false);
        
        activatableObject[index].SetActive(false);
    }
}
