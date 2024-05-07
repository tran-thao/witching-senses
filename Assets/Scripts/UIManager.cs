using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private bool keyHeld = false;
    public bool IsKeyHeld()
    {
        return keyHeld;
    }

    public void SetKeyHeld(bool held)
    {
        keyHeld = held;
    }
    

}
