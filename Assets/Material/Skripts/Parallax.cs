using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] layers; // Массив слоев
    public float[] parallaxScales; // Масштабы параллакса для каждого слоя
    public float smoothing = 1f; // Скорость сглаживания

    public Transform cam; // Ссылка на камеру
    private Vector3 previousCamPosition; // Предыдущее положение камеры

    void Awake()
    {
        cam = Camera.main?.transform; // Используем оператор ?. для безопасного получения ссылки

        if (cam == null)
        {
            Debug.LogError("Main camera not found! Please ensure there is a camera with the tag 'MainCamera' in the scene.");
        }
    }

    void Start()
    {
        previousCamPosition = cam.position; // Сохраняем начальное положение камеры

        // Инициализация массивов масштабов параллакса
        parallaxScales = new float[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            parallaxScales[i] = layers[i].position.z * -1; // Устанавливаем масштабы на основе глубины
        }
    }

    void Update()
    {
        // Вычисляем смещение
        for (int i = 0; i < layers.Length; i++)
        {
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
            float targetX = layers[i].position.x + parallax;
            Vector3 targetPosition = new Vector3(targetX, layers[i].position.y, layers[i].position.z);
            layers[i].position = Vector3.Lerp(layers[i].position, targetPosition, smoothing * Time.deltaTime);
        }

        previousCamPosition = cam.position; // Обновляем предыдущее положение камеры
    }
}
