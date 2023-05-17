#include <SDL2/SDL.h>

int main(int argc, char* argv[]) {
    // Initialize SDL audio subsystem
    if (SDL_Init(SDL_INIT_AUDIO) != 0) {
        SDL_Log("Failed to initialize SDL audio: %s", SDL_GetError());
        return 1;
    }

    // Load audio file
    SDL_AudioSpec wavSpec;
    Uint32 wavLength;
    Uint8* wavBuffer;
    if (SDL_LoadWAV("audio.wav", &wavSpec, &wavBuffer, &wavLength) == NULL) {
        SDL_Log("Failed to load WAV file: %s", SDL_GetError());
        SDL_Quit();
        return 1;
    }

    // Open audio device
    SDL_AudioDeviceID deviceId = SDL_OpenAudioDevice(NULL, 0, &wavSpec, NULL, 0);
    if (deviceId == 0) {
        SDL_Log("Failed to open audio device: %s", SDL_GetError());
        SDL_FreeWAV(wavBuffer);
        SDL_Quit();
        return 1;
    }

    // Play audio
    SDL_QueueAudio(deviceId, wavBuffer, wavLength);
    SDL_PauseAudioDevice(deviceId, 0);

    // Wait for audio to finish playing
    while (SDL_GetAudioDeviceStatus(deviceId) == SDL_AUDIO_PLAYING) {
        SDL_Delay(100);
    }

    // Clean up
    SDL_CloseAudioDevice(deviceId);
    SDL_FreeWAV(wavBuffer);
    SDL_Quit();
    return 0;
}