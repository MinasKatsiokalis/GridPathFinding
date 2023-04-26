using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public static PathFinding Instance { get; private set; }

    [SerializeField] private Transform pathfindingDebugObjectPrefab;

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
        gridPathSystem.CreateDebugObjects(pathfindingDebugObjectPrefab, this.transform);
    }

    //Returns the grid position when given a world Vector3 position
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return gridPathSystem.GetGridPosition(worldPosition);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseClick.GetPosition());
            GridPosition startGridPosition = new GridPosition(0, 0);

            List<GridPosition> gridPositionList = gridPathSystem.FindPath(startGridPosition, mouseGridPosition);

            for (int i = 0; i < gridPositionList.Count - 1; i++)
            {
                Debug.DrawLine(
                    gridPathSystem.GetWorldPosition(gridPositionList[i]),
                    gridPathSystem.GetWorldPosition(gridPositionList[i + 1]),
                    Color.red,
                    10f
                );
            }
        }
    }

}
