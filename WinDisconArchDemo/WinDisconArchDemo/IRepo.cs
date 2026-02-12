using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDisconArchDemo
{
    public interface IRepo<T>
    {
        bool AddData(T obj);
        bool UpdateData(int id, T obj);
        bool DeleteData(int id);
        List<T> ShowAll();
        T SearchByID(int id);
    }
}
