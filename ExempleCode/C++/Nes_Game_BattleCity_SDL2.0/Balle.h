#pragma once

#include "Sprite.h"
#include "Point.h"

class Balle: public Sprite

{
public:
	Balle();
	~Balle();

	void Update();
	void SetDir(int x, int y);

private:
	Point <int> dir;
};

