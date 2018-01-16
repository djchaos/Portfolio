#include "Character.h"

Character::Character()
	: moveSpeed(DEFAULT_SPEED)
	, isActive(false)
{
}

Character::Character(std::string path)
	: Sprite(path.c_str())
	, moveSpeed(DEFAULT_SPEED)
	, isActive(false)
{
}

Character::~Character()
{
}

bool Character::CollisionWithBall()
{
	
	return false;
}

void Character::Update()
{

	//ne fait rien pour le moment
	CollisionWithBall();

	//deplacement des personnage
	if (isActive)
	{
		Vector2D dir = Vector2D(((gInput->IsKeyHeld(SDL_SCANCODE_D) ? 1.f : 0.f) + (gInput->IsKeyHeld(SDL_SCANCODE_A) ? -1.f : 0.f)), ((gInput->IsKeyHeld(SDL_SCANCODE_W) ? -1.f : 0.f) + (gInput->IsKeyHeld(SDL_SCANCODE_S) ? 1.f : 0.f)));

		std::cout << "GetX(): " << GetX() << std::endl;

		// Attention! La direction n,est pas normalizé! Va plus vite en diagonale.
		SetPosition(
			GetX() + dir.x * moveSpeed * gTimer->GetDeltaTime(),
			GetY() + dir.y * moveSpeed * gTimer->GetDeltaTime());

		//std::cout << gTimer->GetDeltaTime() << std::endl;;
	}
}
