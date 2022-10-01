using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResolutionOption : MonoBehaviour
{
    public TextMeshProUGUI qualityText;
    public string qualitysNames;

    private int newQuality;

    public void NextResolution()
    {
        newQuality++;
        Resolution();
    }

    public void BackResolution()
    {
        newQuality--;
        Resolution();
    }

    private void Resolution()
    {
        newQuality = Mathf.Clamp(newQuality, 0, 5);
        switch (newQuality)
        {
            case 0: //960 x 540 QHD Gama low
                qualitysNames = "Very Low";
                break;
            case 1: //1.280 x 720 HD medium
                qualitysNames = "Low";
                break;
            case 2: //1.920 x 1.080 FHD high
                qualitysNames = "Medium";
                break;
            case 3: //2.560 x 1.440 QHD very high
                qualitysNames = "High";
                break;
            case 4: //2.560 x 1.440 QHD very high
                qualitysNames = "Very High";
                break;
            case 5: //2.560 x 1.440 QHD very high
                qualitysNames = "Ultra";
                break;

        }
        qualityText.text = qualitysNames;
        QualitySettings.SetQualityLevel(newQuality, true);

    }
}
