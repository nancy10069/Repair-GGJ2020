using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    GameObject explosionatorPrefab;
    public static ExplosionController instance;

    private void Awake()
    {
        explosionatorPrefab = Resources.Load<GameObject>("ExplosionResources/Explosionator");
        instance = this;
    }

    public void MakeExplosion(Vector3 where, ExplosionSize size, List<Texture> limbs)
    {
        GameObject g = Instantiate<GameObject>(explosionatorPrefab, transform);
        g.transform.position = where;
        g.GetComponent<Explosionator>().FireEffect(where, size, limbs);
    }
}
