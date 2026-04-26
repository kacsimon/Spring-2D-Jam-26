using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    [SerializeField] UpgradeCardSO[] upgradeCardSOArray;
    [SerializeField] UpgradeCard[] upgradeCardArray;

    void Awake()
    {
        SetUpgradeCardUI();
    }
    void Start()
    {
        upgradePanel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.GetFollowersNumber() % 50 != 0) GameManager.Instance.ResetUpgrade();
        if (GameManager.Instance.GetFollowersNumber() % 50 == 0 && !GameManager.Instance.IsUpgraded() && GameManager.Instance.GetFollowersNumber() < 200) ShowUpgradeUI();
        if (GameManager.Instance.GetFollowersNumber() % 100 == 0 && !GameManager.Instance.IsUpgraded() && GameManager.Instance.GetFollowersNumber() < 500) ShowUpgradeUI();
        if (GameManager.Instance.GetFollowersNumber() % 500 == 0 && !GameManager.Instance.IsUpgraded() && GameManager.Instance.GetFollowersNumber() < 2000) ShowUpgradeUI();

        //DEBUG
        if (Input.GetKeyDown(KeyCode.Pause)) ShowUpgradeUI();
    }
    void ShowUpgradeUI()
    {
        if (!GameManager.Instance.IsCardSet()) SetUpgradeCardUI();
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);
    }
    int GetRandomNumber()
    {
        int rng = GameManager.Instance.IsPower() ? Random.Range(1, upgradeCardSOArray.Length) : Random.Range(0, 3);
        return rng;
    }
    void SetUpgradeCardUI()
    {
        int rng1 = 0;
        int rng2 = 0;
        while (rng1 == rng2)
        {
            rng1 = GetRandomNumber();
            rng2 = GetRandomNumber();
        }
        upgradeCardArray[0].SetUpgradeCardSO(upgradeCardSOArray[rng1]);
        upgradeCardArray[1].SetUpgradeCardSO(upgradeCardSOArray[rng2]);
        GameManager.Instance.SetCardSet(true);
    }
}