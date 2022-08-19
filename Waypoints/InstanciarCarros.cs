using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarCarros : MonoBehaviour
{
    public GameObject prefabCarro;

    int numCarros = 20;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < numCarros; i++)
        {
            Instantiate(prefabCarro, new Vector3(Random.Range(-50f,50f), 0.30f, Random.Range(-50f, 50f)), Quaternion.Euler(0, 180, 0));
        }
    }
}
