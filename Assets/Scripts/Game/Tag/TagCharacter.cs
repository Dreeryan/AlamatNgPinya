using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TagCharacter : MonoBehaviour
{
    public class OnTagged : UnityEvent<TagCharacter> { }
    public OnTagged onTagged = new OnTagged();

    private bool    isTagged = false;
    public bool     IsTagged
    {
        get { return isTagged; }
        set { isTagged = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HasBeenTagged()
    {
        onTagged.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagCharacter collided = collision.collider.GetComponent<TagCharacter>();
        if (collided != null && collided.IsTagged) HasBeenTagged();
    }
}
