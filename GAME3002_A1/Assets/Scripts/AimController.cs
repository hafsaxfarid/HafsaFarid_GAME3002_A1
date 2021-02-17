using UnityEngine.Assertions;
using UnityEngine;

public class AimController : MonoBehaviour
{

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
        HandleUserInput();
    }

    private void HandleUserInput()
    {
        // launch projectile
        if (Input.GetKey(KeyCode.Space))
        {
            // launch
            m_aimCompoent.OnLauchProjectile();
        }

        if (Input.GetKey(KeyCode.A))
        {
            // move left
            m_aimCompoent.moveLeft(0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // move right
            m_aimCompoent.moveRight(0.1f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // move up
            m_aimCompoent.moveForwad(0.1f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // move down
            m_aimCompoent.moveBack(0.1f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            // respawn
            m_aimCompoent.reSpawn();
        }
    }
}
