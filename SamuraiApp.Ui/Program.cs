
//using Microsoft.EntityFrameworkCore;
//using SamuraiApp.Data;
//using SamuraiApp.Domain;

////SamuraiContext _context = new SamuraiContext();
////_context.Database.EnsureCreated();
////MultiPleDatabaseOperations();
////AddSamurai("TanjiroN","MuzanN");
////AddVariousTypes();
////QueryFilters();
////RetrieveAndUpdateSamurai();
////QueryAggregates();
////RetrieveAndUpdateMultipleSamurai();
////RetrieveAndDeleteSamurai();
////QueryAndUpdateBattles_Disconnect();
////InsertNewSamuraiWithQuote();
////AddQuoteToExistingSamurai();
////AddQuoteToExistingSamuraiNoTracking(3);
////SimpleAddQuoteToExistingSamuraiNoTracking(5);
////EagreLoadSamuraiWithQuote();
////ProjectingSample();
////ExplicitLoadQuotes();
////FilteringWithRelatedData();
////ModifyRelatedData();
////ModifyRelatedDataNoTracking();
////AddNewSamuraiToBattle();
////BattleAndSamurai();
////AddAllSamuraiToBattle();
////RemoveSamuraiFromBattle();
////RemovSamuraiFromBattleExplicit();
////AddNewSamuraiWithHorse();
////AddNewHorseToSamurai();
////AddNewHorseNoTracking();
////GetSamuraiWithHorse();
////QueryViewBattlesStat();
////GetSamurai();
////AddAddSamuraiByName("Musashi","Takeda","Nobunaga","iyeasu");



Console.WriteLine("press any key");
Console.ReadLine();

////function untuk input lebih dari satu dengan tracking entities
//void AddSamurai(params string[] names)
//{
//    foreach(string name in names)
//    {
//        _context.Samurais.Add(new Samurai { Name = name});
//    }
    
//    _context.SaveChanges();
//}

//void AddVariousTypes()
//{
//    /* _context.Samurais.AddRange(
//         new Samurai { Name = "Kensin"},
//         new Samurai { Name = "Shisio"}
//         );
//     _context.Battles.AddRange(
//         new Battle { Name = "Battle of Anegawa" },
//         new Battle { Name = "Battle of Anegawa" }
//         );*/
//    _context.AddRange(new Samurai { Name = "shinobu" }, new Samurai { Name = "shinobu" }, new Battle { Name = "Battle of gawa" },
//        new Battle { Name = "Battle of Ane" });
//    _context.SaveChanges();
//}

//void GetSamurai()
//{
//    var samurais = _context.Samurais
//        .TagWith("Get Samurai Method")
//        .ToList();
//    Console.WriteLine($"Jumalah samurai adalah  {samurais.Count}");
//    foreach (var samurai in samurais)
//    {
//        Console.WriteLine($"id {samurai.Id} : {samurai.Name}");
//    }
//}

////Filtering (lebih dari satu pakai logika and or dll)
//void QueryFilters()
//{
//    // var samurais = _context.Samurais.Where(s => s.Name == "shinobu").ToList();
//    //var samurais = _context.Samurais.Where(s => s.Name.Contains("shi")).ToList();
//    //var samurais = _context.Samurais.Where(s => s.Name.StartsWith("shi")).ToList();
//    var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name,"shi%")).ToList();
//    foreach(var samurai in samurais)
//    {
//        Console.WriteLine(samurai.Name);
//    }
//}

//void QueryAggregates()
//{
//    var name = "shinobu";
//    //var samurai  = _context.Samurais.FirstOrDefault(s => s.Name == name);
//    /*var samurai = (from s in _context.Samurais 
//                   where s.Name == name
//                   select s).FirstOrDefault();*/
//    var samurai = _context.Samurais.Find(2);
//    Console.WriteLine($"Id {samurai.Id} - Nama {samurai.Name}");
//}

//void RetrieveAndUpdateSamurai()
//{
//    var samurai = _context.Samurais.SingleOrDefault(s => s.Id == 2);
//    samurai.Name = "Kyojiro Udate Nama ";
//    _context.SaveChanges();
//}

//void RetrieveAndUpdateMultipleSamurai()
//{
//    var samurais = _context.Samurais.Skip(0).Take(4).ToList();
//    samurais.ForEach(s => s.Name += "san");
//    _context.SaveChanges();
//}

