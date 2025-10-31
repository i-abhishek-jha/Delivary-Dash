using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 6f;
    [SerializeField] float steerSpeed = 205f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 6f;
    [SerializeField] TMP_Text boostText;
    bool isHaveBooster;

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost") && isHaveBooster == false)
        {
            currentSpeed = boostSpeed;
            isHaveBooster = true;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WorldCollision"))
        {
            currentSpeed = regularSpeed;
            isHaveBooster = false;
            boostText.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -0.5f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
