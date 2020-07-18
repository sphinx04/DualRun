using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CM_Shaker : MonoBehaviour
{
    public static CM_Shaker Instance;

    private Cinemachine.CinemachineBasicMultiChannelPerlin CM;

    public static float amplitude;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        CM = GetComponent<Cinemachine.CinemachineVirtualCamera>()
            .GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (amplitude > 0.01f)
        {
            amplitude = Mathf.Lerp(amplitude, 0f, 10 * Time.deltaTime);
            CM.m_AmplitudeGain = amplitude;
            //CM.m_FrequencyGain = Mathf.Lerp(10f, CM.m_FrequencyGain, 10 * Time.deltaTime);
        }
        else
        {
            CM.m_AmplitudeGain = 0f;
        }
    }
}