//void MultiPleDatabaseOperations()
//{
//    var samurai = _context.Samurais.OrderBy(s => s.Id).LastOrDefault();
//    samurai.Name += "sans";
//    _context.Samurais.Add(new Samurai {Name = "Gyomei"});
//    _context.SaveChanges();
//}

//void RetrieveAndDeleteSamurai()
//{
//    //var samurai = _context.Samurais.Find(6);
//    ///_context.Samurais.Remove(samurai);
//    var samurai = _context.Samurais.Where(s => s.Name.StartsWith("shinobu")).ToList();
//    _context.Samurais.RemoveRange(samurai);
//    _context.SaveChanges();
//}

///*void QueryAndUpdateBattles_Disconnect()
//{
//    List<Battle> disconnectedBattles;
//    using (var context1 = new SamuraiContextNoTracking())
//    {   
//        //disconnectedBattles = context1.Battles.ToList();
//        //dibawah tanpa tracking(no tracking tidak direkomendasikan untuk data yg bukan disconnecting seperti CRUD)
//        disconnectedBattles = context1.Battles.AsNoTracking().ToList();
//    }
//    disconnectedBattles.ForEach(b =>
//    {
//        b.StarDate = new DateTime(1550, 02, 02);
//        b.EndDate = new DateTime(1565, 04, 04);

//    });

//    using(var context2 = new SamuraiContext())
//    {
//        context2.UpdateRange(disconnectedBattles);
//        context2.SaveChanges();
//    }
//}
//*/
//void InsertNewSamuraiWithQuote()
//{
//    var samurai = new Samurai 
//    {
//        Name = "Musashi",
//        Quotes = new List<Quote> 
//        { 
//           new Quote {Text = "Think lightly of yourself and deeply world"},
//           new Quote {Text = "Do nothing that is of no use"}
//        }
        
//      };
//    _context.Samurais.Add(samurai);
//    _context.SaveChanges();
//}

//void AddQuoteToExistingSamurai()
//{
//    var samurai = _context.Samurais.Where(s => s.Id == 1).FirstOrDefault();
//    samurai.Quotes.Add(new Quote
//    {
//        Text = "ok aja"
//    });
//    _context.SaveChanges();
//}

//void AddQuoteToExistingSamuraiNoTracking(int samuraiId)
//{
//    var samurai = _context.Samurais.Find(samuraiId);
//    samurai.Quotes.Add(new Quote
//    {
//        Text = "ok aja"
//    });
//    _context.SaveChanges();

//    using (var context1 = new SamuraiContext())
//    {
//        //context1.Update(samurai);
//        context1.Samurais.Attach(samurai);
//        context1.SaveChanges();
//    }
//}

//void SimpleAddQuoteToExistingSamuraiNoTracking(int samuraiId)
//{
//    var quote = new Quote { Text = "Never Stay from way", SamuraiId = samuraiId};
//    using (var context1 = new SamuraiContext())
//    {
//        context1.Update(quote);
//        context1.SaveChanges();
//    }
//}

//void EagreLoadSamuraiWithQuote()
//{
//    //var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
//    //var splitquery = _context.Samurais.AsSplitQuery().Include(s => s.Quotes).ToList();
//    //var filteredEntity = _context.Samurais.Include(s => s.Quotes.Where(d => d.Text.Contains("ok"))).ToList();
//    //var filterEntityInclude = _context.Samurais.Where(s => s.Name.Contains("san")).Include(s => s.Quotes).ToList();
//    var singleFild = _context.Samurais.Where(s=>s.Id == 1).Include(s=>s.Quotes).FirstOrDefault();
//}

//void ProjectingSample()
//{
//    // var result = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
//    //var idandresult =_context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
//    //var resultWithCount = _context.Samurais.Select(s => new { s.Id, s.Name, NumOfQuote = s.Quotes.Count }).ToList();
//    var samuraiAndQuotes = _context.Samurais.Select(s => new 
//    {
//        samurai = s, BestQuotes = s.Quotes.Where(q => q.Text.Contains("ok"))
//    }).ToList();
//}

////mengambil object yg sudah ada di memory
//void ExplicitLoadQuotes()
//{
//    //_context.Set<Horse>().Add(new Horse { SamuraiId = 1, Name = "Yamatomaru" });
//    //_context.SaveChanges();

//    var samurai = _context.Samurais.Find(1);
//    _context.Entry(samurai).Collection(s=>s.Quotes).Load();
//}

//void FilteringWithRelatedData()
//{
//    var samurais = _context.Samurais.Where(s => s.Quotes.Any(s => s.Text.Contains("ok"))).ToList();
//}

