using System;
using System.Collections.Generic;
using System.Text;
using YEB.Data;

namespace YEB.Repository.Impl
{
    public class MenuRepositoryImpl : BaseRepositoryImpl, IMenuRepository
    {
        private readonly Context _context;
        public MenuRepositoryImpl(Context context) : base(context)
        {
            _context = context;
        }
    }
}
