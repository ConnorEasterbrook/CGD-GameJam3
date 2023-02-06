using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battery : MonoBehaviour
{
    public Light m_light;
    public bool Drainyes;
    public float Maxbightness;
    public float Minbightness;
    [SerializeField] float drainrate;
    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        m_light.intensity = Mathf.Clamp(m_light.intensity, Minbightness, Maxbightness);
        if(Drainyes == true && m_light.enabled == true)
        {
            if (m_light.intensity > Minbightness)
            {
                m_light.intensity -= Time.deltaTime * (drainrate / 1000);
            }

        }
        if (Drainyes == true && m_light.enabled == false)
        {
            if (m_light.intensity < Maxbightness)
            {
                m_light.intensity += Time.deltaTime * (drainrate / 1000);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            m_light.enabled = !m_light.enabled;
        }


    }
}
