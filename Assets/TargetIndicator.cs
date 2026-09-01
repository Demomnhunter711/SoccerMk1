using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public RectTransform arrow;

    void Update()
    {
        Vector3 direction = target.position - player.position;

        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        arrow.rotation = Quaternion.Euler(0, 0, -angle);
    }
}