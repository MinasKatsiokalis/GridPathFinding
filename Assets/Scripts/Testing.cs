using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

    [SerializeField] private Transform gridDebugObjectPrefab;


    private GridSystem gridSystem;

    [SerializeField] int gridWidth;
    [SerializeField] int gridHeight;

    private void Start()
    {
        gridSystem = new GridSystem(gridWidth, gridHeight, 1f);
        gridSystem.CreateDebugObjects(gridDebugObjectPrefab);

    }

    private void Update()
    {
        Debug.Log(gridSystem.GetGridPosition(MouseClick.GetPosition()));
    }

}