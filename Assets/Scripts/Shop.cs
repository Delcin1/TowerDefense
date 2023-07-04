using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint[] turrets;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret1()
    {
        buildManager.SelectTurretToBuild(turrets[0]);
    }

    public void SelectTurret2()
    {
        buildManager.SelectTurretToBuild(turrets[1]);
    }

    public void SelectTurret3()
    {
        buildManager.SelectTurretToBuild(turrets[2]);
    }

    public void SelectTurret4()
    {
        buildManager.SelectTurretToBuild(turrets[3]);
    }

    public void SelectTurret5()
    {
        buildManager.SelectTurretToBuild(turrets[4]);
    }
}
