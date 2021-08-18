using UnityEngine;

public abstract class Tower : MonoBehaviour {
    public int damage;
    public float range;
    public float rateOfFire;
    
    public MeshRenderer[] rendererParts;

    public void HoverTower(Material hoverMaterial) {
        foreach(var renderer in rendererParts) {
            renderer.material = hoverMaterial;
        }   
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}