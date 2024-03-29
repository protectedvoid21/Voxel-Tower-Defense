using DefenseGame;
using UnityEngine;

public class Plate : MonoBehaviour {
    public GameObject hoverElement;
    private MeshRenderer hoverRenderer;

    private Color defaultColor;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color noBuildColor;

    private BuildManager buildManager;
    private TowerType tower;
    private GameObject towerOnPlate;
    public bool hasTower => tower != null;

    private void Awake() {
        hoverRenderer = hoverElement.GetComponent<MeshRenderer>();
        defaultColor = hoverRenderer.sharedMaterial.color;
        buildManager = FindObjectOfType<BuildManager>();
    }

    private void OnMouseDown() {
        if(CanvasPointerHandler.instance.IsMouseOverUI()) {
            return;
        }
        if(hasTower) {
            buildManager.plateUI.SetTarget(this);
        }
        else {
            buildManager.Build(this);
        }
    }

    public TowerType GetTowerType() {
        return tower;
    }

    public void Build(TowerType towerToBuild) {
        if(hasTower) {
            DestroyTower();
        }
        tower = towerToBuild;
        towerOnPlate = Instantiate(tower.towerPrefab, transform.position, Quaternion.identity);
    }

    public void Upgrade() {
        if(tower.upgradeTower.cost - tower.cost <= PlayerStats.money) {
            PlayerStats.RemoveCash(tower.upgradeTower.cost - tower.cost);
            Build(tower.upgradeTower);
        }
    }

    public void DestroyTower() {
        Destroy(towerOnPlate);
        tower = null;
    }

    private void OnMouseEnter() {
        if(CanvasPointerHandler.instance.IsMouseOverUI()) {
            return;
        }
        if(buildManager.canBuild) {
            hoverRenderer.material.color = hoverColor;
        }
        if(!buildManager.canBuild && !hasTower) {
            hoverRenderer.material.color = noBuildColor;
        }

        if(hasTower) {
            towerOnPlate.GetComponent<Tower>().HoverTower(buildManager.hoverTowerMaterial);
        }
    }

    private void OnMouseExit() {
        hoverRenderer.material.color = defaultColor;

        if(hasTower) {
            towerOnPlate.GetComponent<Tower>().HoverTower(buildManager.defaultTowerPalette);
        }
    }
}
