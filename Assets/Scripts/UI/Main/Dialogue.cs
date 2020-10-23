using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string name;

    // Resizes the text area for the dialogue boxes in the inspector
    [TextArea(3, 10)] 
    public string[] sentences;
}
