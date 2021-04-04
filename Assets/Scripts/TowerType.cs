using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "New Tower")]
public class TowerType : ScriptableObject {
    public string towerName;
    public GameObject towerPrefab;
    public TowerType upgradeTower;
    public int cost;
}
