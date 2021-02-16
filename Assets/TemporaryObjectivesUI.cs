using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TemporaryObjectivesUI : MonoBehaviour
{
    public Text textGameObject;
    public TextMesh textmeshpro;    
    // Start is called before the first frame update
    void Start()
    {
      
        UpdateText();
        TaskListManager.Instance.onTaskRemoved.AddListener(UpdateText);
       // textGameObject = GetComponent<TextMesh>();

    }

    void UpdateText()
    {
        Debug.Log("update text");
        Debug.Log(textGameObject);
        textGameObject.text= "You have" + TaskListManager.Instance.taskList.Count.ToString() + " tasks";
    }
}
