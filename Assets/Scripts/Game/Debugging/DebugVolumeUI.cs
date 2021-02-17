using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugVolumeUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private KeyCode toggleKey = KeyCode.F2;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey)) panel.SetActive(!panel.activeSelf);
    }
}
