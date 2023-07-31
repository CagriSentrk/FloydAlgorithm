using System;
using System.Collections.Generic;

public class Song
{
    private string name;
    public Song NextSong { get; set; }

    public Song(string name)
    {
        this.name = name;
    }

    public bool IsInRepeatingPlaylist()
    {
        Song _song = this;    // Başlangıçta iki işaretçi de çalma listesinin başlangıcına işaret ediyor.
        Song _song2 = this;

        while (_song != null && _song2.NextSong != null)
        {
            _song = _song.NextSong;                 // _song'u bir adım ileri taşı.
            _song2 = _song2.NextSong.NextSong;      // _song2'yi işaretçiyi iki adım ileri taşı. 

            if (_song == _song2)
            {
                // Eğer _song, _song2'ye yetişirse (yani döngü bulunursa), 
                // bu, çalma listesinde tekrarlayan bir çalma listesi olduğu anlamına gelir.
                return true;
            }
        }

        // Eğer while döngüsü tamamlandıysa, yani _song ve _song2 birbirini karşılamadıysa, 
        // bu durumda çalma listesinde döngü yok ve tekrarlayan bir çalma listesi değil.
        return false;
    }

    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");

        first.NextSong = second;   // "Hello" şarkısı, "Eye of the tiger" şarkısına referans yapıyor.
        second.NextSong = first;   // "Eye of the tiger" şarkısı, "Hello" şarkısına referans yapıyor.

        Console.WriteLine(first.IsInRepeatingPlaylist()); // Çıktı: True 
    }
}
