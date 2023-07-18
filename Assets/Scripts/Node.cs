using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public int curTurretGrade = 0;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (!buildManager.HasMoney)
        {
            buildManager.SelectTurretToBuild(null);
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turret.GetComponent<Turret>().node = this;

        turretBlueprint = blueprint;

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (curTurretGrade > 1)
        {
            Debug.Log("Turret has already max level");
            return;
        }

        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefabs[curTurretGrade], GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turret.GetComponent<Turret>().node = this;

        curTurretGrade += 1;

        Debug.Log("Turret Upgraded! Money left:" + PlayerStats.Money);
    }

    public void SellTurret()
    {
        curTurretGrade = 0;
        PlayerStats.Money += GetTurretCost();
        Destroy(turret);
        turretBlueprint = null;
    }

    public int GetTurretCost()
    {
        return (turretBlueprint.cost + turretBlueprint.upgradeCost * curTurretGrade) / 2;
    }

    private void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
