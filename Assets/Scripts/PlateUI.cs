using UnityEngine;
using UnityEngine.UI;

public class PlateUI : MonoBehaviour {
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Text upgradeText;
    [SerializeField] private Text sellText;

    [SerializeField] private Text towerName;
    [SerializeField] private Text damageText;
    [SerializeField] private Text rateOfFireText;
    [SerializeField] private Text rangeText;

    private Plate selectedPlate;

    public void SetTarget(Plate plate) {
        selectedPlate = plate;
        TowerStatsDisplay();
        gameObject.SetActive(true);
    }

    private void TowerStatsDisplay() {
        if(selectedPlate.GetTowerType().upgradeTower != null) {
            upgradeText.text = "Upgrade : " + selectedPlate.GetTowerType().upgradeTower.cost + "$";
            sellText.text = "Sell : " + selectedPlate.GetTowerType().upgradeTower.GetSellValue() + "$";  
        }
        else {
            upgradeText.text = "Not available";
            upgradeButton.interactable = false;
        }

        Tower selectedTower = selectedPlate.GetTowerType().towerPrefab.GetComponent<Tower>();
        towerName.text = selectedTower.name;
        damageText.text = "Damage : " + selectedTower.damage.ToString();
        rateOfFireText.text = "Rate of Fire : " + selectedTower.rateOfFire.ToString();
        rangeText.text = "Range : " + selectedTower.range.ToString();
    }

    private void DeselectTarget() {
        selectedPlate = null;
        gameObject.SetActive(false);
    }

    public void Upgrade() {
        selectedPlate.Upgrade();
        DeselectTarget();
    }

    public void Sell() {
        PlayerStats.AddCash(selectedPlate.GetTowerType().cost * 7 / 10);
        selectedPlate.DestroyTower();
        DeselectTarget();
    }
}