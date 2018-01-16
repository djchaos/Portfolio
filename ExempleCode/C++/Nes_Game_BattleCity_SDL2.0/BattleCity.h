#pragma once

#include "Player.h"
#include "Block.h"
#include <iostream>
#include "Enemie.h"

class BattleCity :
	public Component
{
public:
	BattleCity();
	~BattleCity();

	void Update();

private:
	Sprite* hud;
	Sprite* base;
	Player* player;
	Enemie* enemie;

	// Devient un tableau de block
	std::vector<Block*> blocks;
	//Block* block;
	
	Balle* balle = nullptr;
};
// A FAIRE
// gere le tableau de vie du joueur
// gere le tableau denemie


