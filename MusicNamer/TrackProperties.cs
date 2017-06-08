using System;
using System.Collections.Generic;

namespace MusicNamer
{

    class TrackProperties
    {
        public const int NOT_MAPPED = 0;
        public const int PARTIALLY_MAPPED = 1;
        public const int FULLY_MAPPED = 2;

        public Track track;
        public List<Track> suggestedTracks;
        public string shortFilename;
        public string longFilename;
        public int mappedStatus;

        public TrackProperties(string longFilename, Track track)
        {
            this.track = track;
            this.longFilename = longFilename;
        }

        public bool addTrackIfNotNull(Track t)
        {
            if (t == null) return false;
            track = t;
            return true;
        }

        public override string ToString()
        {
            return $"{shortFilename}: {track}";
        }

        public bool isNullOrEmpty(string s)
        {
            if(s != null)
            {
                if(!s.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        public int checkMapStatus()
        {
            int score = 0;
            int result;
            if (!isNullOrEmpty(track.artist)) score++;
            if (!isNullOrEmpty(track.track)) score++;
            if (!isNullOrEmpty(track.album)) score++;
            if (!isNullOrEmpty(track.genre)) score++;
            if (!(track.releaseDate == DateTime.MinValue)) score++;
            if (score > 4) result = FULLY_MAPPED;
            else if (score > 0) result = PARTIALLY_MAPPED;
            else result = NOT_MAPPED;

            mappedStatus = result;
            return result;
        }
    }
}