using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using NAudio.Wave;

namespace Auti_turn_on_music
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Список путей к аудиофайлам, которые вы хотите воспроизвести
            List<string> audioFiles = new List<string>
            {
                "D:\\Музыка\\lkn-ona.mp3"
                // Добавьте пути к другим трекам по аналогии
            };

            // Открываем программу для воспроизведения музыки (пример с использованием Windows Media Player)
            Process.Start("C:\\Program Files\\Windows Media Player\\wmplayer.exe");

            // Воспроизводим аудиофайлы
            foreach (var audioFile in audioFiles)
            {
                PlayAudioFile(audioFile);
            }

            Console.WriteLine("Музыка воспроизведена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }

        // Метод для воспроизведения аудиофайла
        static void PlayAudioFile(string audioFile)
        {
            using (var audioFileReader = new AudioFileReader(audioFile))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFileReader);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // Подождите, пока аудиофайл не закончит воспроизведение
                }
            }
        }
    }
}

