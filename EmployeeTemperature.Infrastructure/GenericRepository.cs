﻿using EmployeeTemperature.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTemperature.Infrastructure
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly EmployeeTemperatureContext _context;
        public GenericRepository(EmployeeTemperatureContext context)
        {
            _context = context; 
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);            
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
