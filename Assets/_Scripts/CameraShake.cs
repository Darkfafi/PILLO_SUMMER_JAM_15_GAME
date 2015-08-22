using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    private float m_fShakeAmplitude = 0.0f;
    private float m_fDecay = 0.004f;
    private bool m_bCanShake = true;

    private Camera m_cCamera;

    private Vector3 m_vOriginPosition;
    private Quaternion m_qOriginRotation;
    private Quaternion m_qTargetRotation;

	// Use this for initialization
	void Start () {
        m_cCamera = this.GetComponent<Camera>();
        Shake(0.04f);
	}
	
	// Update is called once per frame
	void Update () {
	    /*if (Input.GetButtonDown("Jump") && m_bCanShake)
        {
            //Debug.Log("Shake that ass!");
            //Shake(0.08f);
        }*/
        DoShake();
	}

    public void Shake(float amp)
    {
        if (m_bCanShake)
        {
            m_vOriginPosition = m_cCamera.transform.position;
            m_qOriginRotation = m_cCamera.transform.rotation;
            m_fShakeAmplitude = amp;
            m_bCanShake = false;
//            Debug.Log("shaky");
        }
    }

    private void DoShake()
    {
        if (m_fShakeAmplitude > 0)
        {
            //transform.position = m_vOriginPosition + Random.insideUnitSphere * m_fShakeAmplitude;// *10;
            m_qTargetRotation.x = m_qOriginRotation.x + Random.Range(-m_fShakeAmplitude, m_fShakeAmplitude) * 0.2f;
            m_qTargetRotation.y = m_qOriginRotation.y + Random.Range(-m_fShakeAmplitude, m_fShakeAmplitude) * 0.2f;
            m_qTargetRotation.z = m_qOriginRotation.z + Random.Range(-m_fShakeAmplitude, m_fShakeAmplitude) * 0.2f;
            m_qTargetRotation.w = m_qOriginRotation.w + Random.Range(-m_fShakeAmplitude, m_fShakeAmplitude) * 0.2f;
            transform.rotation = m_qTargetRotation;
            
            m_fShakeAmplitude -= m_fDecay;
            if (m_fShakeAmplitude < 0)
            {
                transform.rotation = new Quaternion(m_qOriginRotation.x, m_qOriginRotation.y, m_qOriginRotation.z, m_qOriginRotation.w);
                //transform.position = m_vOriginPosition;
                m_bCanShake = true;
            }
        }
    }
}
