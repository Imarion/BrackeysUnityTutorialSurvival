using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOD : MonoBehaviour
{

    public float slider;
    public float slider2;
    public float Hour;

    public Light sun;

    public float speed = 50.0f;

    public Color NightFogColor;
    public Color DuskFogColor;
    public Color MorningFogColor;
    public Color MiddayFogColor;

    public Color NightAmbientLight;
    public Color DuskAmbientLight;
    public Color MorningAmbientLight;
    public Color MiddayAmbientLight;

    public Color NightTint;
    public Color DuskTint;
    public Color MorningTint;
    public Color MiddayTint;

    public Material SkyBoxMaterial1;
    public Material SkyBoxMaterial2;

    public Color SunNight;
    public Color SunDay;

    // Added in episode 24: water color.
    // Uncheck "IncludeWater" to deactivate.
    public bool IncludeWater = false;
    public GameObject Water;
    public Color WaterNight;
    public Color WaterDay;

    private Renderer WaterRenderer;

    private float Tod;

    // Start is called before the first frame update
    void Start()
    {
        WaterRenderer = Water.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        if (slider >= 1.0f)
        {
            slider = 0.0f;
        }

        slider = GUI.HorizontalSlider(new Rect(20, 20, 200, 30), slider, 0, 1.0f);
        Hour = slider * 24.0f;
        Tod = slider2 * 24.0f;
        sun.transform.localEulerAngles = new Vector3((slider * 360) - 90, 0, 0);
        slider = slider + Time.deltaTime / speed;
        sun.color = Color.Lerp(SunNight, SunDay, slider * 2);
        // Added in episode 24: water color.
        // Uncheck "IncludeWater" to deactivate.
        if (IncludeWater == true) {
            WaterRenderer.material.SetColor("_horizonColor", Color.Lerp(WaterNight, WaterDay, slider2 * 2.0f - 0.2f));
        }

        if (slider < 0.5f)
        {
            slider2 = slider;
        }
        if (slider > 0.5f)
        {
            slider2 = (1.0f - slider);
        }
        sun.intensity = (slider2 - 0.2f) * 1.7f;


        if (Tod < 4)
        {
            //it is Night
            RenderSettings.skybox = SkyBoxMaterial1;
            RenderSettings.skybox.SetFloat("_Blend", 0);
            SkyBoxMaterial1.SetColor("_Tint", NightTint);
            RenderSettings.ambientLight = NightAmbientLight;
            RenderSettings.fogColor = NightFogColor;
        }
        if (Tod > 4 && Tod < 6)
        {
            RenderSettings.skybox = SkyBoxMaterial1;
            RenderSettings.skybox.SetFloat("_Blend", 0);
            RenderSettings.skybox.SetFloat("_Blend", (Tod / 2) - 2);
            SkyBoxMaterial1.SetColor("_Tint", Color.Lerp(NightTint, DuskTint, (Tod / 2) - 2));
            RenderSettings.ambientLight = Color.Lerp(NightAmbientLight, DuskAmbientLight, (Tod / 2) - 2);
            RenderSettings.fogColor = Color.Lerp(NightFogColor, DuskFogColor, (Tod / 2) - 2);
            //it is Dusk

        }
        if (Tod > 6 && Tod < 8)
        {
            RenderSettings.skybox = SkyBoxMaterial2;
            RenderSettings.skybox.SetFloat("_Blend", 0);
            RenderSettings.skybox.SetFloat("_Blend", (Tod / 2) - 3);
            SkyBoxMaterial2.SetColor("_Tint", Color.Lerp(DuskTint, MorningTint, (Tod / 2) - 3));
            RenderSettings.ambientLight = Color.Lerp(DuskAmbientLight, MorningAmbientLight, (Tod / 2) - 3);
            RenderSettings.fogColor = Color.Lerp(DuskFogColor, MorningFogColor, (Tod / 2) - 3);
            //it is Morning

        }
        if (Tod > 8 && Tod < 10)
        {
            RenderSettings.ambientLight = MiddayAmbientLight;
            RenderSettings.skybox = SkyBoxMaterial2;
            RenderSettings.skybox.SetFloat("_Blend", 1);
            SkyBoxMaterial2.SetColor("_Tint", Color.Lerp(MorningTint, MiddayTint, (Tod / 2) - 4));
            RenderSettings.ambientLight = Color.Lerp(MorningAmbientLight, MiddayAmbientLight, (Tod / 2) - 4);
            RenderSettings.fogColor = Color.Lerp(MorningFogColor, MiddayFogColor, (Tod / 2) - 4);

            //it is getting Midday

        }
    }
}
