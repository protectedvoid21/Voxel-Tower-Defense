using UnityEngine;

public class BuildManager : MonoBehaviour {
    public PlateUI plateUI;
    private ShopManager shopManager;

    private TowerType towerToBuild;

    public bool canBuild { 
        get {
            if(towerToBuild != null) {
                return PlayerStats.money >= towerToBuild.cost;
            }
        return false;
    }}

    private void Awake() {
        shopManager = GetComponent<ShopManager>();
    }
    
    public void SelectBuildTower(TowerType tower) {
        if(PlayerStats.money >= tower.cost) {
            towerToBuild = tower;
        }
    }

    public void Build(Plate plate) {
        if(towerToBuild != null && canBuild && !plate.hasTower) {
            PlayerStats.RemoveCash(towerToBuild.cost);
            plate.Build(towerToBuild);
        }
    }
}
