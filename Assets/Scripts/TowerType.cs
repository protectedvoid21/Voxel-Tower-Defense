using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "New Tower")]
public class TowerType : ScriptableObject {
    public string name;
    public GameObject towerPrefab;
    public int cost;
}
