#pragma once

#include "Sprite.h"
#include "Block.h"
#include "EnemieBalle.h"
#include "Point.h"
#include <stdlib.h>

class Enemie
	:public Sprite
{
friend class BattleCity;

public:
	Enemie();
	Enemie(EnemieBalle enemieBalle);
	~Enemie();

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

	int rDirection;

	Point<int> dir;

};
// A FAIRE
// reprendre le systeme du player sauf de mettre le deplacement random et de previliger le deplacement vers le bas
// faire un tableau d enemie pour 3 type
// si certain tank pr/definie meur lacher des power up
// si le tableau d enemie egale zero faire gagner
