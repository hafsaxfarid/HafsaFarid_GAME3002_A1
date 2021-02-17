using UnityEngine.Assertions;
using UnityEngine;

public class AimComponent : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_initialVel = Vector3.zero; // initial velocity

    private Rigidbody m_rBody = null;
    private GameObject m_aimDisplay = null;

    private bool m_bIsGrounded = true;

    private void Start()
    {
        // sets initial velocity on start
        m_initialVel.y = 7.7f;
        m_initialVel.x = 0.0f;
        m_initialVel.z = 7.0f;
        m_rBody = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rBody, "No rigidBody component attached!");

        CreateAimDisplay();
    }

    private void Update()
    {
        UpdateAimPosition();
    }
    private void CreateAimDisplay()
    {
        // creates aim object
        m_aimDisplay = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        m_aimDisplay.transform.position = Vector3.zero;
        m_aimDisplay.transform.localScale = new Vector3(1.0f, 0.2f, 1.0f);

        m_aimDisplay.GetComponent<Renderer>().material.color = Color.red;
        m_aimDisplay.GetComponent<Collider>().enabled = false;

    }

    public void OnLauchProjectile()
    {
        if (!m_bIsGrounded)
        {
            return;
        }

        m_aimDisplay.transform.position = GetAimPosition();
        m_bIsGrounded = false;

        transform.rotation = CalculationTools.CalcAim.UpdateBallFacingPosition(m_aimDisplay.transform.position, transform.position);
        m_rBody.velocity = m_initialVel;
    }
    private void UpdateAimPosition()
    {
        if (m_aimDisplay != null && m_bIsGrounded)
        {
            m_aimDisplay.transform.position = GetAimPosition();
        }
    }

    private Vector3 GetAimPosition()
    {
        float fTime = 2f * (0.0f - m_initialVel.y / Physics.gravity.y);

        Vector3 vFlatVel = m_initialVel;
        vFlatVel.y = 0.0f;
        vFlatVel *= fTime;

        return (transform.position + vFlatVel);
    }


    #region INPUT_FUNCTIONS
    public void moveRight(float fVal)
    {
        m_initialVel.x += fVal;
    }
    public void moveLeft(float fVal)
    {
        m_initialVel.x -= fVal;
    }
    public void moveForwad(float fVal)
    {
        m_initialVel.z += fVal;
    }
    public void moveBack(float fVal)
    {
        m_initialVel.z -= fVal;
    }

    public void reSpawn()
    {
        // sets balls position to that of the starting position
        m_rBody.transform.position = new Vector3(0.0f, 3.14f, -23.35f);

        m_bIsGrounded = true;

        m_initialVel.y = 7.7f;
        m_initialVel.x = 0.0f;
        m_initialVel.z = 7.0f;
    }

    #endregion
}
