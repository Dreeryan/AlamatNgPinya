using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TagManager : MonoBehaviour
{
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
        currentTagged.IsTagged = false;

        currentTagged = newTagged;
        currentTagged.IsTagged = true;

        // If the current tagged is one of the other kids, complete the minigame
        if (currentTagged.CompareTag("Enemy")
            && completionCountdown == null)
        {
            completionCountdown = StartCoroutine(BeginCompletionCountdown());
        }
        else if (currentTagged.CompareTag("Player")
            && completionCountdown != null)
        {
            StopCoroutine(completionCountdown);
            completionCountdown = null;
        }
    }

    void OnComplete()
    {
        onMinigameCompleted.Invoke();
        SceneLoader.Instance.LoadScene("WinScene", true);
        //Time.timeScale = 0.0f;
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
