using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "New Tower")]
public class TowerType : ScriptableObject {
    public GameObject towerPrefab;
    public TowerType upgradeTower;
    public int cost;

    public int GetSellValue() {
        return cost * 7 / 10;
    }
}
