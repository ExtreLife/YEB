using System;
using System.Collections.Generic;
using System.Text;
using YEB.Data;

namespace YEB.Repository.Impl
{
    public class RoleRepositoryImpl : BaseRepositoryImpl, IRoleRepository
    {
        private readonly Context _context;
        public RoleRepositoryImpl(Context context) : base(context)
        {
            _context = context;
        }
    }
}
