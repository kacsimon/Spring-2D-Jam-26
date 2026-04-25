using UnityEngine;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] UpgradeCardSO upgradeCardSO;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;
    GameObject upgradePanel;

    void Start()
    {
        nameText.text = upgradeCardSO.name;
        descriptionText.text = upgradeCardSO.upgradeDescription;
        upgradePanel = transform.parent.gameObject;
    }

    public void OnSelect()
    {
        upgradePanel.SetActive(false);
        switch (upgradeCardSO.upgradeId)
        {
            case 0:
                //speed
                GameManager.Instance.IncreaseMoveSpeed();
                break;
            case 1:
                //aura
                Vector3 scale = GameManager.Instance.GetScale();
                GameManager.Instance.SetScale(scale + new Vector3(0.2f, 0.2f, 0.2f));
                break;
            case 2:
                //power
                GameManager.Instance.ActivatePower();
                break;
            case 3:
                //power cooldown
                break;
            case 4:
                //power range
                break;
        }
        Time.timeScale = 1f;
        GameManager.Instance.Upgraded();
    }
}