using UnityEngine;
public class PlayerAnimations : MonoBehaviour
{
    private const string CONST_PLAYERWALK = "isMoving";

    private Animator    anim;

    private bool        willPlay;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 1.0f;
    }


    private void Update()
    {
        if (GameManager.Instance.IsPaused) anim.speed = 0f;
        else anim.speed = 1f;
        
    }

    public void PlayerWalking(bool state)
    {
        if (anim == null) return;
        anim.SetBool(CONST_PLAYERWALK, state);
    }

    public void DisableAnimation()
    {
        anim.speed = 0.0f;
    }
}
