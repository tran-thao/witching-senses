using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInstruction : MonoBehaviour
{
    public GameObject instructionPanel;

    public void CloseInstructionPanel()
    {
        instructionPanel.SetActive(false); // Deactivate the panel
    }
}