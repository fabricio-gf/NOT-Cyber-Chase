using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour{

    public GameObject TilePrefab;

    [SerializeField] int Rows = 6;
    [SerializeField] int Columns = 9;

    Grid myGrid;

    // Start is called before the first frame update
    void Awake()
    {
        
        Tile[,] matrix = new Tile[Rows, Columns]; 
        
        if (myGrid == null) {
            myGrid = GetComponent<Grid>();
            for (int row = 0; row < Rows; row++) {
                for (int col = 0; col < Columns; col++) {
                    Vector3 position = myGrid.GetCellCenterWorld(new Vector3Int(col - (Columns/2), row - (Rows/2), 0));
                    matrix[row,col] = Instantiate(TilePrefab, position, Quaternion.identity, transform).GetComponent<Tile>();
                }
            }

            for (int row = 0; row < Rows; row++) {
                for (int col = 0; col < Columns; col++) {

                    if(row + 1 < Rows)matrix[row, col].upTile = matrix[row + 1, col];

                    if (row - 1 >= 0) matrix[row, col].downTile = matrix[row - 1, col];

                    if (col + 1 < Columns) matrix[row, col].rightTile = matrix[row, col + 1];

                    if (col - 1 >= 0) matrix[row, col].leftTile = matrix[row, col - 1];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
