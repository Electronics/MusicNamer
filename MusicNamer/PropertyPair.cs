namespace MusicNamer
{

    class PropertyPair
    {
        public string name;
        public int count;

        public PropertyPair(string propertyName, int propertyCount)
        {
            name = propertyName;
            count = propertyCount;
        }

        override public string ToString()
        {
            return name + ": " + count.ToString();
        }
    }}