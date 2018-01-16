#pragma once

#include "Sprite.h"
#include "Block.h"
#include "Balle.h"
#include "Point.h"

class Player
	: public Sprite
{
friend class BattleCity;

public:
	Player();
	Player(Balle* balle);
	~Player();

	void Update();

private:

	float speed;

	// enregistre la dernier position du tank
	int lastX = 0;
	int lastY = 0;

	// enregistre la dernier direction du tank
	int lastDirX;
	int lastDirY;

	// pour placer la balle a la position du canon
	int ballePositionX;
	int ballePositionY;

	// tableau de balle de un seule index
	Point<int> dir;
	Balle* balle;
};
// A FAIRE
// mettre un spwan 
// si toucher par balle enemie perdre une vie
// si moin de 2 vie faire fin de partie
// power up
