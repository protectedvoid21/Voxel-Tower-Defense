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

    public void SelectTower(string tower) {
        for(int i = 0; i < towerList.Length; i++) {
            if(towerList[i].towerType.towerName == tower) {
                if(towerList[i].towerType.cost <= PlayerStats.money) {
                    buildManager.SelectBuildTower(towerList[i].towerType);
                }
                return;
            }
        }
        Debug.LogError("No towers found at string passsed as parameter in onclick button method");
    }
}
