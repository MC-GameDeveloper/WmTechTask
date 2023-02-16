using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public GameObject dashTrail;

    public async void Dash(Vector3 movement, Vector3 position)
    {
        dashTrail.SetActive(true);
        dashTrail.transform.position = position;
        dashTrail.transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        await Task.Delay(1000);
        dashTrail.SetActive(false);
    }
    
    void OnDrawGizmos()
    {
        Vector3 forward = transform.TransformDirection(Vector3.up) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}