﻿using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace ExpensesApp.Models
{
    public class Expense
    {
        [PrimaryKey] [AutoIncrement] public int Id { get; set; }

        public string Name { get; set; }

        public float Amount { get; set; }

        [MaxLength(25)] public string Description { get; set; }
        
        public string Category { get; set; }

        public DateTime Date { get; set; }

        public static int InsertExpense(Expense expense)
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Insert(expense);
            }
        }

        public static List<Expense> GetExpenses()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList();
            }
        }
        
        public static List<Expense> GetExpenses(string category)
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(e => e.Category == category).ToList();
            }
        }

        public static float TotalExpensesAmount()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList().Sum(e => e.Amount);
            }
        }
    }
}