using static System.Net.Mime.MediaTypeNames;

namespace HWHZ7
{
    class BpI
    {
        public string N { get; set; }
        public double V { get; set; }

        public BpI(string n, double v)
        {
            N = n;
            V = v;
        }
    }
    class Bp
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Manufacturer { get; set; }
        public string Fabric { get; set; }
        public double Weight { get; set; }
        public double Capacity { get; set; }
        public List<BpI> Contents { get; private set; }

        public event EventHandler<BpI> ItemAdded;

        public Bp()
        {
            Contents = new List<BpI>();
        }

        public void AddItem(BpI it)
        {
            double currentVolume = 0;
            foreach (var i in Contents)
            {
                currentVolume += i.V;
            }

            Contents.Add(it);
            ItemAdded?.Invoke(this, it);
        }
    }
    internal class Program
    {
        delegate (int R, int G, int B) GetC(string c);

        static void Main()
        {
            //1
            GetC getC = delegate (string c)
            {
                return c.ToLower() switch
                {
                    "червоний" => (255, 0, 0),
                    "оранжевий" => (255, 165, 0),
                    "жовтий" => (255, 255, 0),
                    "зелений" => (0, 255, 0),
                    "блакитний" => (0, 127, 255),
                    "синій" => (0, 0, 255),
                    "фіолетовий" => (139, 0, 255)
                };
            };

            Console.WriteLine("Введіть колір веселки:");
            string c = Console.ReadLine();
            
                var rgb = getC(c);
                Console.WriteLine($"RGB для кольору {c}: ({rgb.R}, {rgb.G}, {rgb.B})");


            //2

            Bp backpack = new Bp
            {
                Color = "Синій",
                Brand = "Nike",
                Manufacturer = "Nike Inc.",
                Fabric = "Поліестер",
                Weight = 0.5,
                Capacity = 15.0
            };

            backpack.ItemAdded += delegate (object sender, BpI item)
            {
                Console.WriteLine($"Об'єкт '{item.N}' додано в рюкзак. Об'єм: {item.V} л.");
            };
            
                backpack.AddItem(new BpI("Книга", 1.0));
                backpack.AddItem(new BpI("Бутилка води", 0.5));
                backpack.AddItem(new BpI("Ноутбук", 2.0));
                // Додавання об'єкта, який перевищить обсяг рюкзака
                backpack.AddItem(new BpI("Спальний мішок", 13.0));


            //3
            int[] numbers = { 7, 14, 21, 28, 35, 1, 3, 5, 10, 14 };
            int count = numbers.Count(n => n % 7 == 0);

            Console.WriteLine($"Кількість чисел у масиві, кратних семи: {count}");

            //4
            int[] numbers1 = { -1, 0, 2, 3, -4, 5, -6, 7, 8, -9 };
            int count1 = numbers1.Count(n => n > 0);

            Console.WriteLine($"Кількість позитивних чисел у масиві: {count1}");


            //5
            int[] numbers2 = { -1, -2, -3, -1, -2, 4, 5, -6, 7, -6 };
            var NegaN = numbers2.Where(n => n < 0).Distinct();

            Console.WriteLine("Унікальні негативні числа у масиві:");
            foreach (var number3 in NegaN)
            {
                Console.WriteLine(number3);
            }

            //6
            string t = "Я хз що придумати";
            string w = "придумати";

            // Лямбда-вираз для перевірки наявності слова в тексті
            var containsWord = (string txt, string w) => txt.Contains /*Перевіяє чи є це слово в рядку*/ (w, StringComparison.OrdinalIgnoreCase /*забезпечує порівняння рядків*/);

            bool result = containsWord(t, w);
            Console.WriteLine($"Чи містить текст слово '{w}': {result}");

        }
    }
}
