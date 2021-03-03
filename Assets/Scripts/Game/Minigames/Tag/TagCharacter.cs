using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TagCharacter : MonoBehaviour
{
    public class OnTagged : UnityEvent<TagCharacter> { }
    public OnTagged             tagged              = new OnTagged();

    public bool                 IsTagged            = false;

    private SpriteRenderer      sRenderer;
    private TagCharacter        previousTagged      = null;

    protected bool              isMinigameCompleted = false;

    [SerializeField]public bool CanBeTagged { get; protected set; } = true;

  [SerializeField]protected float TagCooldownAmount = 2;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        DebugUpdateColor();

        TagManager manager = FindObjectOfType<TagManager>();
        if (manager != null) manager.OnMinigameCompleted.AddListener(OnMinigameCompleted);
    }

    public void DebugUpdateColor()
    {
        if (sRenderer != null)
        {
            if (IsTagged) sRenderer.color = Color.black;
            else sRenderer.color = Color.white;
        }
    }

    // Assign the target as the new tagged
    protected virtual void TagTarget(TagCharacter target)
    {
        target.GetTagged(this);
        DebugUpdateColor();
    }

    protected virtual void GetTagged(TagCharacter collider)
    {
        // Assign the collided object's previous tagged object to avoid backtagging
        previousTagged = collider;
        tagged.Invoke(this);
        DebugUpdateColor();
    }

    protected virtual void OnMinigameCompleted()
    {
        isMinigameCompleted = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TagCharacter collided = collision.GetComponent<TagCharacter>();
        // If tagging
        if (collided != null && IsTagged)
        {
            /* 
             *  If colliding object is equal to the previous tagger return
             *  Avoids backtagging, sets to null in CollisionExit
             */
            if (collided == previousTagged) return;
            if (!collided.GetComponent<TagCharacter>().CanBeTagged) return;
            TagTarget(collided);
            StartCoroutine(TagCooldown());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TagCharacter collided = collision.GetComponent<TagCharacter>();
        if (collided != null && collided == previousTagged)
            previousTagged = null;
    }
    
    IEnumerator TagCooldown()
    {
        CanBeTagged = false;
        yield return new WaitForSeconds(TagCooldownAmount);
        CanBeTagged = true;
    }
}
