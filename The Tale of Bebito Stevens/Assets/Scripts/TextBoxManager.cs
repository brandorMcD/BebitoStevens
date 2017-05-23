using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject TextBox;

    public Text theText;


    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public bool isActive;
    public bool stopPlayerMovement;
    public bool opentextbox;
    public charactermovement playermovement;




    // Use this for initialization
    void Start () {
        playermovement = FindObjectOfType<charactermovement>();


        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive == true)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        if (isActive == false)
        {
            return;
        }

        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(opentextbox == true)
            {
                //Debug.Log("Test");
                opentextbox = false;
                return;
            }
            Debug.Log(currentLine); 
            currentLine += 1;
        }

        if (currentLine > endAtLine)
        {
            currentLine = 0;    
            DisableTextBox();
        }
	}

    public void EnableTextBox()
    {
        Debug.Log("Text Box Open");
        TextBox.SetActive(true);
        isActive = true;
        TextBox.GetComponent<Image>().color = new Color(1f, 1f, 1f, .85f);
        // if (stopPlayerMovement == true)
        // {
        playermovement.canMove = false;
        //}
    }
    public void DisableTextBox()
    {
        TextBox.SetActive(false);
        isActive = false;
        playermovement.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }

    }

    public void ChangePortait(Image portaits,string PortaitName)
    {
        Debug.Log(PortaitName);
        portaits.sprite = Resources.Load<Sprite>("Sprites/Sprite Portaits/" + PortaitName);
    }
}
