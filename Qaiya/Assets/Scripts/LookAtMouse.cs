using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform m_transform;

    private void Start()
    {
        m_transform = this.transform;
    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        m_transform.rotation = rotation;
    }

    private void Update()
    {
        LAMouse();
    }
}
