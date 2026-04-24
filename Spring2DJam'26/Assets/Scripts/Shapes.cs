using UnityEngine;

public class Shapes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Shape become follower
            //Color
        }
    }
}