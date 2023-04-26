using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private static MouseClick instance;

    [SerializeField] private LayerMask planeLayerMask;
    [SerializeField] private Transform mouseIndicator;
    [SerializeField] private Unit selectedUnit;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        mouseIndicator.position = GetPosition();

        if (Input.GetMouseButtonDown(0))
        {
            selectedUnit.Move(MouseClick.GetPosition());
        }

    }
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.planeLayerMask);
        //Debug.Log(raycastHit.point);
        return raycastHit.point;
    }

}