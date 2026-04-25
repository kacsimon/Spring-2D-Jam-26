using UnityEngine;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] UpgradeCardSO upgradeCardSO;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;

    void Start()
    {
        nameText.text = upgradeCardSO.name;
        descriptionText.text = upgradeCardSO.upgradeDescription;
    }

    public void OnSelect()
    {
        switch (upgradeCardSO.upgradeId)
        {
            case 0:
                //speed
                Debug.Log("Speed upgraded");
                GameManager.Instance.IncreaseMoveSpeed();
                break;
            case 1:
                //aura
                Debug.Log("Aura upgraded");
                break;
            case 2:
                //power
                Debug.Log("Power upgraded");
                break;
        }
    }
}
