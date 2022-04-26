﻿using SamuraiApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SamuraiApp.Data
{
    public class BusinessDataLogic
    {
        private SamuraiContext _context;
        public BusinessDataLogic(SamuraiContext context)
        {
            _context = context;
        }
        /*public BusinessDataLogic()
        {
            _context = new SamuraiContext();
        }*/
        public int AddSamuraiByName(params string[] names)
        {
            foreach(string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name });
            }
            var dbResult =_context.SaveChanges();
            return dbResult;
        }

        public int  InsertNewSamurai(Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            var dbResult = _context.SaveChanges();
            return dbResult;
        }

        public Samurai GetSamuraiWithQuotes(int samuraiId)
        {
            var samuraiWithQuotes = _context.Samurais.Where(s => s.Id == samuraiId).Include(s=>s.Quotes).FirstOrDefault();
            return samuraiWithQuotes;

        }
    }
}
