#include "MusicSound.h"
MusicSound::MusicSound()
{
	LoadMedia();
}

MusicSound::~MusicSound()
{
	
}

void MusicSound::LoadMedia()
{
	LoadMusic(MUSICTEST);
}

Mix_Music* MusicSound::LoadMusic(const char * music)
{
	auto found = musics.find(music);
	if (found == musics.end())
	{
		Mix_Music* mixMusic = Mix_LoadMUS(music);
		if (mixMusic == NULL)
		{
			printf("Failed to load %s! SDL_mixer Error: %s\n", music, Mix_GetError());
			return NULL;
		}
		else
		{
			musics[music] = mixMusic;
			return mixMusic;
		}
	}
}

Mix_Chunk * MusicSound::LoadSound(const char * sound)
{
	auto found = sounds.find(sound);
	if (found == sounds.end())
	{
		Mix_Chunk* mixSound = Mix_LoadWAV(sound);
		if (mixSound == NULL)
		{
			printf("Failed to load %s! SDL_mixer Error: %s\n", sound, Mix_GetError());
		}
		else
		{
			sounds[sound] = mixSound;
			return mixSound;
		}
	}

}

void MusicSound::PlayMusic(const char* SelectedMusic)
{
	// If there is a music already playing.
	if (Mix_PlayingMusic() != 0)
	{
		StopMusic();
	}

	auto found = musics.find(SelectedMusic);
	if (found != musics.end())
	{
		Mix_PlayMusic(musics[SelectedMusic], -1);
	}
	else
	{
		printf("Failed to play: %s! SDL_mixer Error: %s\n", SelectedMusic, Mix_GetError());
	}
}

void MusicSound::StopMusic()
{
	Mix_HaltMusic();
}

void MusicSound::PlaySound(const char* SelectedSound)
{
	auto found = sounds.find(SelectedSound);
	if (found != sounds.end())
	{
		Mix_PlayChannel(-1, sounds[SelectedSound], 0);
	}
}

