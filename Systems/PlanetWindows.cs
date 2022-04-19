using UnityEngine;

public class PlanetWindows : MonoBehaviour
{

    #region Initialization / Declaration

    private float rotationSpeedPc = 15f;

    private bool rotationLocked = false;

    #endregion

    void OnMouseDrag()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            transform.Rotate(0, -Input.GetAxis("Mouse X") * rotationSpeedPc, 0);
            rotationLocked = true;
        }
    }

    void FixedUpdate()
    {
        if (rotationLocked != true)
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }

        if (rotationLocked == true && !Input.GetMouseButtonDown(0))
        {
            rotationLocked = false;
        }

        if (transform.position != new Vector3(0, 0.18f, 0))
        {
            transform.position = new Vector3(0, 0.18f, 0);
        }
    }

}
