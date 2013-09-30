﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerDb.Core.DataStore;

namespace InnerDb.Core
{
    public class InnerDbClient
    {
		private LocalDatabase database = LocalDatabase.Instance;

        public InnerDbClient(string databaseName)
        {
			this.database.OpenDatabase(databaseName);
        }

        public List<T> GetCollection<T>()
        {
			return this.database.GetCollection<T>();
        }

        public T GetObject<T>(int id)
        {
			return this.database.GetObject<T>(id);
        }

		public T GetObject<T>(Func<T, bool> predicate)
		{
			return this.database.GetObject<T>(predicate);
		}

        public int PutObject(object obj, int id = 0) {
			return this.database.PutObject(obj, id);
        }

		public void Delete(int id)
		{
			this.database.Delete(id);
		}

        public void DeleteDatabase()
        {
			this.database.DeleteDatabase();
        }

		public void Stop()
		{
			this.database.StopJournal();
		}

		public void SetJournalIntervalMilliseconds(uint milliseconds)
		{
			this.database.SetJournalIntervalMillseconds(milliseconds);
		}
	}
}
