using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public static PathFinding Instance { get; private set; }

    [SerializeField] private Transform _pathfindingDebugObjectPrefab;
    [SerializeField] private Unit _unit;

    private GridPathSystem gridPathSystem;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        //Grid Creation

        //10 x 100 Grid , 1 unit tile size
        gridPathSystem = new GridPathSystem(10, 10, 1f);
        //Create Debug Objects on each grid tile
        gridPathSystem.CreateDebugObjects(_pathfindingDebugObjectPrefab, this.transform);
    }

    //Returns the GridSystem that created
    public GridPathSystem Grid()
    {
        return gridPathSystem;
    }

    //Returns the grid position when given a world Vector3 position
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return gridPathSystem.GetGridPosition(worldPosition);
    }

    List<GridPosition> gridPathPositionList;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gridPathPositionList = null;

            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseClick.GetPosition());
            GridPosition startGridPosition = new GridPosition(0, 0);

            gridPathPositionList = gridPathSystem.FindPath(startGridPosition, mouseGridPosition);

            //temporary unit position list
            List<Vector3> unitPositionsList = new List<Vector3>();

            for (int i = 0; i < gridPathPositionList.Count - 1; i++)
            {   
                //fill the list
                unitPositionsList.Add(gridPathSystem.GetWorldPosition(gridPathPositionList[i]));

                if(i == gridPathPositionList.Count - 2)
                    unitPositionsList.Add(gridPathSystem.GetWorldPosition(gridPathPositionList[i+1]));


                Debug.DrawLine(
                    gridPathSystem.GetWorldPosition(gridPathPositionList[i]),
                    gridPathSystem.GetWorldPosition(gridPathPositionList[i + 1]),
                    Color.red,
                    10f
                );
            }
            //Update Unit's list
            Debug.Log(unitPositionsList.Count);
            _unit.SetPositionsList(unitPositionsList);
        }
    }

}
