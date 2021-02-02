using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLoadAudio : MonoBehaviour
{
    [SerializeField] private AudioManager managerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (AudioManager.Instance == null) Instantiate(managerPrefab);
    }
}
