using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ticket_xamarin.Models;
using Xamarin.Forms;

namespace ticket_xamarin.Controllers
{
    public class SQLiteCtrl
    {
        private readonly SQLiteAsyncConnection conn;

        public SQLiteCtrl(string dbPath) 
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Ticket>();
        }

        public Task<int> CreateVenta(Ticket ticket)
        {
            return conn.InsertAsync(ticket);
        }

        public Task<List<Ticket>> AllVentas()
        {
            return conn.Table<Ticket>().ToListAsync();
        }

        public Task<int> DeleteVenta(Ticket ticket)
        {
            return conn.DeleteAsync(ticket);
        }

        public Task<Ticket> OneVenta(int id)
        {
            return conn.Table<Ticket>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
