using UnityEngine;

//[RequireComponent(typeof(Outline))]
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

    /*[HideInInspector]
    public Outline outline;

    protected void Awake() {
        outline = GetComponent<Outline>();
        outline.enabled = false;
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineWidth = 10f;
        outline.OutlineColor = Color.red;
    }*/

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}