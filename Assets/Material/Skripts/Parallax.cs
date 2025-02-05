using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] layers; // ������ �����
    public float[] parallaxScales; // �������� ���������� ��� ������� ����
    public float smoothing = 1f; // �������� �����������

    public Transform cam; // ������ �� ������
    private Vector3 previousCamPosition; // ���������� ��������� ������

    void Awake()
    {
        cam = Camera.main?.transform; // ���������� �������� ?. ��� ����������� ��������� ������

        if (cam == null)
        {
            Debug.LogError("Main camera not found! Please ensure there is a camera with the tag 'MainCamera' in the scene.");
        }
    }

    void Start()
    {
        previousCamPosition = cam.position; // ��������� ��������� ��������� ������

        // ������������� �������� ��������� ����������
        parallaxScales = new float[layers.Length];
        for (int i = 0; i < layers.Length; i++)
        {
            parallaxScales[i] = layers[i].position.z * -1; // ������������� �������� �� ������ �������
        }
    }

    void Update()
    {
        // ��������� ��������
        for (int i = 0; i < layers.Length; i++)
        {
            float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];
            float targetX = layers[i].position.x + parallax;
            Vector3 targetPosition = new Vector3(targetX, layers[i].position.y, layers[i].position.z);
            layers[i].position = Vector3.Lerp(layers[i].position, targetPosition, smoothing * Time.deltaTime);
        }

        previousCamPosition = cam.position; // ��������� ���������� ��������� ������
    }
}
