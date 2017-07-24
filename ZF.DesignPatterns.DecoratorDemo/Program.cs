using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.DecoratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Widget widget = new BorderDecorator(
					 new BorderDecorator(
					   new ScrollDecorator(
						 new TextField(80, 24))));
	        widget.Draw();


            // Przykład użycia wzorca dekoratora przy obsłudze strumieni 

            Compress("test.txt", "Hello World!");

            Console.WriteLine(Decompress("test.txt"));
        }



        private static void Compress(string filename, string content)
        {
            var stream = new GZipStream(new FileStream(filename, FileMode.Create), CompressionMode.Compress);

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(content);

            stream.Write(bytes, 0, bytes.Length);

            stream.Close();
        }

        private static string Decompress(string filename)
        {
            var stream = new GZipStream(new FileStream(filename, FileMode.Open), CompressionMode.Decompress);

            byte[] bytes = new byte[100];

            stream.Read(bytes, 0, bytes.Length);

            stream.Close();

            var content = System.Text.Encoding.ASCII.GetString(bytes);

            return content;
        }


    }

   


    interface Widget
    {
        void Draw();
    }

    class TextField : Widget
    {
        private int width;
        private int height;

        public TextField(int w, int h)
        {
            width = w;
            height = h;
        }

        public void Draw()
        {
            Console.WriteLine($"TextField: ({width},{height})");
        }
    }

    abstract class Decorator : Widget
    {
        private Widget widget;

        public Decorator(Widget w)
        {
            this.widget = w;
        }

        public virtual void Draw()
        {
            widget.Draw();
        }
    }

    class BorderDecorator : Decorator
    {
        public BorderDecorator(Widget w)
            : base(w)
        { }

        public override void Draw()
        {
            base.Draw();

            Console.WriteLine("BorderDecorator");
        }
    }

    class ScrollDecorator : Decorator
    {
        public ScrollDecorator(Widget w)
            : base(w)
        { }

        public override void Draw()
        {
            base.Draw();

            Console.WriteLine("ScrollDecorator");
        }
    }
}
