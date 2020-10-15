using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)] // Resizes the text area for the dialogue boxes in the inspector
    public string[] sentences;
}
