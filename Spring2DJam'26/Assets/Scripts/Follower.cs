using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float maxMoveSpeed = 10;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] float turnSpeed = 45;

    Vector2 currentVelocity;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);

        //LookAtMouse
        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);
    }
}
