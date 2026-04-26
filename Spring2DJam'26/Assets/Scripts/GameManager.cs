using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text powerCooldownText;

    int followersNumber = 0;

    [Header("Upgrades:")]
    float moveSpeed = 5f;
    Vector3 scale = Vector3.one;
    bool power = false;
    float powerCooldown = 10f;
    float powerScale = 2.5f;
    float powerTimer;

    bool isUpgraded = true;
    bool isCardSet = false;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    void Update()
    {
        scoreText.text = followersNumber.ToString();
        powerCooldownText.gameObject.SetActive(power);
        powerCooldownText.text = powerTimer.ToString("0.0s/") + powerCooldown.ToString("0s");
    }
    public void IncreaseFollowersNumber() => followersNumber++;
    public int GetFollowersNumber() => followersNumber;
    public void IncreaseMoveSpeed() => moveSpeed++;
    public float GetMoveSpeed() => moveSpeed;
    public void ActivatePower() => power = true;
    public bool IsPower() => power;
    public void Upgraded() => isUpgraded = true;
    public void ResetUpgrade() => isUpgraded = false;
    public bool IsUpgraded() => isUpgraded;
    public void SetScale(Vector3 _scale) => scale = _scale;
    public Vector3 GetScale() => scale;
    public float GetPowerCooldown() => powerCooldown;
    public void SetPowerCooldown(float _powerCooldown) => powerCooldown = _powerCooldown;
    public float GetPowerScale() => powerScale;
    public void SetPowerScale(float _powerScale) => powerScale = _powerScale;
    public float GetPowerTimer() => powerTimer;
    public void SetPowerTimer(float _powerTimer) => powerTimer = _powerTimer;
    public bool IsCardSet() => isCardSet;
    public void SetCardSet(bool _isCardSet) => isCardSet = _isCardSet;
}
