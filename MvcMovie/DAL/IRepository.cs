﻿using System.Collections.Generic;

namespace MvcMovie.DAL
{
    public interface IRepository<T>
    {
        List<T> FindAll();

        T FindById(int id);

        List<T> FindByIds(IEnumerable<int> ids);
    }
}
