using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedDisplay : MonoBehaviour
{
    public CropController.CropType cropType;
    public Image seedImage;
    public TMP_Text seedAmount;

    public void UpdateSeedDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(cropType);

        seedImage.sprite = info.seedType;
        seedAmount.text = "x" + info.seedAmount.ToString();
    }

    public void SelectSeed()
    {
        PlayerController.instance.SwitchSeed(cropType);

        UIController.instance.SwithSeed(cropType);

        UIController.instance.inventoryController.OpenClose();
    }
}
