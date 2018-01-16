#include "Enemie.h"

Enemie::Enemie()
	:Sprite("decoupage\\tank\\enemie\\1bas.png", 0, 0, 26, 30)
{

}

Enemie::Enemie(EnemieBalle enemieBalle)
	:Sprite("decoupage\\tank\\enemie\\1bas.png", 0, 0, 26, 30)
{

}

Enemie::~Enemie()
{

}

void Enemie::Update()
{
	speed = 10.0f;

	// random number pour le deplacement de lenemie
	rDirection = rand() % 5;

	lastX = GetX();
	lastY = GetY();

	dir.x = 0;
	dir.y = 0;


	// deplacement vers le bas
	if (rDirection == 1)
	{
		dir.y = 1;
		lastDirY = 1;
		lastDirX = 0;
		ballePositionY = 26;
		ballePositionX = 11;
	}
	//deplacement vers le haut
	if (rDirection == 2)
	{
		dir.y = -1;
		lastDirY = -1;
		lastDirX = 0;
		ballePositionY = 0;
		ballePositionX = 11;
	}
	//deplacement vers la droite
	if (rDirection == 3)
	{
		dir.x = 1;
		lastDirX = 1;
		lastDirY = 0;
		ballePositionY = 11;
		ballePositionX = 26;
	}
	//deplacement vers la gauche
	if (rDirection == 4)
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
}
