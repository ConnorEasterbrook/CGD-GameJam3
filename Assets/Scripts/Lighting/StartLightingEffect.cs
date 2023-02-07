using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLightingEffect : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _lightingObject;
    [SerializeField] private Material _skyboxMaterial;
    [SerializeField] private float _effectChangeRate = 1;
    private Color _incrementalSkyboxColor = Color.white;
    private Color _ambientGroundColor;
    private Color _incrementalAmbientGroundColor = Color.white;
    private float _lightingIntensity;
    private float _incrementalLightingIntensity = 1;
    private float _maxFogAmount;
    private float _incrementalFogAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _skyboxMaterial = RenderSettings.skybox;
        _ambientGroundColor = RenderSettings.ambientGroundColor;
        _lightingIntensity = _lightingObject.GetComponent<Light>().intensity;
        _maxFogAmount = RenderSettings.fogDensity;
    }

    // Update is called once per frame
    void Update()
    {
        _incrementalSkyboxColor = Color.Lerp(_incrementalSkyboxColor, _skyboxMaterial.color, (Time.deltaTime / (_effectChangeRate * 10)));
        _skyboxMaterial.color = _incrementalSkyboxColor;

        _incrementalAmbientGroundColor = Color.Lerp(_incrementalAmbientGroundColor, _ambientGroundColor, (Time.deltaTime / (_effectChangeRate)));
        RenderSettings.ambientLight = _incrementalAmbientGroundColor;

        _incrementalLightingIntensity = Mathf.Lerp(_incrementalLightingIntensity, _lightingIntensity, (Time.deltaTime / (_effectChangeRate * 10)));
        _lightingObject.GetComponent<Light>().intensity = _incrementalLightingIntensity;

        _incrementalFogAmount = Mathf.Lerp(_incrementalFogAmount, _maxFogAmount, (Time.deltaTime / (_effectChangeRate * 10)));
        RenderSettings.fogDensity = _incrementalFogAmount;
    }
}
