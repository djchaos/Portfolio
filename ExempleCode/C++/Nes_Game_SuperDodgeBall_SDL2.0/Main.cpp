#include <iostream>

#include "SDL.h"
#include "Engine.h"
#include "DodgeBall.h"
#include "Text.h"

int main(int argc, char* args[])
{
	gEngine->Init("SDLEngine", 1024, 896);
	// creer la class jeux
	DodgeBall* game = new DodgeBall();
	gEngine->AddComponent(game);
	// creer un text (test)
	Text* textTest = new Text("en cour de devlopment", 20, 860);
	gEngine->AddComponent(textTest);

	gEngine->Run();

	delete textTest;
	delete game;

	return 0;
}