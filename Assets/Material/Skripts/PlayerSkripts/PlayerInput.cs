using UnityEngine;
[RequireComponent(typeof(PlayerMovment))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{

    private Animator animator;
    private PlayerMovment playerMovment;
    private Shooter shooter;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovment = GetComponent<PlayerMovment>();
        shooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJampButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);

        if (Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            animator.SetBool("attack", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            float shootDirection = transform.localScale.x;
            shooter.Shoot(shootDirection);
            animator.SetBool("attack", false);
        }
        playerMovment.Move(horizontalDirection, isJampButtonPressed);
    }
}
