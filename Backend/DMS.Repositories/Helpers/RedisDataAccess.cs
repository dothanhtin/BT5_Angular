using DMS.Shared;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Repositories.Helpers
{
    public static class RedisDataAccess
    {
        public async static Task<Boolean> AddListHash(string table, List<string> key, List<string> value)
        {
            var redis = RedisSharedConnection.RedisCache;
            var listHash = new HashEntry[key.Count];
            for (int i=0;i< key.Count;i++)
            {
                var hashEntry = new HashEntry(key[i], value[i]);
                listHash[i] = hashEntry;
            }
            await redis.HashSetAsync(table, listHash);
            return true;
        }
        public async static Task<Boolean> TimeToLiveRedis( string key)
        {
            var redis = RedisSharedConnection.RedisCache;
            await redis.KeyExpireAsync(key, new TimeSpan(1,1,1));
            return true;
        }
        public async static Task<Boolean> TimeToLiveAweeks(string key)
        {
            var redis = RedisSharedConnection.RedisCache;
            await redis.KeyExpireAsync(key, new TimeSpan(49, 0, 0));
            return true;
        }
        public async static Task<Boolean> AddHash(string table, string key, string value)
        {
            var redis = RedisSharedConnection.RedisCache;
            var hash = new HashEntry(key, value);
            var listHash = new HashEntry[] { hash};
            await redis.HashSetAsync(table, listHash);
            return true;
        }

        public async static Task<string> GetHash(string table, string key)
        {
            var redis = RedisSharedConnection.RedisCache;
            var result= await redis.HashGetAsync(table, key);
            return result;
        }
        public async static Task<HashEntry[]> GetHashAll(string table)
        {
            var redis = RedisSharedConnection.RedisCache;
            var result = await redis.HashGetAllAsync(table);
            return result;
        }
        public async static Task<Boolean> CheckIsExist(string table, string key)
        {
            var redis = RedisSharedConnection.RedisCache;
            var result = await redis.HashExistsAsync(table, key);
            return result;
        }
        public async static Task<Boolean> DeleteHash (string table, string key)
        {
            var redis = RedisSharedConnection.RedisCache;
            var result = await redis.HashDeleteAsync(table, key);
            return result;
        }
        public async static Task<string[]> GetListValueByListHash(string table, List<string> key)
        {
            var length = key.Count;
            RedisValue[] listKey = new RedisValue[length];
           
            for(int i =0;i< length; i++)
            {
                listKey[i] = key[i];
            }
            var redis = RedisSharedConnection.RedisCache;
            var listHash = await redis.HashGetAsync(table, listKey);
            var result = ToStringArray(listHash);
            return result;
        }
        public static string[] ToStringArray(this RedisValue[] values)
        {
            if (values == null) return null;
            if (values.Length == 0) return null;
            return Array.ConvertAll(values, x => (string)x);
        }
    }
}
