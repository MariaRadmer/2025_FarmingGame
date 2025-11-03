
using System.Collections.Generic;
using UnityEngine;

public class CropController : MonoBehaviour
{

    public static CropController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public enum CropType
    {
        Pumpkin,
        Lettuce,
        Carrot,
        Hay,
        Potato,
        Strawberry,
        Tomato,
        Avocado
    }

    public List<CropInfo> cropList = new List<CropInfo>();

    public CropInfo GetCropInfo(CropType cropType)
    {
        foreach(CropInfo crop in cropList)
        {
            if(crop.cropType == cropType)
            {
                return crop;
            }
        }
        return null;
    }

    public void UseSeed(CropType seedToUse)
    {
        foreach(CropInfo crop in cropList)
        {
            if(crop.cropType == seedToUse)
            {
                if(crop.seedAmount > 0)
                {
                    crop.seedAmount--;
                }
            }
        }
    }

    public void AddCrop(CropType cropToAdd)
    {
        foreach (CropInfo crop in cropList)
        {
            if (crop.cropType == cropToAdd)
            {
                if (crop.seedAmount > 0)
                {
                    crop.cropAmount++;
                }
            }
        }
    }

}


[System.Serializable]
public class CropInfo
{
    public CropController.CropType cropType;
    public Sprite finalCrop, seedType, planted, growStage1, growStage2, ripe;
    public int seedAmount, cropAmount;
    [Range(0f, 100f)]
    public float growthFailChance;
}
