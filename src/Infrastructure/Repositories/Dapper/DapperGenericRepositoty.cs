using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CardAccess.Application.Common.Interfaces;
using CardAccess.Domain.Entities.CaLiveConfig;
using CardAccess.Domain.Repositories.Dapper;
using Dapper;
using static Dapper.SqlMapper;
using System.Data.Common;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CardAccess.Infrastructure.Repositories.Dapper;

internal class Repository<dbModelName>(IDapperDbConnection<dbModelName> dapper) : IRepositoty<dbModelName>
{
    private const string INSERT = "INSERT INTO";
    private const string SELECTALL = "SELECT * FROM";
    private const string UPDATE = "UPDATE";
    private const string DELETE = "DELETE FROM";

    public async Task<int> AddAsync<T>(T model) where T : class
    {
        try
        {
            using (var dbConnection = dapper.CreateConnection())
            {
                string _tableName = typeof(T).Name;
                var query = $"{INSERT} {_tableName} ({GetColumns<T>()}) VALUES ({GetValues<T>()})";
                var result = await dbConnection.QueryAsync<int>(query, model);
                return await Task.FromResult(result.Single());
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<int> UpdateAsync<T>(T model) where T : class
    {
        try
        {
            using (var dbConnection = dapper.CreateConnection())
            {
                string _tableName = typeof(T).Name;
                var where = GetIdentityKeyWhere<T>(model);
                var query = $"{UPDATE} {_tableName} SET {GetUpdateSet<T>()} {where}";
                return await dbConnection.ExecuteAsync(query);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<int> DeleteAsync<T>(T model) where T : class
    {
        try
        {
            using (var dbConnection = dapper.CreateConnection())
            {
                string _tableName = typeof(T).Name;
                var where = GetIdentityKeyWhere<T>(model);
                var query = $"{DELETE} {_tableName} {where}";
                return await dbConnection.ExecuteAsync(query);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> FindAsync<T>(T model) where T : class
    {
        try
        {
            using (var dbConnection = dapper.CreateConnection())
            {
                string _tableName = typeof(T).Name;
                var where = GetIdentityKeyWhere<T>(model);
                var query = $"{SELECTALL} {_tableName} {where}";
                var result = await dbConnection.QueryFirstAsync<T>(query);
                return await Task.FromResult(result);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        try
        {
            using (var dbConnection = dapper.CreateConnection())
            {
                string _tableName = typeof(T).Name;
                var id = typeof(T).GetProperties().FirstOrDefault();

                var query = $"{SELECTALL} {_tableName}";
                var result = await dbConnection.QueryAsync<T>(query);
                return await Task.FromResult(result);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAllBySpAsync<T>(string spName, object spParamModel) where T : class
    {
        try
        {
            using (var dbConnection = dapper.CreateConnection())
            {
                string _tableName = typeof(T).Name;
                var result = await dbConnection.QueryAsync<T>(spName, spParamModel, null, null, CommandType.StoredProcedure);
                return await Task.FromResult(result);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private string GetColumns<T>() where T : class
    {
        var properties = GetInsertableProperties<T>();
        return string.Join(", ", properties.Select(p => p.Name));
    }

    private string GetValues<T>() where T : class
    {
        var properties = GetInsertableProperties<T>();
        return string.Join(", ", properties.Select(p => "@" + p.Name));
    }

    private string GetUpdateSet<T>() where T : class
    {
        var properties = GetInsertableProperties<T>();
        return string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
    }
    private IEnumerable<PropertyInfo> GetInsertableProperties<T>() where T : class
    {
        return typeof(T).GetProperties().Where(p => !IsIdentityColumn(p));

    }
    private bool IsIdentityColumn(PropertyInfo property)
    {
        var keyAttr = property.GetCustomAttribute<KeyAttribute>();
        var dbGeneratedAttr = property.GetCustomAttribute<DatabaseGeneratedAttribute>();
        return keyAttr != null && dbGeneratedAttr != null && dbGeneratedAttr.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity;
    }
    private (string Name, object Value) GetKeyAndIdentityValue<T>(T entity) where T : class
    {
        var keyProperty = typeof(T).GetProperties()
            .FirstOrDefault(p =>
                p.GetCustomAttribute<KeyAttribute>() != null &&
                p.GetCustomAttribute<DatabaseGeneratedAttribute>()?.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity);

        if (keyProperty != null)
        {
            var keyName = keyProperty.Name ?? "";
            var keyValue = keyProperty.GetValue(entity) ?? 0;
            return (keyName, keyValue);
        }
        return ("", 0);
    }
    private string GetIdentityKeyWhere<T>(T entity) where T : class
    {
        string query = "WHERE";
        var properties = typeof(T).GetProperties();
        foreach (PropertyInfo item in properties)
        {
            if (item.GetCustomAttribute<KeyAttribute>() != null)
            {
                string name = item.Name;
                var value = item.GetValue(entity);
                query += $" {name} = {value}";
            }
        }
        return query;
    }
}
