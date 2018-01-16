#pragma once

#include "Engine.h"
#include "Sprite.h"
#include "Vector2D.h"

#define DEFAULT_SPEED 100.f

class Character
	: public Sprite
{
public:
	Character();
	Character(std::string path);
	~Character();

	void SetActive(bool tf) { isActive = tf; }

	bool CollisionWithBall();

	void Update();

private: 
	bool isActive;
	float moveSpeed;
};

