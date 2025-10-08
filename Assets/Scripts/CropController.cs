
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

}


[System.Serializable]
public class CropInfo
{
    public CropController.CropType cropType;
    public Sprite finalCrop, seedType, planted, growStage1, growStage2, ripe;
    public int seedAmount, cropAmount;
}
