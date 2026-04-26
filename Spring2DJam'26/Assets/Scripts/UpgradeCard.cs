using UnityEngine;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    UpgradeCardSO upgradeCardSO;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;
    GameObject upgradePanel;

    void Start()
    {
        upgradePanel = transform.parent.gameObject;
        UpdateUpgradeCardUI();
    }
    public void OnSelect()
    {
        AudioManager.Instance.Play("Button");
        upgradePanel.SetActive(false);
        switch (upgradeCardSO.upgradeId)
        {
            case 0:
                //power
                GameManager.Instance.ActivatePower();
                break;
            case 1:
                //speed
                GameManager.Instance.IncreaseMoveSpeed();
                break;
            case 2:
                //aura
                Vector3 scale = GameManager.Instance.GetScale();
                GameManager.Instance.SetScale(scale + new Vector3(0.2f, 0.2f, 0.2f));
                break;
            case 3:
                //power cooldown
                float powerCooldown = GameManager.Instance.GetPowerCooldown();
                GameManager.Instance.SetPowerCooldown(powerCooldown / 1.5f); //!!!Check 0!!!
                break;
            case 4:
                //power range
                float powerScale = GameManager.Instance.GetPowerScale();
                GameManager.Instance.SetPowerScale(powerScale + 0.5f);
                break;
        }
        Time.timeScale = 1f;
        GameManager.Instance.Upgraded();
        GameManager.Instance.SetCardSet(false);
    }
    void UpdateUpgradeCardUI()
    {
        nameText.text = upgradeCardSO.upgradeName;
        descriptionText.text = upgradeCardSO.upgradeDescription;
    }
    public void SetUpgradeCardSO(UpgradeCardSO _upgradeCardSO)
    {
        upgradeCardSO = _upgradeCardSO;
        UpdateUpgradeCardUI();
    }
}