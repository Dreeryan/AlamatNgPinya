using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer  spriteRenderer;

    private Vector2         destination;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (spriteRenderer == null || Time.timeScale == 0) return;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject()) return;

        //    SetDestination();

        //    if (destination.x > transform.position.x)
        //    {
        //        transform.rotation = Quaternion.Euler(0, 180, 0);
        //    }

        //    else
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, 0);
        //    }
        //}
    }

    public void FlipSprite(float direction)
    {
        if (spriteRenderer == null || Time.timeScale == 0) return;

        if (direction < 0)      transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (direction > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        else return;
    }

    void SetDestination()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
