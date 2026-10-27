using System;
using UnityEngine;
namespace Hamdoku {
    public sealed class AudioModule {
        readonly AudioSource effects;
        readonly AudioSource music;
        readonly AudioSource voice;
        bool effectsEnabled = true;
        bool voiceEnabled = true;
        public AudioModule(AudioSource effects, AudioSource music, AudioSource voice) {
            if (effects == null || music == null || voice == null) {
                throw new ArgumentNullException("Audio sources must be injected by ClientMain.");
            }
            this.effects = effects;
            this.music = music;
            this.voice = voice;
        }
        public void Configure(bool effectsOn, bool musicOn, bool voiceOn, AudioClip track, float musicVolume) {
            if (track == null) {
                throw new ArgumentNullException(nameof(track));
            }
            SetEffectsEnabled(effectsOn);
            voiceEnabled = voiceOn;
            if (!effectsOn) {
                effects.Stop();
                voice.Stop();
            }
            if (!voiceOn) {
                voice.Stop();
            }
            if (music.clip != track) {
                music.clip = track;
            }
            music.loop = true;
            music.volume = musicVolume;
            if (musicOn && !music.isPlaying) {
                music.Play();
            } else if (!musicOn) {
                music.Stop();
            }
        }
        public void PlayOneShot(AudioClip clip, float volume) {
            if (clip == null) {
                throw new ArgumentNullException(nameof(clip));
            }
            if (effectsEnabled) {
                effects.PlayOneShot(clip, volume);
            }
        }
        public void SetEffectsEnabled(bool enabled) {
            effectsEnabled = enabled;
            if (!enabled) {
                effects.Stop();
                voice.Stop();
            }
        }
        public void PlayVoice(AudioClip clip, float volume) {
            if (clip == null) {
                throw new ArgumentNullException(nameof(clip));
            }
            if (effectsEnabled && voiceEnabled) {
                voice.Stop();
                voice.clip = clip;
                voice.volume = volume;
                voice.Play();
            }
        }
        public void Stop() {
            effects.Stop();
            music.Stop();
            voice.Stop();
        }
        public void Release() {
            Stop();
            UnityEngine.Object.Destroy(music.gameObject);
            UnityEngine.Object.Destroy(voice.gameObject);
        }
    }
}
