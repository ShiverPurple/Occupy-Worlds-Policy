using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{

    #region Initialization / Declaration

    [SerializeField] private TextMeshProUGUI fpsCounter;
    
    private float hudRefreshRate = 1f;
    private float timer;

    #endregion

    private void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsCounter.SetText("FPS: " + fps);

            timer = Time.unscaledTime + hudRefreshRate;
        }
    }

}
