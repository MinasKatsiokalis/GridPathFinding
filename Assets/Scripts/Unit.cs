using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;
    private GridPosition gridPosition;

    private List<Vector3> positionList = new List<Vector3>();
    private int currentPositionIndex;

    private void Awake()
    {
        targetPosition = this.transform.position;
    }

    private void Start()
    {   
        //Initialize Unit
        gridPosition = PathFinding.Instance.GetGridPosition(this.transform.position);
        //PathFinding.Instance.AddUnitAtGridPosition(gridPosition, this.gameObject.GetComponent<Unit>());


        currentPositionIndex = 0;
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

        /*
        if (positionList.Count <= 0)
            return;

        Vector3 targetPosition = positionList[currentPositionIndex];
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            currentPositionIndex++;
            if (currentPositionIndex >= positionList.Count)
            {   
                //ÅÍÄ
                Debug.Log("CurrentPos:" +currentPositionIndex);
                positionList.Clear();
                currentPositionIndex = 0;
            }
        }*/
        
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    public void SetPositionsList(List<Vector3> pathGridPositions)
    {
        foreach (Vector3 pathPosition in pathGridPositions)
            positionList.Add(pathPosition);
    }
}