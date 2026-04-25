using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    float powerCooldown;
    float powerScale;
    float powerDuration;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, GameManager.Instance.GetMoveSpeed() * Time.deltaTime);

        transform.localScale = GameManager.Instance.GetScale();

        if (Input.GetMouseButtonDown(0)) UsePower();
    }
    void UsePower()
    {
        if (GameManager.Instance.IsPower())
        {
            Debug.Log("Using power!");
        }
    }
}