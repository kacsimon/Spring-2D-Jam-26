using UnityEngine;

public class Shapes : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Color[] colors;
    [SerializeField] ParticleSystem transformationPS;
    [SerializeField] Sprite[] sprites;

    Follower follower;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        follower = GetComponent<Follower>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        float scaleSize = Random.Range(0.3f, 0.5f);
        transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }
    void Update()
    {
        Vector3 offset = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f));
        transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)) + offset, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseFollowersNumber();
            follower.enabled = true;
            boxCollider2D.enabled = false;
            follower.Target = collision.gameObject.transform;
            spriteRenderer.color = colors[Random.Range(0, colors.Length)];
            ParticleSystem.MainModule transformationPSMain = transformationPS.main;
            transformationPSMain.startColor = spriteRenderer.color;
            transformationPS.Play();
            AudioManager.Instance.Play("Evolve");
        }
    }
}