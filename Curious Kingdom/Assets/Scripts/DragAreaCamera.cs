using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(BoxCollider2D))]
public class DragAreaCamera : MonoBehaviour
{
    public Camera linkedCamera;
    private BoxCollider2D boxCollider;
 
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
 
    private void LateUpdate()
    {
        float vertExtent = linkedCamera.orthographicSize;
        float horizExtent = vertExtent * Screen.width / Screen.height;
 
        Vector3 linkedCameraPos = linkedCamera.transform.position;
        Bounds areaBounds = boxCollider.bounds;
 
        linkedCamera.transform.position = new Vector3(
            Mathf.Clamp(linkedCameraPos.x, areaBounds.min.x + horizExtent, areaBounds.max.x - horizExtent),
            Mathf.Clamp(linkedCameraPos.y, areaBounds.min.y + vertExtent, areaBounds.max.y - vertExtent),
            linkedCameraPos.z);
    }
}