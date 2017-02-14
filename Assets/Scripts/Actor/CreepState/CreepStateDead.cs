﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepStateDead : ICreepState {

	private readonly StatePatternCreep creep;

	private readonly IActorView actorView;

	public CreepStateDead(StatePatternCreep creep)
	{
		this.creep = creep;
		actorView = creep.GetActorView();
	}

	public void Update (float deltaTime)
	{
		UpdateView ();
	}

	public void UpdateView()
	{
		actorView.ActorUpdate ();
	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void ToNextState(EnumCreepState state)
	{
		SetActive (false);
		creep.ToNextState (state);
	}

	public void SetActive(bool isActive)
	{
		if(isActive)
			actorView.PlayAnimation ("HeroDead", -1f, true, TriggerAnimationEnd);
	}

	void TriggerAnimationEnd()
	{
		creep.Destroy ();
	}
}