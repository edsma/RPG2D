using Assets.Scripts.Common;
using Cinemachine;
using UnityEngine;

public class ZonaConfiner : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeCameraActive(true,collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ChangeCameraActive(false, collision);
    }

    void ChangeCameraActive(bool status, Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.player) && camera != null)
        {
            camera.gameObject.SetActive(status);
        }
    }
}
