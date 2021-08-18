using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    [System.Serializable]
    public class TowerShop {
        public TowerType towerType;
        public Text costText;
    }

    public TowerShop[] towerList;

    private BuildManager buildManager;

    private void Start() {
        buildManager = FindObjectOfType<BuildManager>();

        for(int i = 0; i < towerList.Length; i++) {
            towerList[i].costText.text = towerList[i].towerType.cost.ToString() + "$"; 
        }
    }

    public void SelectTower(string towerName) {
        foreach(var tower in towerList) {
            if(tower.towerType.name == towerName) {
                if(tower.towerType.cost <= PlayerStats.money) {
                    buildManager.SelectBuildTower(tower.towerType);
                }
                return;
            }
        }

        Debug.LogError("The passed string : " + towerName + " doesn't exist.");
    }
}
