using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }
}