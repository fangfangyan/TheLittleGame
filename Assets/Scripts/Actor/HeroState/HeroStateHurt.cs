﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateHurt : IHeroState {

	private readonly StatePatternHero hero;

	private readonly IActorView actorView;

	public HeroStateHurt(StatePatternHero hero)
	{
		this.hero = hero;
		actorView = hero.GetActorView();
	}

	public void Update (float deltaTime)
	{
		UpdateView ();
		UpdateState ();
	}

	public void UpdateView()
	{
		actorView.ActorUpdate ();
	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void UpdateState()
	{

	}

	public void ToNextState(EnumHeroState state)
	{
		SetActive (false);
		hero.ToNextState (state);
	}

	public void SetActive(bool isActive)
	{
		if(isActive)
			actorView.PlayAnimation ("HeroHurt", -1f, true, TriggerAnimationEnd);
	}

	void TriggerAnimationEnd()
	{
		ToNextState (EnumHeroState.Fight);
	}
}
