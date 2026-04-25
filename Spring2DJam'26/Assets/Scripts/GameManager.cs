using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] TMP_Text scoreText;
    
    int followersNumber = 0;

    [Header("Upgrades:")]
    float moveSpeed = 5f;
    Vector3 scale = Vector3.one;
    bool power = false;

    bool isUpgraded = true;

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    void Update()
    {
        scoreText.text = followersNumber.ToString();
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
}
