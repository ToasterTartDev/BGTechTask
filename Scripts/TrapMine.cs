using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mine script
public class TrapMine : MonoBehaviour
{
    [SerializeField]
    private GameObject particleExplosion;

    public void Explosion()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 1f);
        print(hits.Length);
        for (int i = 0; i < hits.Length; i++)
        {
            //print(hits[i].tag);
            if (hits[i].tag == "Unit")
            {
                hits[i].GetComponent<Unit>().RemoveUnit();
                GameManager.instance.RemoveUnit(hits[i].GetComponent<Unit>());
            }
        }

        Destroy(Instantiate(particleExplosion, transform.position, Quaternion.identity), 3f);
        Destroy(this.gameObject);
    }
}
