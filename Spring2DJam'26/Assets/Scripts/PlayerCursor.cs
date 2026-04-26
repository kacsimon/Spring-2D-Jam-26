using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCursor : MonoBehaviour
{
    //float powerCooldown = 10f;
    //float powerScale = 2.5f; //startSize
    float powerDuration = 0.5f;
    //float powerTimer;
    bool isPowerOn;
    ParticleSystem shockwave;
    BoxCollider2D boxCollider;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        shockwave = GetComponentInChildren<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, GameManager.Instance.GetMoveSpeed() * Time.deltaTime);

        transform.localScale = GameManager.Instance.GetScale();

        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI()) UsePower();

        if (GameManager.Instance.GetPowerTimer() > 0)
        {
            float powerTimer = GameManager.Instance.GetPowerTimer();
            GameManager.Instance.SetPowerTimer(powerTimer -= Time.deltaTime);
        }

        if (isPowerOn)
        {
            powerDuration -= Time.deltaTime;
            if (powerDuration <= 0)
            {
                isPowerOn = false;
                powerDuration = 0.5f;
                boxCollider.size = Vector2.one;
            }
        }
    }
    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    void UsePower()
    {
        if (GameManager.Instance.IsPower() && GameManager.Instance.GetPowerTimer() <= 0)
        {
            isPowerOn = true;
            ParticleSystem.MainModule shockwaveMain = shockwave.main;
            shockwaveMain.startSize = GameManager.Instance.GetPowerScale() + 5.5f;
            shockwave.Play();
            AudioManager.Instance.Play("Shockwave");
            boxCollider.size = new Vector2(GameManager.Instance.GetPowerScale(), GameManager.Instance.GetPowerScale());
            GameManager.Instance.SetPowerTimer(GameManager.Instance.GetPowerCooldown());
        }
    }
}