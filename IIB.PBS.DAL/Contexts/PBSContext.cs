﻿using IIB.PBS.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.DAL.Contexts
{
    public class PBSContext : DbContext
    {
        public PBSContext(DbContextOptions<PBSContext> options) : base(options) { 

        }

        public DbSet<Personel> Personel { get; set; }
        public DbSet<Unvan> Unvan { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Nufus> Nufus { get; set; }
        public DbSet<Izin> Izin { get; set; }
        public DbSet<IzinTip> IzinTip { get; set; }
        

    }
}
