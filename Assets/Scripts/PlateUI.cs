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

    private void Update() {
        if(Input.GetMouseButtonDown(1) && selectedPlate != null) {
            DeselectTarget();
        }
    }

    private void TowerStatsDisplay() {
        if(selectedPlate.GetTowerType().upgradeTower != null) {
            upgradeButton.interactable = true;
            upgradeText.text = "Upgrade : " + (selectedPlate.GetTowerType().upgradeTower.cost - selectedPlate.GetTowerType().cost).ToString() + "$";
        }
        else { 
            upgradeText.text = "Not available";
            upgradeButton.interactable = false;
        }
        sellText.text = "Sell : " + selectedPlate.GetTowerType().GetSellValue() + "$";

        Tower selectedTower = selectedPlate.GetTowerType().towerPrefab.GetComponent<Tower>();
        towerName.text = selectedPlate.GetTowerType().name;
        damageText.text = "Damage : " + selectedTower.damage.ToString();
        rateOfFireText.text = "Rate of Fire : " + selectedTower.rateOfFire.ToString();
        rangeText.text = "Range : " + selectedTower.range.ToString();
    }

    private void DeselectTarget() {
        //selectedPlate.GetTowerType().towerPrefab.GetComponent<Tower>().outline.enabled = false;
        selectedPlate = null;
        gameObject.SetActive(false);
    }

    public void Upgrade() {
        selectedPlate.Upgrade();
        DeselectTarget();
    }

    public void Sell() {
        PlayerStats.AddCash(selectedPlate.GetTowerType().GetSellValue());
        selectedPlate.DestroyTower();
        DeselectTarget();
    }
}