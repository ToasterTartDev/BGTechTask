using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;

    [SerializeField]
    private List<Unit> units = new List<Unit>();

    // lerp unit position in local coordiantes
    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<units.Count; i++)
        {
            if (units[i] != null)
            {
                if (units[i].GetPosition() != units[i].transform.localPosition)
                    units[i].transform.localPosition = Vector3.Lerp(units[i].transform.localPosition, units[i].GetPosition(), 5f * Time.deltaTime);
            }
        }
    }

    // start 2 lines unit created
    public void StartCreated()
    {
        for (int i=-5; i<5; i++)
        {
            AddUnit(new Vector3(i * 0.5f, 0f, 0.3f));
        }
        for (int i = -5; i < 5; i++)
        {
            AddUnit(new Vector3(i * 0.5f, 0f, -0.3f));
        }
    }


    // set new position unit using list points linerenderer 
    int lastPosition = 0;
    public void SetAllUnitsPositions(List<Vector3> listPoints)
    {
        lastPosition = 0;
        for (int i=0; i<units.Count; i++)
        {
            if (units[i] != null)
            {
                units[i].SetPosition(listPoints[lastPosition]);
                lastPosition++;
                if (lastPosition >= listPoints.Count)
                    lastPosition = 0;
            }
        }
    }

    // add new unit
    public void AddUnit(Vector3 position)
    {
        Unit u = new Unit();
        u = Instantiate(unitPrefab, transform).GetComponent<Unit>();
        u.SetPosition(position);
        u.transform.localPosition = u.GetPosition();
        u.SetAnimator(u.GetComponentInChildren<Animator>());
        units.Add(u);
    }

    // remove unit
    public void RemoveUnit(Unit u)
    {
        units.Remove(u);
        Destroy(u.gameObject);
        CheckLose();
    }

    // set state unit (idle, run, finish)
    public void SetUnitState(int state)
    {
        for (int i = 0; i < units.Count; i++)
            if (units[i] != null)
                units[i].GetAnimator().SetInteger("State", state);
    }

    // check lose and restart
    public void CheckLose()
    {
        bool flag = true;
        for(int i=0; i<units.Count; i++)
        {
            if (units[i] != null)
                flag = false;
        }

        if (flag)
            SceneManager.LoadScene(0);
    }
}
