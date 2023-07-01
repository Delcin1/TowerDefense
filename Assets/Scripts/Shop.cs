using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public GameObject[] turretsPrefabs;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseTurret1()
    {
        buildManager.SetTurretToBuild(turretsPrefabs[0]);
    }

    public void PurchaseTurret2()
    {
        buildManager.SetTurretToBuild(turretsPrefabs[1]);
    }

    public void PurchaseTurret3()
    {
        buildManager.SetTurretToBuild(turretsPrefabs[2]);
    }

    public void PurchaseTurret4()
    {
        buildManager.SetTurretToBuild(turretsPrefabs[3]);
    }

    public void PurchaseTurret5()
    {
        buildManager.SetTurretToBuild(turretsPrefabs[4]);
    }
}
