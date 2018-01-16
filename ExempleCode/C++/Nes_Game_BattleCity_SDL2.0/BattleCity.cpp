#include "BattleCity.h"

BattleCity::BattleCity()
{
	//création des objets
	hud = new Sprite("decoupage\\Hud.png", 410, 0, 64, 420);
	base = new Sprite("decoupage\\base.png", 178, 392, 32, 28);
	balle = new Balle();
	player = new Player(balle);
	enemie = new Enemie();

	int map[12][13] = {
		{ 0,0,0,0,0,0,0,0,0,0,0,0,0 },
		{ 0,1,0,1,0,1,0,1,0,1,0,1,0 },
		{ 0,1,0,1,0,1,0,1,0,1,0,1,0 },
		{ 0,1,0,1,0,1,1,1,0,1,0,1,0 },
		{ 0,1,0,1,0,1,0,1,0,1,0,1,0 },
		{ 0,1,0,1,0,0,0,0,0,1,0,1,0 },
		{ 0,0,0,0,0,0,0,0,0,0,0,0,0 },
		{ 0,0,1,1,0,1,0,1,0,1,1,0,0 },
		{ 0,0,0,0,0,1,1,1,0,0,0,0,0 },
		{ 0,1,0,1,0,1,0,1,0,1,0,1,0 },
		{ 0,1,0,1,0,1,0,1,0,1,0,1,0 },
		{ 0,1,0,0,0,0,0,0,0,0,0,1,0 },
	};

	for (int i = 0; i < 12; i++)
	{
		for (int j = 0; j < 12; j++)
		{
			switch (map[j][i])
			{
			case 0:
				break;
			case 1:
				blocks.push_back(new Block(i*Block::WIDTH, j*Block::HEIGHT));
				break;
			default:
				break;
			}
		}
	}
}

BattleCity::~BattleCity()
{
	// destruction des objets
	delete base;
	delete player;
	delete hud;
	delete balle;
	delete enemie;
}

void BattleCity::Update()
{

	//for (int i = 0; i < 12; i++)
	//{
	//	for (int j = 0; j < 12; j++)
	//	{
	//		if (player->HitTest(blocks))
	//		{
	//			player->SetPosition(player->lastX, player->lastY);
	//		}
	//	}
	//}
	// test la collision entre le joueur et le block
	//if (player->HitTest(block))
	//{
	//	//si le block est visible
	//	if (block->GetIsVisible())
	//	{
	//		// remmetre le joueur a sa dernier position avant davoir toucher
	//		player->SetPosition(player->lastX, player->lastY);
	//	}
	//}
	
	// Pour chaque block
	//for()
	//{
	//	// Si Collision avec la ball
	//	if (block->HitTest(balle))
	//	{
	//		// Rendre invisible
	//		block->SetVisible(false);
	//	}
	//	// break;
	//}
}
