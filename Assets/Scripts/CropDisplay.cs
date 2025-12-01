using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropDisplay : MonoBehaviour
{
    public CropController.CropType cropType;
    public Image seedImage;
    public TMP_Text seedAmount;

    public void UpdateCropDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(cropType);

        seedImage.sprite = info.finalCrop;
        seedAmount.text = "x" + info.cropAmount.ToString();
    }


}
