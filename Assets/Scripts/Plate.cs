using UnityEngine;

public class Plate : MonoBehaviour {
    public GameObject hoverElement;
    private MeshRenderer hoverRenderer;

    private Color defaultColor;
    public Color hoverColor;
    public Color noBuildColor;

    private BuildManager buildManager;
    private TowerType tower;
    public bool hasTower = false;

    private void Start() {
        hoverRenderer = hoverElement.GetComponent<MeshRenderer>();
        defaultColor = hoverRenderer.sharedMaterial.color;
        buildManager = FindObjectOfType<BuildManager>();
    }

    private void OnMouseDown() {
        if(hasTower) {
            buildManager.plateUI.SetTarget(this);
        }
        else {
            buildManager.Build(this);
            hasTower = true;
        }
    }

    public void Build(TowerType tower) {
        this.tower = tower;
        Instantiate(tower.towerPrefab, transform.position, Quaternion.identity);
    }

    private void OnMouseOver() {
        if(buildManager.canBuild) {
            hoverRenderer.material.color = hoverColor;
        }
        if(!buildManager.canBuild || hasTower){
            hoverRenderer.material.color = noBuildColor;
        }
    }

    private void OnMouseExit() {
        hoverRenderer.material.color = defaultColor;
    }
}
