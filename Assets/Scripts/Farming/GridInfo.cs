
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridInfo : MonoBehaviour
{

    public static GridInfo instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public bool hasGrid;

    public List<InfoRow> theGrid;


    public void CreateGrid()
    {
        hasGrid = true;

        for(int y = 0; y < GridController.instance.blockRows.Count; y++)
        {
            theGrid.Add(new InfoRow());

            for(int x = 0; x< GridController.instance.blockRows[y].blocks.Count;x++ ) 
            {
                theGrid[y].blocks.Add(new BlockInfo());
            }
        }
    }


    public void UpdateInfo ( GrowBlock growBlock, int x, int y ) {

        theGrid[y].blocks[x].currentStage = growBlock.currentStage;
        theGrid[y].blocks[x].isWatered= growBlock.isWatered;

    }

    public void GrowCrops()
    {
        for(int y = 0;y<theGrid.Count;y++)
        {
            for (int x = 0; x < theGrid[y].blocks.Count; x++)
            {
                BlockInfo current = theGrid[y].blocks[x];

                if (current.isWatered)
                {
                    switch(current.currentStage)
                    {
                        case GrowBlock.GrowthStage.Planted:
                            current.currentStage = GrowBlock.GrowthStage.Growing1;
                            break;
                        case GrowBlock.GrowthStage.Growing1:
                            current.currentStage = GrowBlock.GrowthStage.Growing2;
                            break;
                        case GrowBlock.GrowthStage.Growing2:
                            current.currentStage = GrowBlock.GrowthStage.Ripe;
                            break;

                    }

                    current.isWatered = false;
                }
            }
        }
    }
    /*
    private void Update()
    {
        if(Keyboard.current.yKey.wasPressedThisFrame)
        {
            GrowCrops();
        }
    }*/
}

[System.Serializable]
public class BlockInfo
{
    public bool isWatered;
    public GrowBlock.GrowthStage currentStage;
}

[System.Serializable]
public class InfoRow
{
    public List<BlockInfo> blocks = new List<BlockInfo>();
}