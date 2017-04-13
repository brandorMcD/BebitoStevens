﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {
    public TextAsset TheText;

    public int StartLine;
    public int EndLine;

    public TextBoxManager TextManager;

    public bool DestroyWhenActivated;
    bool startbox;
    public bool RequireButtonPress;
    private bool WaitForPress;

	// Use this for initialization
	void Start () {
        TextManager = FindObjectOfType<TextBoxManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (WaitForPress && Input.GetKeyDown(KeyCode.E))
        {
                TextManager.ReloadScript(TheText);
                TextManager.currentLine = StartLine;
                TextManager.endAtLine = EndLine;
                TextManager.opentextbox = true;
                TextManager.EnableTextBox();
                WaitForPress = false;




            if (DestroyWhenActivated == true)
            {
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (RequireButtonPress == true)
        {
            WaitForPress = true;
            return;
        }
        if (other.tag == "Player")
        {
            TextManager.ReloadScript(TheText);
            TextManager.currentLine = StartLine;
            TextManager.endAtLine = EndLine;
            TextManager.EnableTextBox();
        }

        if (DestroyWhenActivated == true)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            WaitForPress = false;
        }
    }
}
