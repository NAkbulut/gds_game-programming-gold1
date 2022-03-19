using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Entry(GameObject vehicle);
    void Update();
    void FixedUpdate();
    void StateTransition();
    void Exit();
}
