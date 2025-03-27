namespace Models
{
    public class Card 
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string OracleText { get; private set; }
        public string ManaCost { get; private set; }
        public string TypeLine { get; private set; }
        public ImageURI ImageURI { get; private set; }

        private Card () {}

        public Card (Guid id, string name, string oracleText, string manaCost, string typeLine, ImageURI imageURI) 
        {
            Id = id;
            Name = name;
            OracleText = oracleText;
            ManaCost = manaCost;
            TypeLine = typeLine;
            ImageURI = imageURI ?? throw new ArgumentNullException(nameof(imageURI));
        }
    }
}