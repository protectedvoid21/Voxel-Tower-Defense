using UnityEngine;

public class BuildManager : MonoBehaviour {
    public GameObject tower;

    public void Build(Plate plate) {
        Instantiate(tower, plate.transform.position, Quaternion.identity);
    }
}