////modify object yg berelasi di tabel yang berbeda dengan syarat masih tracking
//void ModifyRelatedData()
//{
//    var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 14);
//    samurai.Quotes[0].Text = "hello world";
//    _context.Remove(samurai.Quotes[1]);
//    _context.SaveChanges();
//}

//void ModifyRelatedDataNoTracking()
//{
//    var samura = _context.Samurais.Include(s=> s.Quotes).FirstOrDefault(s => s.Id == 14);
//    var quote = samura.Quotes[0];
//    quote.Text = ".net core 6";
    
//    using(var context1 = new SamuraiContext())
//    {
//        //context1.Quotes.Update(quote);
//        context1.Entry(quote).State = EntityState.Modified;
//        context1.SaveChanges();
//    }
//}

//void AddNewSamuraiToBattle()
//{
//    var battle = _context.Battles.FirstOrDefault();
//    battle.Samurais.Add(new Samurai { Name = "Nobunaga Oda" });
//    _context.SaveChanges();
//}

//void BattleAndSamurai()
//{
//    //var battle = _context.Battles.Include(s => s.Samurais).FirstOrDefault(b => b.BattleId == 1);
//    var battles = _context.Battles.Include(b=>b.Samurais).ToList();
//}

//void AddAllSamuraiToBattle()
//{
//    var allbattles = _context.Battles.ToList();
//    var allsamurai = _context.Samurais.ToList();
//    foreach(var battle in allbattles)
//    {
//        battle.Samurais.AddRange(allsamurai);
//    }
//    _context.SaveChanges();
//}

//void RemoveSamuraiFromBattle()
//{
//    var battleWithSamurai = _context.Battles.Include(s => s.Samurais.Where(s => s.Id == 12))
//        .SingleOrDefault(b => b.BattleId == 1);
//    var samurai = battleWithSamurai.Samurais[0];
//    battleWithSamurai.Samurais.Remove(samurai);
//    _context.SaveChanges();
//}

//void RemovSamuraiFromBattleExplicit()
//{
//    var battlesamurai = _context.Set<BattleSamurai>().
//        SingleOrDefault(bs => bs.BattleId == 1  && bs.SamuraiId == 1);
//    if(battlesamurai != null)
//    {
//        _context.Remove(battlesamurai);
//        _context.SaveChanges();
//    }
//}

//void AddNewSamuraiWithHorse()
//{
//    var samurai = new Samurai {Name = "Kensin Himura" };
//    samurai.Horse = new Horse { Name = "Nekochan" };
//    _context.Samurais.Add(samurai);
//    _context.SaveChanges();
//}

//void AddNewHorseToSamurai()
//{
//    var horse = new Horse { Name = "Red Hare", SamuraiId =2 };
//    _context.Add(horse);
//    _context.SaveChanges();
//}

//void AddNewHorseNoTracking()
//{
//    var samurai  = _context.Samurais.AsNoTracking().FirstOrDefault(s=>s.Id ==3);
//    samurai.Horse = new Horse { Name = "Silver Thunder" };

//    using (var context1 = new SamuraiContext())
//    {
//        _context.Samurais.Attach(samurai);
//        _context.SaveChanges();
//    }
//}

//void GetSamuraiWithHorse()
//{
//    //var samurai = _context.Samurais.Include(s => s.Horse).ToList();
//    var Horseaja = _context.Set<Horse>().Find(2);
//}

//void QueryViewBattlesStat()
//{
//    /*var results = _context.SamuraiBattleStarts.ToList();
//    foreach (var result in results)
//    {
//        Console.WriteLine($"{result.Name} - {result.NumberOfBattles} - {result.EarliestBattle}");
//    }*/

//    var firststat = _context.SamuraiBattleStarts.FirstOrDefault(s=>s.Name == "Kensin");
//    Console.WriteLine($"{firststat.Name} - {firststat.NumberOfBattles} - {firststat.EarliestBattle}");
//}

///*
//void QueryUsingRawSql()
//{
//    var samurais = _context.Samurais.FromSqlRaw()
//}
//*/

//void AddAddSamuraiByName(params string[] names)
//{
//    var bs = new BusinessDataLogic();
//    var newSamuraisCreateCount = bs.AddSamuraiByName(names);
//}

//struct IdAndName
//{
//    public IdAndName(int  id, string name)
//    {
//        Id = id;
//        Name = name;
//    }
//    public int Id;
//    public string Name;
//}