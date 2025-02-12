﻿namespace EasyOposLibrary.DataAccess
{
    public class MongoUserData : IUserData
    {
        private readonly IMongoCollection<UserModel> _users;
        public MongoUserData(IDbConnection db)
        {
            _users = db.UserCollection;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var results = await _users.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<UserModel> GetUser(string id)
        {
            var result = await _users.FindAsync(u => u.Id == id);
            return result.FirstOrDefault();
        }

        public async Task<UserModel> GetUserFromAuthentication(string objectId)
        {
            var result = await _users.FindAsync(u => u.ObjectIdentifier == objectId);
            return result.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            return _users.InsertOneAsync(user);
        }

        public Task UpdateUser(UserModel user)
        {
            //Get user ref
            var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
            //Update if exists, insert if it does not
            return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }
    }
}
