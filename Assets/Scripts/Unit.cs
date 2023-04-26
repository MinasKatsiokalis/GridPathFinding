using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private GridPosition gridPosition;

    private void Awake()
    {
        targetPosition = this.transform.position;
    }

    private void Start()
    {   
        //Initialize Unit
        gridPosition = LevelGrid.Instance.GetGridPosition(this.transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this.gameObject.GetComponent<Unit>());
    }

    private void Update()
    {
        float stoppingDistance = 0.05f;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {   
            //Move unit to target position
            Vector3 moveDirection = (targetPosition - this.transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            
            //Rotate Unit to face the direction it's moving
            float rotateSpeed = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        }


        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(this.transform.position);
        if (newGridPosition != gridPosition)
        {
            // Unit changed Grid Position
            LevelGrid.Instance.UnitMovedGridPosition(this.gameObject.GetComponent<Unit>(), gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

}