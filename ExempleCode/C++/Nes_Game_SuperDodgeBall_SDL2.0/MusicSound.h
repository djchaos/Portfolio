#pragma once

#include "SDL_Mixer.h"
#include <map>

#define MUSICTEST "03-change-position.mp3"


class MusicSound
{
public:
	MusicSound();
	~MusicSound();

	void LoadMedia();
	Mix_Music* LoadMusic(const char* music);

	void LoadSound();
	Mix_Chunk * MusicSound::LoadSound(const char * sound);

	void PlayMusic(const char* SelectedMusic);
	void StopMusic();

	void PlaySound(const char* SelectedSound);

private:

	std::map<const char*, Mix_Music*> musics;
	std::map<const char*, Mix_Chunk*> sounds;
};