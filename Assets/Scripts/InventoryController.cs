using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public SeedDisplay[] seedDisplays;
    public CropDisplay[] cropDisplays;
    public void OpenClose()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            UpdateDisplay();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateDisplay()
    {
        foreach (SeedDisplay display in seedDisplays)
        {
            display.UpdateSeedDisplay();
        }
        foreach (CropDisplay display in cropDisplays)
        {
            display.UpdateCropDisplay();
        }
    }
}
