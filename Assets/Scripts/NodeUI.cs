using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Button upgradeBtn;
    public TMP_Text upgradeCost;

    public TMP_Text sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        sellAmount.text = "$" + target.GetTurretCost();

        if (target.curTurretGrade > 1)
        {
            upgradeCost.text = "DONE";
            upgradeBtn.interactable = false;
        } else
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeBtn.interactable = true;
        }

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
