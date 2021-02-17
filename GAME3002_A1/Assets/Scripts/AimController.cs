using UnityEngine.Assertions;
using UnityEngine;

public class AimController : MonoBehaviour
{
    // to create variable used to aim at target
    private AimComponent m_aimCompoent = null;

    // Start is called before the first frame update
    void Start()
    {
        m_aimCompoent = GetComponent<AimComponent>();
        Assert.IsNotNull(m_aimCompoent, "No aim component attached!");

    }

    // Update is called once per frame
    void Update()
    {
        // updtaes users imput
        HandleUserInput();
    }

    private void HandleUserInput()
    {
        // launch projectile
        if (Input.GetKey(KeyCode.Space))
        {
            // launch - launcnes the ball attached to aim component
            m_aimCompoent.OnLauchProjectile();
        }

        if (Input.GetKey(KeyCode.A))
        {
            // moves aim component left
            m_aimCompoent.moveLeft(0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move aim component right
            m_aimCompoent.moveRight(0.1f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // move aim component forward
            m_aimCompoent.moveForwad(0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // move aim component down
            m_aimCompoent.moveBack(0.1f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            // respawn
            m_aimCompoent.reSpawn();
        }
    }
}
