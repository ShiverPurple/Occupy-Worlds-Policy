using UnityEngine;

public class PlanetAndroid : MonoBehaviour
{

    #region Initialization / Declaration

    private Touch touch;

    private bool rotationLocked = false;

    #endregion

    void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            float pointer_x = touch.deltaPosition.x;
            transform.Rotate(0, -pointer_x, 0);

            rotationLocked = true;
        }
    }

    void FixedUpdate()
    {
        if (rotationLocked == false)
        {
            transform.Rotate(new Vector3(0, -1f, 0));
        }
        else if (rotationLocked == true && Input.touchCount == 0)
        {
            rotationLocked = false;
        }

        if (transform.position != new Vector3(0, 0.18f, 0))
        {
            transform.position = new Vector3(0, 0.18f, 0);
        }
    }

}
