#pragma once

#include "Engine.h"
#include "Sprite.h"
#include "Character.h"
#include "MusicSound.h"
#include "Balle.h"

#define NUM_PLAYER 6

class DodgeBall
	: public Component
{
public:
	DodgeBall();
	~DodgeBall();

	void Update();

private:
	MusicSound* jukebox;


	Balle* balle;
	Sprite* terrain;
	int currPlayerId;
	Character* team1[NUM_PLAYER];
	Character* team2[NUM_PLAYER];
};

