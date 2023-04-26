using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PathfindingDebugObject : MonoBehaviour
{
    [SerializeField] private TMP_Text poistionText;

    [SerializeField] private TMP_Text gCostText;
    [SerializeField] private TMP_Text hCostText;
    [SerializeField] private TMP_Text fCostText;

    private PathNode pathNode;

    public void SetPathfindingObject(PathNode pathNode)
    {
        this.pathNode = pathNode;
    }
    private void Update()
    {
        poistionText.text = pathNode.ToString();
        gCostText.text = pathNode.GetGCost().ToString();
        hCostText.text = pathNode.GetHCost().ToString();
        fCostText.text = pathNode.GetFCost().ToString();
    }
}