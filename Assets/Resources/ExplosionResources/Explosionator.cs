using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosionator : MonoBehaviour
{
    List<GameObject> limbParticleSystems = new List<GameObject>();
    ParticleSystem inkParticleSystem;

    public void FireEffect(Vector3 where, ExplosionSize size, List<Texture> partsList)
    {
        GameObject inkTemp = Instantiate(Resources.Load<GameObject>("ExplosionResources/WetExplosion"), this.transform);
        inkTemp.transform.position = where;
        inkParticleSystem = inkTemp.GetComponent<ParticleSystem>();

        if (size == ExplosionSize.Small)
            inkParticleSystem.Emit(15);
        else if (size == ExplosionSize.Medium)
            inkParticleSystem.Emit(25);
        else if (size == ExplosionSize.Large)
            inkParticleSystem.Emit(40);

        GameObject newLimbEmitter = Resources.Load<GameObject>("ExplosionResources/NewLimb");
        Material newLimbMat = Resources.Load<Material>("ExplosionResources/LimbMat");
        if (partsList != null)
        {
            for (int i = 0; i < partsList.Count; i++)
            {
                GameObject emitterGO = Instantiate(newLimbEmitter, this.transform);
                emitterGO.transform.position = where;
                limbParticleSystems.Add(emitterGO);

                Material instLimbMat = Instantiate<Material>(newLimbMat);
                instLimbMat.SetTexture("_MainTex", partsList[i]);

                ParticleSystem pS = emitterGO.GetComponent<ParticleSystem>();
                pS.GetComponent<ParticleSystemRenderer>().material = instLimbMat;
                pS.Emit(1);
            }
        }

        Invoke("_Cleanup", 5);
    }

    private void _Cleanup()
    {
        Destroy(inkParticleSystem);
        for (int i = limbParticleSystems.Count - 1; i >= 0; i--)
        {
            GameObject g = limbParticleSystems[i];
            limbParticleSystems.Remove(g);
            Destroy(g);
        }
        Destroy(this.gameObject);
    }
}

public enum ExplosionSize { Small, Medium, Large }
