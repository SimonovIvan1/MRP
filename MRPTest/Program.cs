public class Test
{
    public int Id { get; set; }
    public int ParentId{ get; set; }
    public string Name { get; set; }
    public int Count { get; set; }

    public static void Main()
    {
        var items = new List<Test>();
        var needItems = new List<Test>();
        var item1 = new Test()
        {
            Id = 1,
            ParentId = 0,
            Name = "Стул",
            Count = 5
        };
        var item2 = new Test()
        {
            Id = 2,
            ParentId = 1,
            Name = "Сиденье",
            Count = 1
        };
        var item3 = new Test()
        {
            Id = 3,
            ParentId = 2,
            Name = "Ножки",
            Count = 4
        };
        var item4= new Test()
        {
            Id = 4,
            ParentId = 2,
            Name = "Спинка",
            Count = 1
        };
        var item5 = new Test()
        {
            Id = 5,
            ParentId = 4,
            Name = "Спинка5",
            Count = 1
        };
        var item6 = new Test()
        {
            Id = 6,
            ParentId = 4,
            Name = "Спинка6",
            Count = 1
        };
        items.Add(item1);
        items.Add(item2);
        items.Add(item3);
        items.Add(item4);
        items.Add(item5);
        items.Add(item6);
        var mainItem = items.Where(x => x.ParentId == 0).FirstOrDefault();
        var parentItems = items.Where(x => x.ParentId == mainItem.Id).ToList();
        needItems.AddRange(parentItems);
        while (parentItems.Count != 0)
        {
            var copyParents = new List<Test>(parentItems);
            parentItems.Clear();
            foreach (var parentItem in copyParents)
            {
                parentItems = items.Where(x => x.ParentId == parentItem.Id).ToList();
                needItems.AddRange(parentItems);
            }
        }
        foreach (var item in needItems)
        {
            Console.WriteLine("Нам необходимо: " + item.Name + " в количестве " + item.Count * mainItem.Count);
        }
    }
}
