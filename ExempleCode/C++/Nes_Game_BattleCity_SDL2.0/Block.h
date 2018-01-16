#pragma once

#include "Sprite.h"

class Block
	: public Sprite
{
public:
	static const int WIDTH = 30;
	static const int HEIGHT = 32;

	Block();
	Block(int x, int y);
	~Block();
};
// A FAIRE
// cree un autre type de block non destructible

