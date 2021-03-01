using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TagManager : MonoBehaviour
{
    public UnityEvent OnTagChanged = new UnityEvent();
    [SerializeField] private UnityEvent onPlayerTagging;
    [SerializeField] private UnityEvent onPlayerTagged;
    [SerializeField] private UnityEvent onEnemyTag;
    private UnityEvent  onMinigameCompleted = new UnityEvent();
    public UnityEvent   OnMinigameCompleted => onMinigameCompleted;

    [Header("Kids")]
    [SerializeField] private TagCharacter[] kids;
    [SerializeField] private TagCharacter   startingTagged;

    [Header("Settings")]
    [SerializeField] private float maxTime = 5.0f;

    private float curTime = 0;

    [Header("Debug")]
    public float debugTimerDisplay;

    private TagCharacter    currentTagged;
    private Coroutine       completionCountdown = null;

    public float MaxTime => maxTime;
    public float CurTime => curTime;

    void Start()
    {
        curTime = maxTime;
        // Adds listener for when a kid gets tagged
        foreach (TagCharacter kid in kids)
        {
            kid.tagged.AddListener(OnCurrentTaggedChange);
            kid.DebugUpdateColor();
        }

        currentTagged = startingTagged;
        currentTagged.IsTagged = true;
        currentTagged.DebugUpdateColor();
    }

    // Changes the current tagged kid
    void OnCurrentTaggedChange(TagCharacter newTagged) 
    {
        ProcessTag(newTagged);

        // If the current tagged is one of the other kids, complete the minigame
        if (currentTagged.CompareTag("Enemy")
            && completionCountdown == null)
        {
            completionCountdown = StartCoroutine(BeginCompletionCountdown());
        }
        if (currentTagged.CompareTag("Player")
            && completionCountdown != null)
        {
            StopCoroutine(completionCountdown);
            completionCountdown = null;
        }
        OnTagChanged.Invoke();
    }

    void ProcessTag(TagCharacter newTagged)
    {
        // Checks if the player is involved in the tag event
        if (currentTagged.CompareTag("Player") || newTagged.CompareTag("Player"))
        {
            // If the player is the one tagging
            if (currentTagged.CompareTag("Player")) 
                onPlayerTagging?.Invoke();
            // If the player is the one getting tagged
            else onPlayerTagged?.Invoke();
        }
        // If the player is not involved in the tag event
        else
        {
            onEnemyTag?.Invoke();
        }

        // Reassign tag state
        currentTagged.IsTagged = false;
        currentTagged = newTagged;
        currentTagged.IsTagged = true;
    }

    void OnComplete()
    {
        onMinigameCompleted.Invoke();
        WinCheck.Instance.IncreaseProgress();
        //Time.timeScale = 0.0f;
    }

    public List<TagCharacter> GetNonTagged()
    {
        List<TagCharacter> NonTagged = new List<TagCharacter>();
        foreach (TagCharacter kid in kids)
        {
            if (!kid.IsTagged)
            {
                NonTagged.Add(kid);
            }
        }
        return NonTagged;
    }

    public Transform GetTaggedTransform()
    {

        foreach (TagCharacter kid in kids)
        {
            if (kid.IsTagged)
            {
                Transform taggedKid = kid.transform;
                return taggedKid;
            }
        }
        return null;
 
    }

    IEnumerator BeginCompletionCountdown()
    {
        curTime = maxTime;

        debugTimerDisplay = curTime;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            curTime = Mathf.Clamp(curTime, 0, maxTime);

            debugTimerDisplay = curTime;
            yield return null;
        }
        yield return null;
        OnComplete();
    }
}
