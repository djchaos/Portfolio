#include "Player.h"

Player::Player()
	: Sprite("decoupage\\tank\\player1\\bas.png", 320, 240, 26, 26)
{
	
}

Player::Player(Balle * balle)
	: Sprite("decoupage\\tank\\player1\\bas.png", 320, 240, 26, 26)
	, balle(balle)
{
}

Player::~Player()
{

}

void Player::Update()
{
	 speed = 10.0f;

	lastX = GetX();
	lastY = GetY();

	dir.x = 0;
	dir.y = 0;

	// deplacement vers le bas
	if (gInput->IsKeyHeld(SDL_SCANCODE_S))
	{
		dir.y = 1;
		lastDirY = 1;
		lastDirX = 0;
		ballePositionY = 26;
		ballePositionX = 11;
	}
	//deplacement vers le haut
	else if (gInput->IsKeyHeld(SDL_SCANCODE_W))
	{
		dir.y = -1;
		lastDirY = -1;
		lastDirX = 0;
		ballePositionY = 0;
		ballePositionX = 11;
	}
	//deplacement vers la droite
	else if (gInput->IsKeyHeld(SDL_SCANCODE_D))
	{
		dir.x = 1;
		lastDirX = 1;
		lastDirY = 0;
		ballePositionY = 11;
		ballePositionX = 26;
	}
	//deplacement vers la gauche
	else if (gInput->IsKeyHeld(SDL_SCANCODE_A))
	{
		dir.x = -1;
		lastDirX = -1;
		lastDirY = 0;
		ballePositionY = 11;
		ballePositionX = 0;
	}

	SetPosition(
		GetX() + dir.x * speed * gEngine->deltaTime, 
		GetY() + dir.y * speed * gEngine->deltaTime);
	// tire des balles
	if (gInput->IsKeyHeld(SDL_SCANCODE_SPACE))
	{
		// set sa postion par rapport au tank
		balle->SetPosition(GetX() + ballePositionX, GetY() + ballePositionY);
		// set sa direction selon le dernier movement du tank
		balle->SetDir(lastDirX * speed, lastDirY * speed);
		// rend la balle visible
		balle->SetVisible(true);
	}
}



