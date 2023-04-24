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
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        Cursor.lockState = CursorLockMode.None; // unlock the cursor
        Cursor.visible = true; // show the cursor to make it easier for the player to select dialogue

        currentStory = new Story(inkJSON.text);
        currentStory.BindExternalFunction("activateObject", (int selectedObject) => ActivateObject(selectedObject));
        currentStory.BindExternalFunction("deactivateObject", (int selectedObject) => DeactivateObject(selectedObject));
        
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

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void ActivateObject(int index)
    {
        //used to activate objects via ink
        activatableObject[index].SetActive(true);
    }

    private void DeactivateObject(int index)
    {
        //used to deactivate objects via ink
        activatableObject[index].SetActive(false);
    }
}
