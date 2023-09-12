using AutoMapper;
using Core.DAL.Concretes;
using IIB.PBS.DAL.Abstracts;
using IIB.PBS.DAL.Contexts;
using IIB.PBS.Model.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IIB.PBS.DAL.Concretes
{
    public class PBSRepository : BaseRepository, IPBSRepository
    {
        private readonly PBSContext _contex;
        private readonly IMapper _mapper;
        public PBSRepository(PBSContext context, IMapper mapper,IConfiguration configuration):base(context,mapper)
        {
            _contex = context;
            _mapper = mapper;

            _conStr = configuration.GetConnectionString("PBSConnection");

        }
       

    }
}
