#include "Balle.h"

Balle::Balle()
	: Sprite("decoupage//balle.png", 0, 0, 4, 3 )
{

}

Balle::~Balle()
{
}

void Balle::Update()
{
	if (isVisible)
	{
		SetPosition(
			GetX() + dir.x * gEngine->deltaTime, // X 
			GetY() + dir.y * gEngine->deltaTime);// Y
	}
}

void Balle::SetDir(int x, int y)
{
	dir.x = x;
	dir.y = y;
}
