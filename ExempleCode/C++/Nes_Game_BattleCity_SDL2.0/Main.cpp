#include "Engine.h"
#include <iostream>
#include "Text.h"

#include "BattleCity.h"

int main(int argc, char* args[])
{
	//creation de lecran
	gEngine->Init("BattleCity", 474, 420);

	// affichage de texte (le score s affiche normalment juste a la fin)
	Text* NoScore = new Text(510, 0, "emulogic.ttf", "Too ez", 10);

	// creation du jeux
	BattleCity* game = new BattleCity();

	int assert = gEngine->Run();

	delete game;

	return assert;
}
 