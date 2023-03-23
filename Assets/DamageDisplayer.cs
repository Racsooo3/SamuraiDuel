using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplayer : MonoBehaviour
{
    [SerializeField] GameObject TwoDamage;
    [SerializeField] GameObject OneDamage;
    [SerializeField] GameObject ZeroDamage;

    public void SpawnTwoDamage()
    {
        Instantiate(TwoDamage, transform.position + new Vector3(0, 1f ,0), Quaternion.identity);
    }
    public void SpawnOneDamage()
    {
        Instantiate(OneDamage, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
    }
    public void SpawnZeroDamage()
    {
        Instantiate(ZeroDamage, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
    }
}
