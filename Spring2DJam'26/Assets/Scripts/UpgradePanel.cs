using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;

    void Start()
    {
        upgradePanel.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance.GetFollowersNumber() % 50 != 0) GameManager.Instance.ResetUpgrade();
        if (GameManager.Instance.GetFollowersNumber() % 50 == 0 && !GameManager.Instance.IsUpgraded())
        {
            Time.timeScale = 0f;
            upgradePanel.SetActive(true);
        }
    }

    //Set 2 random upgrade
    //If power (2) locked, don't show 3 and 4
    //If power (2) unulock, don't show 2
    void Power()
    {
        if (GameManager.Instance.IsPower())
        {

        }
    }
}
