﻿using UnityEngine;
using System.Collections;
using Rewired;


public class RewiredInputAdapter : BaseBehaviour {

    private Player playerControls;
    private ICreatureController creature;

    void Start()
    {
        playerControls = ReInput.players.GetPlayer(0);
        creature = GetComponent<ICreatureController>();
    }

    void Update()
    {
        float h;

        h = playerControls.GetAxisRaw("Move Horizontal");

        if (h > 0)
            creature.MoveRight(true);
        else
            creature.MoveRight(false);

        if (h < 0)
            creature.MoveLeft(true);
        else
            creature.MoveLeft(false);

        if (playerControls.GetButtonDown("Jump"))
            creature.Jump();

        if (playerControls.GetButtonDown("Attack"))
            creature.Attack(true);

        if (playerControls.GetButtonUp("Attack"))
            creature.Attack(false);
    }
}