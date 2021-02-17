using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToLastPosition : MonoBehaviour
{
    [SerializeField] private Vector2 defaultPlayerPosition;
    [SerializeField] private GameObject player;

    private Vector2 lastPosition;

    void Start()
    {
        if (GameManager.Instance.IsNewGame)
        {
            player.transform.position = new Vector3(defaultPlayerPosition.x, defaultPlayerPosition.y, 0);
            GameManager.Instance.IsNewGame = false;
        }
        else
        {
            lastPosition = SaveManager.LoadData<Vector2>("lastPosition");
            player.transform.position = new Vector3(lastPosition.x, lastPosition.y, 0);
        }
    }

    public void SavePosition()
    {
        SaveManager.SaveData(new Vector2(player.transform.position.x, player.transform.position.y), "lastPosition");
    }
}
