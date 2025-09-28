using Clean.Core.Entities;
using Clean.Core.Interfaces;
using Clean.InfraStructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.InfraStructure.Repository
{
    public class EmployeeRepository(AppDBContext context): IEmployeeRepository
    {
        private readonly AppDBContext _context = context;
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            return employee!;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            await _context.Database.BeginTransactionAsync();
            try
            {
                employee.EmployeeId = Guid.NewGuid();
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
                return employee;
            }
            catch (Exception)
            {
                await _context.Database.RollbackTransactionAsync();
                throw new Exception();
            }
        }
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            await _context.Database.BeginTransactionAsync();
            try
            {
                var existingEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
                if (existingEmployee != null)
                {
                    existingEmployee.EmployeeName = employee.EmployeeName;
                    existingEmployee.EmployeeEmail = employee.EmployeeEmail;
                    existingEmployee.EmployeePhone = employee.EmployeePhone;
                    await _context.SaveChangesAsync();
                    await _context.Database.CommitTransactionAsync();
                }
                return employee;
            }
            catch (Exception)
            {
                await _context.Database.RollbackTransactionAsync();
                throw new Exception();
            }
        }
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            await _context.Database.BeginTransactionAsync();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    await _context.Database.CommitTransactionAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                await _context.Database.RollbackTransactionAsync();
                throw new Exception();
            }
        }
    }
}
