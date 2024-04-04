using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// unit script
public class Unit : MonoBehaviour
{
    private Animator animator;

    private Vector3 position;

    [SerializeField]
    private GameObject particleDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NewUnit")
        {
            GameManager.instance.AddNewUnit(GameManager.instance.GetUnitController().transform.InverseTransformPoint(other.transform.position));
            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            RemoveUnit();
            GameManager.instance.RemoveUnit(this);
        }

        if (other.tag == "Mine")
        {
            other.GetComponent<TrapMine>().Explosion();
        }
    }

    public Animator GetAnimator()
    {
        return animator;
    }
    public void SetAnimator(Animator anim)
    {
        animator = anim;
    }

    public Vector3 GetPosition()
    {
        return position;
    }
    public void SetPosition(Vector3 pos)
    {
        position = pos;
    }

    public void RemoveUnit()
    {
        Destroy(Instantiate(particleDestroy, transform.position, Quaternion.identity), 3f);
    }
}
