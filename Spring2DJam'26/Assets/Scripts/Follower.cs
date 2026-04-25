using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float maxMoveSpeed = 10;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] float turnSpeed = 45;

    Vector3 offset;
    Vector2 currentVelocity;

    public Transform Target { get; set; }

    void Start()
    {
        offset = new Vector3(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
    }
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, Target.position + offset, ref currentVelocity, smoothTime, maxMoveSpeed);

        //LookAtMouse
        Vector2 direction = Target.position - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);

        Destroy(gameObject, 100f);
    }
}
