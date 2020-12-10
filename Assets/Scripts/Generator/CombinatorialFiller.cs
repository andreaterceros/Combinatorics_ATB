using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO DO
//1. Set a first block
//Probably just select a random voxel with Z index 0
//Position a block on this voxel

//2. Find all the possible next voxels
//loop over all the blocks
//Where possibleDirection contains elements
//Loop over possible directions elements
//Get neighbour voxels of these elements in the direction
//Check if index of neighbour voxel is withing grid (theres a Util function for that)
//Check if neighbour voxel is still available
//Add the neighbour voxel to the list of possible direction
//neihgbour voxels need to be unique ==> Look into hashset

//3. Try adding a block on a random neighbourvoxel until the next block is built 

//4. Loop over 2 --> 3 till you place a certain amount of blocks, or no more blocks can be added


public class CombinatorialFiller : MonoBehaviour
{

    #region Public Fields
    //list of Blocks
    //list of Voxels, this can replace the blocks
    public List<Voxel> Voxels;
    public Vector3Int GridSize;


    //have the patterns variables
    public PatternType Type;

    //The EndPatternVoxel this component is assigned to
    private Voxel _endPatternVoxel;
    //Possible directions?
    public List<AxisDirection> PossibleDirections;
    public BuildingManager BManager
    {
        get
        {
            if (_buildingManager == null)
            {
                GameObject manager = GameObject.Find("Manager");
                _buildingManager = manager.GetComponent<BuildingManager>();
            }
            return _buildingManager;
        }
    }


    #endregion

    #region Private Fields

    //Grid variables
    private VoxelGrid _grid;
    //Grid generating variables
    private float _voxelSize = 0.2f;
    private int _voxelOffset = 2;

    private int _triesPerIteration = 25000;
    private int _iterations = 100;

    //Patterns variables
    private Pattern _pattern => PatternManager.GetPatternByType(Type);

   
    private BuildingManager _buildingManager;
    

    #endregion

    #region Start Voxel Deff

    //1. Set a first Block / Voxel
    //Probably just select a random voxel with Z index 0, Do we mean Z as Y in UNITY?
    //Position a block on this voxel

    Vector3Int StartRandomIndex()
    {
        // Place a random start at the bottom
        int x = UnityEngine.Random.Range(0, _grid.GridSize.x);
        int y = 0;
        int z = UnityEngine.Random.Range(0, _grid.GridSize.z);

        return new Vector3Int(x, y, z);
    }

    Quaternion RandomRotation()
    {
        int x = UnityEngine.Random.Range(0, 4) * 90;
        int y = UnityEngine.Random.Range(0, 4) * 90;
        int z = UnityEngine.Random.Range(0, 4) * 90;
        return Quaternion.Euler(x, y, z);
    }

    //1.1 Place a random patern and get its next possible voxels
    
    void Start()
    {
        _grid = BManager.CreateVoxelGrid(BoundingMesh.GetGridDimensions(_voxelOffset, _voxelSize), _voxelSize, BoundingMesh.GetOrigin(_voxelOffset, _voxelSize));
        Debug.Log(_grid.GridSize);
        _grid.DisableOutsideBoundingMesh();
        
    }

    
    void Update()
    {
        if PlacedBlocks.Count = 0;
            {
            PlaceFirstBlock;
        }
        else
        {

        }
        if (Input.GetKeyDown("space"))
        {
            var lastBlock = _grid.PlacedBlocks[_grid.PlacedBlocks.Count -1];
            var lastVoxel = lastBlock.Voxels[lastBlock.Voxels.Count - 1];
            // TryAddBlockAtVoxel(lastVoxel);
            TryAddRandomBlock();
            //Place GO and get pattern type? 
            //public Voxel GetVoxelByIndex(Vector3Int index) => Voxels[index.x, index.y, index.z];
            Voxel voxelAtIndex = _grid.GetVoxelByIndex(Vector3Int.zero);
        }
        else
        {
            Console.WriteLine("press space to start");
        }
    }
    #endregion


    //3.Loop over possible directions elements
    //Get neighbour voxels of these elements in the direction
    public void PossibleDirectionsNeighbours()
    {
        ////PatternType.get AxisDirection;
        ////var t = 

        ////Ideally in the possible directions function we should
        ////input only the list we have of public List<AxisDirection> PossibleDirectionsArray;


        //var neighbours = _endPatternVoxel.GetFaceNeighboursArray();
        //for (int i = 0; i < neighbours.Length; i++)
        //{
        //    //4.Check if index of neighbour voxel is within grid (theres a Util function for that)
        //    if (CheckBounds != true)
        //    {
        //        //If neighbour voxel is occupied // if (neighbours != IsOccupied) (define IsOccupied, alternative)
        //        if (!neighbours.IsOccupied) 
        //        {
        //            //Restart?
        //        }
        //        // If neighbour voxel is not occupied
        //        else
        //        {
        //            //6. Try adding a block on a random neighbourvoxel until the next block is built
        //        }
        //    }
            
        //}
    }

//neihgbour voxels need to be unique ==> Look into hashset

//6.1 Neighbourvoxel class?

//7. Loop over 2 --> 3 till you place a certain amount of blocks, or no more blocks can be added
#region Public methods



#endregion

#region Private Methods

//2. Find all the possible next voxels
//loop over all the blocks //Or the VOXELS!!
//Where possibleDirection contains elements
public IEnumerable<Voxel> GetVoxels()
    {
        for (int x = 0; x < GridSize.x; x++)
            for (int y = 0; y < GridSize.y; y++)
                for (int z = 0; z < GridSize.z; z++)
                {
                    yield return Voxels[index, possible;
                }
    }
    private IEnumerable<Voxel> GetPathVoxels()
    {
        foreach (Voxel voxel in Voxels.)
        {
            if (voxel.IsPath)
            {
                yield return voxel;
            }
        }

        
    }

    /// <summary>
    /// Methods using VoxelGrid operations, 
    /// </summary>
    private void BlockTest()
    {
        var anchor = new Vector3Int(2, 8, 0);
        var rotation = Quaternion.Euler(0, 0, -90);
        _grid.AddBlock(anchor, rotation);
        _grid.TryAddCurrentBlocksToGrid();
    }

    private bool TryAddRandomBlock()
    {
        _grid.SetRandomType();
        _grid.AddBlock(StartRandomIndex(), RandomRotation());
        bool blockAdded = _grid.TryAddCurrentBlocksToGrid();
        _grid.PurgeUnplacedBlocks();
        return blockAdded;
    }

    #endregion
    
}

