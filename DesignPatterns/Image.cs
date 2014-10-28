using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //
    //      Implementacja wzorca projektowego proxy
    //
    public interface IImage
    {
        void DisplayImage();
    }
    
    public class Image: IImage
    {
        private readonly string _filePath;
        private readonly string _tag;

        public Image(string filePath, string tag)
        {
            Console.WriteLine("Create image");
            _filePath = filePath;
            _tag = tag;
        }

        public void DisplayImage()
        {
            Console.WriteLine("Path: {0}", _filePath);
            Console.WriteLine("Tag: {0}", _tag);
        }
    }

    public class ImageProxy : IImage
    {
        private readonly string _filePath;
        private readonly string _tag;
        private Image _image;

        public ImageProxy(string filePath, string tag)
        {
            _filePath = filePath;
            _tag = tag;
        }

        public void DisplayImage()
        {
            if (_image == null)
            {
                _image = new Image(_filePath, _tag);
            }

            _image.DisplayImage();
        }
    }
}
