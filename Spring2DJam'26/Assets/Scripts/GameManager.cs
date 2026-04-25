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

    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    void Update()
    {
        scoreText.text = followersNumber.ToString();
    }
    public void IncreaseFollowersNumber()
    {
        followersNumber++;
    }
    public int GetFollowersNumber() => followersNumber;
    public void IncreaseMoveSpeed() => moveSpeed++;
    public float GetMoveSpeed() => moveSpeed;
    public bool IsPower() => power;
}
