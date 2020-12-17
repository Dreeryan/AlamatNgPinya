using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTag : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] private float moveSpeed;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI playerItText;
    [SerializeField] private float secondsToWin;
    [SerializeField] private GameObject winScreen;

    private Vector3 targetPoint;
    private bool isMoving = false;
    private bool playerIsIt = true;
    private SpriteRenderer spriteRend;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        if (winScreen != null) winScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint.z = transform.position.z;
            isMoving = true;
        }

        if (isMoving)
        {
            Movement();
        }

        if (playerIsIt)
        {
            // The player turns black if It
            spriteRend.color = Color.black;
            playerItText.text = "Player It: Yes";
            StopCoroutine("CountdownToWin");
        }
        else
        {
            spriteRend.color = new Color(255f, 255f, 255f, 255f);
            playerItText.text = "Player It: No";
            StartCoroutine("CountdownToWin");
        }
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        if (transform.position == targetPoint)
        {
            isMoving = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !playerIsIt)
        {
            playerIsIt = true;
        }

        else
        {
            playerIsIt = false;
        }

        if (collision.gameObject.tag == "Wall")
        {
            isMoving = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isMoving = false;
        }
    }

    IEnumerator CountdownToWin()
    {
        yield return new WaitForSeconds(secondsToWin);
        if (winScreen != null) winScreen.SetActive(true);
    }
}
