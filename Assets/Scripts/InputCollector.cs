using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InputCollector : MonoBehaviour
{
    public InputField inputField;
    private string _userInput = "";
    private ArrayList _inputList = new ArrayList();




    public TextMeshProUGUI textPrefab;
    public Transform textContainer;
    int i = 0;
    //public string[] inputArray;
    private void Start()
    {
        i = 0;
        // Iterate through the input array
        //for (int i = 0; i < _inputList.Count; i++)
        //{
        //    // Instantiate a new TextMeshPro object
        //    TextMeshProUGUI newText = Instantiate(textPrefab, textContainer);

        //    // Set the text value
        //    newText.text = _inputList[i].ToString();

        //    // Position the new text below the previous one
        //    Vector3 newPosition = newText.transform.localPosition;
        //    newPosition.y = -i * newText.preferredHeight;
        //    newText.transform.localPosition = newPosition;
        //}
    }


    //private void Start()
    //{
    //    // Add a listener to the "End Edit" event of the Input Field
    //    inputField.onEndEdit.AddListener(OnInputEndEdit);
    //}

    //private void OnInputEndEdit(string input)
    //{
    //    Debug.Log("User Input: " + input);
    //    // Clear the input field text
    //    inputField.text = "";
    //    // Optionally, set the focus back to the input field for continued input
    //    inputField.ActivateInputField();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("User Input:- " + _userInput);
            if(_userInput!= "")
            {
                _inputList.Add(_userInput);
                addRecord();
            }
                
            Debug.Log(_inputList.Count);
            _userInput = ""; // Reset the user input after logging
        }
        else
        {
            // Collect the input
            foreach (char c in Input.inputString)
            {
                if (c == '\b') // Backspace
                {
                    if (_userInput.Length > 0)
                        _userInput = _userInput.Substring(0, +_userInput.Length - 1);
                }
                else if (c == '\n' || c == '\r') // Newline or carriage return
                {
                    // Ignore these characters
                }
                else
                {
                    _userInput += c;
                }
            }
        }
    }

    private void addRecord()
    {
        TextMeshProUGUI newText = Instantiate(textPrefab, textContainer);

        // Set the text value
        newText.text = _inputList[i].ToString();

        // Position the new text below the previous one
        Vector3 newPosition = newText.transform.localPosition;
        newPosition.y = -i * newText.preferredHeight;
        newText.transform.localPosition = newPosition;
        i++;
    }
    public void createCanvas()
    {
        GameObject canvasObj = new GameObject("Canvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Create a new EventSystem object (required for UI interaction)
        GameObject eventSystemObj = new GameObject("EventSystem");
        eventSystemObj.AddComponent<UnityEngine.EventSystems.EventSystem>();
        eventSystemObj.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();

        // Create a parent object for the buttons
        GameObject buttonsParent = new GameObject("Buttons");
        buttonsParent.transform.SetParent(canvas.transform);

        // Create a button and add it to the parent
        GameObject buttonObj1 = new GameObject("Button1");
        buttonObj1.transform.SetParent(buttonsParent.transform);
        Button button1 = buttonObj1.AddComponent<Button>();
        button1.onClick.AddListener(OnClickButton1);

        // Create a text component for the button
        Text buttonText1 = buttonObj1.AddComponent<Text>();
        buttonText1.text = "Button 1";
        buttonText1.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // Position the button
        RectTransform buttonRect1 = buttonObj1.GetComponent<RectTransform>();
        buttonRect1.localPosition = new Vector3(-100f, 0f, 0f);
        buttonRect1.sizeDelta = new Vector2(200f, 50f);

        // Create another button and add it to the parent
        GameObject buttonObj2 = new GameObject("Button2");
        buttonObj2.transform.SetParent(buttonsParent.transform);
        Button button2 = buttonObj2.AddComponent<Button>();
        button2.onClick.AddListener(OnClickButton2);

        // Create a text component for the button
        Text buttonText2 = buttonObj2.AddComponent<Text>();
        buttonText2.text = "Button 2";
        buttonText2.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // Position the button
        RectTransform buttonRect2 = buttonObj2.GetComponent<RectTransform>();
        buttonRect2.localPosition = new Vector3(100f, 0f, 0f);
        buttonRect2.sizeDelta = new Vector2(200f, 50f);
    }

    private void OnClickButton1()
    {
        Debug.Log("Button 1 clicked!");
    }

    private void OnClickButton2()
    {
        Debug.Log("Button 2 clicked!");
    }
}
