using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    public static FMODEvents instance; 
    private EventInstance musicEventAmbient;
    private EventInstance musicEventOnClick;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicEventAmbient = RuntimeManager.CreateInstance("event:/Ambient");
        musicEventOnClick = RuntimeManager.CreateInstance("event:/Click");
        musicEventAmbient.start();

        Vector3 position = transform.position;
        musicEventAmbient.set3DAttributes(RuntimeUtils.To3DAttributes(position));
    }
  public void OnClick()
    {
        musicEventOnClick.start();
    }
}
