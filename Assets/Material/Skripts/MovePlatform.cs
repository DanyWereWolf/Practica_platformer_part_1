using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public SliderJoint2D sliderJoint; // Ссылка на Slider Joint
    public float motorSpeed = 1f; // Скорость мотора

    private void Start()
    {
        UpdateMotorSpeed(motorSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка на столкновение с объектом слоя "Ground"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Изменение направления скорости мотора при столкновении
            motorSpeed = -motorSpeed;
            UpdateMotorSpeed(motorSpeed);
        }
    }

    private void UpdateMotorSpeed(float speed)
    {
        JointMotor2D motor = sliderJoint.motor;
        motor.motorSpeed = speed; // Установка желаемой скорости
        sliderJoint.motor = motor; // Применение изменений
    }
}
