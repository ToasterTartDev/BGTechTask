using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

// game manager
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isDraw = false;
    public bool isPlay = false;

    [SerializeField]
    private DrawPanel drawPanel;

    [SerializeField]
    private UnitController unitController;

    [SerializeField]
    private SplineFollower unitsFollower;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        unitController.StartCreated();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            if (!isPlay)
            {
                StartGame();
            }
    }

    // start game
    public void StartGame()
    {
        isPlay = true;
        unitsFollower.enabled = true;
        unitController.SetUnitState(1);
    }

    // end game
    public void StopGame()
    {
        isPlay = false;
        unitsFollower.enabled = false;
        unitController.SetUnitState(0);
    }

    // start draw
    public void ClickOnPanelDraw()
    {
        if (!isDraw)
        {
            isDraw = true;
            drawPanel.StartDraw(drawPanel.GetMousePosition());
        }
    }

    // end draw
    public void ClickOffPanelDraw()
    {
        if (isDraw)
        {
            isDraw = false;
            SetNewPositions();
        }
    }

    // leave panel draw - its end draw
    public void LeavePanelDraw()
    {
        if (isDraw)
        {
            isDraw = false;
            SetNewPositions();
        }
    }

    // create new positions units
    public void SetNewPositions()
    {
        unitController.SetAllUnitsPositions(drawPanel.GetPoints());
        drawPanel.EndDraw();
    }

    // add new units
    public void AddNewUnit(Vector3 position)
    {
        unitController.AddUnit(position);
        unitController.SetUnitState(1);
    }

    // remove unit
    public void RemoveUnit(Unit u)
    {
        unitController.RemoveUnit(u);
    }

    public UnitController GetUnitController()
    {
        return unitController;
    }
}
