namespace MagicCardInfo.Domain.ValueObjects
{
    public class ImageURI 
    {
        public string Normal { get; private set; }

        private ImageURI () {}

        public ImageURI(string normal)
        {
            Normal = normal;
        }
    }
}