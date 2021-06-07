using System;
using System.Collections.Generic;
using System.Text;
using YEB.Data;

namespace YEB.Repository.Impl
{
    public class FunctionRepositoryImpl : BaseRepositoryImpl, IFunctionRepository
    {
        private readonly Context _context;
        public FunctionRepositoryImpl(Context context) : base(context)
        {
            _context = context;
        }
    }
}
