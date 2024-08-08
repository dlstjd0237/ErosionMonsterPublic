using UnityEngine;

public static class Utile
{
    public static RaycastHit GetMouseToRay(Camera cam)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit;
        }
        return hit;
    }
}
