﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace DiDo
{
    public enum SoundEfxEnum
    {
        BACKGROUND,
        SHOOT,
        RELOAD
    }

    public class SoundEffects
    {
        private Dictionary<SoundEfxEnum, MediaElement> effects;

        public SoundEffects()
        {
            effects = new Dictionary<SoundEfxEnum, MediaElement>();
            LoadEfx();
        }

        private async void LoadEfx()
        {
            effects.Add(SoundEfxEnum.BACKGROUND, await LoadSoundFile("ms-appx:///Assets/Sound/Zapper-16-Bit.mp3"));
            effects.Add(SoundEfxEnum.SHOOT, await LoadSoundFile("ms-appx:///Assets/Sound/shot.mp3"));
            effects.Add(SoundEfxEnum.RELOAD, await LoadSoundFile("ms-appx:///Assets/Sound/shot.mp3"));
        }

        private async Task<MediaElement> LoadSoundFile(string v)
        {
            MediaElement snd = new MediaElement();

            snd.AutoPlay = false;
            StorageFile file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri(v));
            var stream = await file.OpenAsync(FileAccessMode.Read);
            snd.SetSource(stream, file.ContentType);
            return snd;
        }

        public async Task Play(SoundEfxEnum efx)
        {
            var mediaElement = effects[efx];

            await mediaElement.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                mediaElement.Stop();
                mediaElement.Play();
            });
        }
    }
}