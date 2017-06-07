using System;

namespace MusicNamer
{

    class Track
    {
        public string artist;
        public string track;
        public string album;
        public string genre;
        public DateTime releaseDate;
        public int duration;
        public string comment;

        public int artistLevDistance;
        public int trackLevDistance;

        public Track()
        {

        }

        public Track(string newArtist, string newTrack, string newAlbum, string newGenre, DateTime newReleaseDate, int newDuration)
        {
            artist = newArtist;
            track = newTrack;
            album = newAlbum;
            genre = newGenre;
            releaseDate = newReleaseDate;
            duration = newDuration;
        }

        public void fromKeyPair(int type, string value)
        {
            switch(type)
            {
                case TRACK:
                    track = value;
                    break;
                case ARTIST:
                    artist = value;
                    break;
                case ALBUM:
                    album = value;
                    break;
                case GENRE:
                    genre = value;
                    break;
                case COMMENT:
                    comment = value;
                    break;
            }
        }

        override public string ToString()
        {
            return "Artist: " + artist + ", Track: " + track + ", Album: " + album +
                ", Release Date: " + releaseDate.ToShortDateString() + ", Genre " + genre + " " + duration + "ms. Comment: "+comment;
        }


        public const int IGNORE = 0;
        public const int TRACK = 1;
        public const int ARTIST = 2;
        public const int ALBUM = 3;
        public const int GENRE = 4;
        public const int RELEASE_DATE = 5;
        public const int DURATION = 6;
        public const int LABEL = 7;
        public const int OTHER = 8;
        public const int COMMENT = 9;
        

    }
}