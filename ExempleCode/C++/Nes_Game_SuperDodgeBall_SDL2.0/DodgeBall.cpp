#include "DodgeBall.h"

DodgeBall::DodgeBall()
	: jukebox(nullptr)
	, currPlayerId(0)
{
	//creation du sons
	jukebox = new MusicSound();
	jukebox->PlayMusic(MUSICTEST);

	//création de la ball
	balle = new Balle();
	gEngine->AddComponent(balle);

	// creation du terrain
	terrain = new Sprite("Terrain.png");
	gEngine->AddComponent(terrain);

	//creer les deux equipe
	for (int i = 0; i < 6; i++)
	{
		team1[i] = new Character("Sam.png");
		team1[i]->SetPosition(400, 400);
		gEngine->AddComponent(team1[i]);

		team2[i] = new Character("Sam.png");
		team2[i]->SetPosition(400, 900);
		gEngine->AddComponent(team2[i]);
	}

	team1[currPlayerId]->SetActive(true);
}

DodgeBall::~DodgeBall()
{
	delete jukebox;
	delete terrain;

	for (int i = 0; i < NUM_PLAYER; i++)
	{
		delete team1[i];
		delete team2[i];
	}
}

void DodgeBall::Update()
{
	//change de joueeur
	if (gInput->IsKeyPressed(SDL_SCANCODE_TAB))
	{
		team1[currPlayerId]->SetActive(false);

		currPlayerId = currPlayerId++;

		if (currPlayerId >= NUM_PLAYER)
		{
			currPlayerId = 0;
		}

		team1[currPlayerId]->SetActive(true);
	}
}
