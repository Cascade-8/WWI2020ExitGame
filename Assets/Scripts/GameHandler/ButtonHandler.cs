using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [Header("Buttons")]
    public Button submitButton;

    private void Start()
    {
        submitButton.onClick.AddListener(SubmitAction);
    }

    private void SubmitAction()
    {
        
    }
}
