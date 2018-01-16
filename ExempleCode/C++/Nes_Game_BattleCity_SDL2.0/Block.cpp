#include "Block.h"

Block::Block()
	: Sprite("decoupage\\Block\\brick.png", 20, 20, 30 , 32)
{
}

Block::Block(int x, int y)
	: Sprite("decoupage\\Block\\brick.png", x, y, 30, 32)
{
}


Block::~Block()
{
}
