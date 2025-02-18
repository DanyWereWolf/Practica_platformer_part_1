using UnityEngine;
[RequireComponent(typeof(PlayerMovment))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovment playerMovment;
    private Shooter shooter;
    private void Awake()
    {
        playerMovment = GetComponent<PlayerMovment>();
        shooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJampButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);

        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            float shootDirection = transform.localScale.x;
            shooter.Shoot(shootDirection);
        }

        playerMovment.Move(horizontalDirection, isJampButtonPressed);
    }
}
