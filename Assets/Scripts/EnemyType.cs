using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "New Enemy")]
public class EnemyType : ScriptableObject {
    public GameObject prefab;
    public int maxHealth;
    public float speed;

    private void Awake() {
        prefab.AddComponent<Enemy>();
    }
}
