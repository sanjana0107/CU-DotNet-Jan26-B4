namespace Day47Exercise
{
    class Item
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public string Category { get; set; }

        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }

    class Container 
    {
        public string ContainerId { get; set; }

        public List<Item> Items { get; set; }

        public Container(string id, List<Item> items) 
        {
            ContainerId = id;
            Items = items ?? new List<Item>();            
        }        

        public static List<string> FindHeavyContainers(List<List<Container>> Containers, double weightThreshold)
        {
            var ConIdList = Containers.SelectMany(x => x)
                .Where(x => x.Items.Sum(y => y.Weight) > weightThreshold)
                .Select(n => n.ContainerId).ToList();
            return ConIdList;
        }

        public static Dictionary<string, int> GetItemsCountByCategory(List<List<Container>> Containers)
        {
            var ItemCount = Containers.SelectMany(x => x)
                .SelectMany(y => y.Items)
                .GroupBy(g => g.Category)
                .ToDictionary(g => g.Key, g => g.Count());
            return ItemCount;
        }

        public static List<Item> FlattenAndSortShipment(List<List<Container>> Containers)
        {
            var itemList = Containers.SelectMany(x => x).SelectMany(x => x.Items);
            var distinctItem = itemList.DistinctBy(x => x.Name);
            var finalList = distinctItem.OrderBy(x => x.Category)
                .ThenByDescending(x => x.Weight).ToList();
            return finalList;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            var cargoBay = new List<List<Container>>
            {
                // ROW 0: High-Value Tech Row
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"), // Heavy Item
                        new Item("Cables", 1.2, "Tech")
                    })
                },

            // ROW 1: Mixed Consumer Goods
                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {   
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                // ROW 2: Fragile & Perishables (Includes an Empty Container)
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
                },

                // ROW 3: EDGE CASE - Empty Row
                new List<Container>() // A row that exists but has no containers
                };
                var heavy = Container.FindHeavyContainers(cargoBay, 40);
                var categoryCounts = Container.GetItemsCountByCategory(cargoBay);
                var flattened = Container.FlattenAndSortShipment(cargoBay);

            Console.WriteLine("Heavy Containers:");
            foreach (var item in heavy)
            {
                Console.WriteLine(item);
            }
            //heavy.ForEach(Console.WriteLine);

            Console.WriteLine("\nCategory Counts:");
            foreach (var item in categoryCounts)
                Console.WriteLine($"{item.Key}: {item.Value}");

            Console.WriteLine("\nFlattened Shipment:");
            foreach (var item in flattened)
                Console.WriteLine($"{item.Name} - {item.Category} - {item.Weight}");
        }
    }
}
